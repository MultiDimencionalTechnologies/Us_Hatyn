using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Noesis
{
    public enum AntialiasingMode
    {
        MSAA,
        PPAA
    }

    public enum TessellationMode
    {
        Once,
        Always,
        Threshold
    }

    public enum TessellationQuality
    {
        Low,
        Medium,
        High
    }

    public enum RendererFlags
    {
        None = 0,
        Wireframe = 1,
        ColorBatches = 2,
        ShowOverdraw = 4,
        FlipY = 8,
        DisableStencil = 16,
        ClearColor = 32
    }

    /////////////////////////////////////////////////////////////////////////////////////
    /// Manages updates, render and input events of a Noesis UI panel
    /////////////////////////////////////////////////////////////////////////////////////
    internal partial class UIRenderer
    {
        /////////////////////////////////////////////////////////////////////////////////
        private int _rendererId;

        private Noesis.FrameworkElement _content;
        private Noesis.Visual _root;

        private UnityEngine.Vector2 _offscreenSize;
        private UnityEngine.Vector3 _mousePos;

        private UnityEngine.GameObject _target;

        private UnityEngine.RenderTexture _texture;
        private UnityEngine.Camera _textureCamera;
        
        /////////////////////////////////////////////////////////////////////////////////
        public UIRenderer(Noesis.FrameworkElement content, UnityEngine.Vector2 offscreenSize,
            UnityEngine.GameObject target)
        {
            _rendererId = Noesis_CreateRenderer(Noesis.FrameworkElement.getCPtr(content).Handle);

            _content = content;
            _root = VisualTreeHelper.GetRoot(_content);

            _offscreenSize = offscreenSize;
            _mousePos = UnityEngine.Input.mousePosition;

            _target = target;

            _texture = FindTexture();
            if (IsRenderToTexture())
            {
                _textureCamera = _target.AddComponent<Camera>();
                _textureCamera.clearFlags = CameraClearFlags.SolidColor;
                _textureCamera.backgroundColor = new UnityEngine.Color(0.0f, 0.0f, 0.0f, 0.0f);
                _textureCamera.cullingMask = 0;
                _textureCamera.targetTexture = _texture;
            }

#if !UNITY_4_1 && !UNITY_4_2
            // Note that this function works with a null object (meaning the backbuffer)
            if (!RenderTexture.SupportsStencil(_texture))
            {
                Debug.LogWarning("Masking disabled because Stencil Buffer is not present" 
                    + ". Use a 24-bits DepthBuffer to activate it.");
            }
#endif

            _Panels.Add(_rendererId, _target.GetComponent<NoesisGUIPanel>());
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void Destroy()
        {
            _Panels.Remove(_rendererId);

            if (IsRenderToTexture())
            {
                UnityEngine.Object.Destroy(_textureCamera);
                _textureCamera = null;
                _texture = null;
            }

            _content = null;
            _root = null;

            if (NoesisGUISystem.IsInitialized)
            {
                Noesis_NotifyDestroyRenderer(_rendererId);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        public bool IsRenderToTexture()
        {
            return _texture != null;
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void Update(double timeInSeconds, Noesis.AntialiasingMode aaMode,
            Noesis.TessellationMode tessMode, Noesis.TessellationQuality tessQuality,
            Noesis.RendererFlags flags, bool enableMouse, bool enableTouch,
            bool enablePostProcess, bool flipVertically)
        {
            UpdateSettings(aaMode, tessMode, tessQuality, flags, enablePostProcess, flipVertically);
            UpdateInputs(enableMouse, enableTouch);
            if (Noesis_UpdateRenderer(_rendererId, timeInSeconds))
            {
                UnityEngine.GL.InvalidateState();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        public event System.EventHandler Rendering
        {
            add
            {
                if (!_Rendering.ContainsKey(_rendererId))
                {
                    _Rendering.Add(_rendererId, null);
                    Noesis_BindRenderingEvent(_rendererId, _raiseRendering);
                }

                _Rendering[_rendererId] += value;
            }
            remove
            {
                if (_Rendering.ContainsKey(_rendererId))
                {
                    _Rendering[_rendererId] -= value;

                    if (_Rendering[_rendererId] == null)
                    {
                        Noesis_UnbindRenderingEvent(_rendererId, _raiseRendering);
                        _Rendering.Remove(_rendererId);
                    }
                }
            }
        }

        internal delegate void RaiseRenderingCallback(int id);
        private static RaiseRenderingCallback _raiseRendering = RaiseRendering;

        [MonoPInvokeCallback(typeof(RaiseRenderingCallback))]
        private static void RaiseRendering(int id)
        {
            try
            {
                if (!_Rendering.ContainsKey(id))
                {
                    throw new InvalidOperationException("Rendering delegate not registered");
                }
                EventHandler handler = _Rendering[id];
                if (handler != null)
                {
                    handler(_Panels[id], System.EventArgs.Empty);
                }
            }
            catch(Exception e)
            {
                Noesis.Error.SetNativePendingError(e);
            }
        }

        static Dictionary<int, EventHandler> _Rendering = new Dictionary<int, EventHandler>();
        static Dictionary<int, NoesisGUIPanel> _Panels = new Dictionary<int, NoesisGUIPanel>();

        /////////////////////////////////////////////////////////////////////////////////
        const int PluginId = 0x0ACE0ACE;

        enum RenderEvent
        {
            // custom IDs
            PreRender = 2000 + PluginId,
            PostRender = 1000 + PluginId
        };

        /////////////////////////////////////////////////////////////////////////////////
        public void PreRender()
        {
            // Wait for update render commands
            Noesis_WaitUpdateRenderer(_rendererId);

            // Begin render
            IssueRenderEvent(RenderEvent.PreRender);

            // For a weird reason, if we invalidate state here in Windows OpenGL, Unity scene 
            // is not rendered any more. Instead is working without this invalidate
            if (!_isWindowsGL)
            {
                UnityEngine.GL.InvalidateState();
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void PostRender()
        {
            IssueRenderEvent(RenderEvent.PostRender);
            UnityEngine.GL.InvalidateState();

#if !UNITY_4_1 && !UNITY_4_2
            if (IsRenderToTexture())
            {
                _texture.DiscardContents(false, true);
            }
#endif
        }

        /////////////////////////////////////////////////////////////////////////////////
        public FrameworkElement GetContent()
        {
            return _content;
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void KeyDown(Noesis.Key key)
        {
            Noesis_KeyDown(_rendererId, (int)key);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void KeyUp(Noesis.Key key)
        {
            Noesis_KeyUp(_rendererId, (int)key);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void MouseDown(float x, float y, Noesis.MouseButton button)
        {
            Noesis_MouseButtonDown(_rendererId, x, y, (int)button);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void MouseUp(float x, float y, Noesis.MouseButton button)
        {
            Noesis_MouseButtonUp(_rendererId, x, y, (int)button);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void MouseDoubleClick(float x, float y, Noesis.MouseButton button)
        {
            Noesis_MouseDoubleClick(_rendererId, x, y, (int)button);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void MouseWheel(float x, float y, int wheelRotation)
        {
            Noesis_MouseWheel(_rendererId, x, y, wheelRotation);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void MouseMove(float x, float y)
        {
            Noesis_MouseMove(_rendererId, x, y);
        }

        /////////////////////////////////////////////////////////////////////////////////
        private UnityEngine.EventModifiers _modifiers = 0;

        private void ProcessModifierKey(EventModifiers modifiers, EventModifiers delta,
            EventModifiers flag, Noesis.Key key)
        {
            if ((delta & flag) > 0)
            {
                if ((modifiers & flag) > 0)
                {
                    Noesis_KeyDown(_rendererId, (int)key);
                }
                else
                {
                    Noesis_KeyUp(_rendererId, (int)key);
                }
            }
        }

#if !UNITY_EDITOR && UNITY_STANDALONE_OSX
        private static int lastFrame;
        private static int lastKeyDown;
#endif

        public void ProcessEvent(UnityEngine.Event ev, bool enableKeyboard, bool enableMouse)
        {
#if !UNITY_STANDALONE && !UNITY_EDITOR
            enableKeyboard = false;
            enableMouse = false;
#endif

            // Process keyboard modifiers
            if (enableKeyboard)
            {
                EventModifiers delta = ev.modifiers ^ _modifiers;
                if (delta > 0)
                {
                    _modifiers = ev.modifiers;

                    ProcessModifierKey(ev.modifiers, delta, EventModifiers.Shift, Key.Shift);
                    ProcessModifierKey(ev.modifiers, delta, EventModifiers.Control, Key.Control);
                    ProcessModifierKey(ev.modifiers, delta, EventModifiers.Command, Key.Control);
                    ProcessModifierKey(ev.modifiers, delta, EventModifiers.Alt, Key.Alt);
                }
            }

            switch (ev.type)
            {
                case UnityEngine.EventType.MouseDown:
                {
                    if (enableMouse)
                    {
                        UnityEngine.Vector2 mouse = ProjectPointer(ev.mousePosition.x,
                            UnityEngine.Screen.height - ev.mousePosition.y);

                        if (HitTest(mouse.x, mouse.y))
                        {
                            ev.Use();
                        }

                        Noesis_MouseButtonDown(_rendererId, mouse.x, mouse.y, ev.button);

                        if (ev.clickCount == 2)
                        {
                            Noesis_MouseDoubleClick(_rendererId, mouse.x, mouse.y, ev.button);
                        }
                    }
                    break;
                }
                case UnityEngine.EventType.MouseUp:
                {
                    if (enableMouse)
                    {
                        UnityEngine.Vector2 mouse = ProjectPointer(ev.mousePosition.x,
                            UnityEngine.Screen.height - ev.mousePosition.y);

                        if (HitTest(mouse.x, mouse.y))
                        {
                            ev.Use();
                        }

                        Noesis_MouseButtonUp(_rendererId, mouse.x, mouse.y, ev.button);
                    }
                    break;
                }
                case UnityEngine.EventType.KeyDown:
                {
                    if (enableKeyboard)
                    {
                        if (ev.keyCode != KeyCode.None)
                        {
                            int noesisKeyCode = NoesisKeyCodes.Convert(ev.keyCode);
                            if (noesisKeyCode != 0)
                            {
#if !UNITY_EDITOR && UNITY_STANDALONE_OSX
                                // In OSX Standalone, CMD + key always sends two KeyDown events for the key.
                                // This seems to be a bug in Unity. 
                                if (!ev.command || lastFrame != Time.frameCount || lastKeyDown != noesisKeyCode)
                                {
                                    lastFrame = Time.frameCount;
                                    lastKeyDown = noesisKeyCode;
#endif
                                    Noesis_KeyDown(_rendererId, noesisKeyCode);
#if !UNITY_EDITOR && UNITY_STANDALONE_OSX
                                }
#endif
                            }
                        }

                        if (ev.character != 0)
                        {
                            // Filter out character events when CTRL is down
                            bool isControl = (_modifiers & EventModifiers.Control) != 0 || (_modifiers & EventModifiers.Command) != 0;
                            bool isAlt = (_modifiers & EventModifiers.Alt) != 0;
                            bool filter = isControl && !isAlt;

                            if (!filter)
                            {
#if !UNITY_EDITOR && UNITY_STANDALONE_LINUX
                                // It seems that linux is sending KeySyms instead of Unicode points
                                // https://github.com/substack/node-keysym/blob/master/data/keysyms.txt
                                ev.character = NoesisKeyCodes.KeySymToUnicode(ev.character);
#endif
                                Noesis_Char(_rendererId, (uint)ev.character);
                            }
                        }
                    }
                    break;
                }
                case UnityEngine.EventType.KeyUp:
                {
                    if (enableKeyboard)
                    {
                        if (ev.keyCode != UnityEngine.KeyCode.None)
                        {
                            int noesisKeyCode = NoesisKeyCodes.Convert(ev.keyCode);
                            if (noesisKeyCode != 0)
                            {
                                Noesis_KeyUp(_rendererId, noesisKeyCode);
                            }
                        }
                    }
                    break;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void Activate()
        {
            Noesis_Activate(_rendererId);
        }

        /////////////////////////////////////////////////////////////////////////////////
        public void Deactivate()
        {
            Noesis_Deactivate(_rendererId);
            _modifiers = 0;
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void UpdateSettings(Noesis.AntialiasingMode aaMode,
            Noesis.TessellationMode tessMode, Noesis.TessellationQuality tessQuality,
            Noesis.RendererFlags flags, bool enablePostProcess, bool flipVertically)
        {
            // update renderer size
            if (!IsRenderToTexture())
            {
                Noesis_RendererSurfaceSize(_rendererId,
                    UnityEngine.Screen.width, UnityEngine.Screen.height,
                    _offscreenSize.x, _offscreenSize.y,
                    UnityEngine.QualitySettings.antiAliasing);

                if (_isGraphicsDeviceDirectX)
                {
                    UnityEngine.Camera camera = _target.GetComponent<Camera>() ??
                        UnityEngine.Camera.main;

                    if (enablePostProcess && camera != null &&
                        camera.actualRenderingPath == UnityEngine.RenderingPath.DeferredLighting)
                    {
                        flags |= RendererFlags.FlipY;
                    }
                }
            }
            else // Render to Texture
            {
                System.Diagnostics.Debug.Assert(_texture.width > 0);
                System.Diagnostics.Debug.Assert(_texture.height > 0);

                Noesis_RendererSurfaceSize(_rendererId,
                    _texture.width, _texture.height,
                    _offscreenSize.x, _offscreenSize.y,
                    UnityEngine.QualitySettings.antiAliasing);

                if (_isGraphicsDeviceDirectX)
                {
                    flags |= RendererFlags.FlipY;
                }
            }

            if (flipVertically)
            {
                flags ^= RendererFlags.FlipY;
            }

            // update renderer settings
            Noesis_RendererAntialiasingMode(_rendererId, (int)aaMode);
            Noesis_RendererTessMode(_rendererId, (int)tessMode);
            Noesis_RendererTessQuality(_rendererId, (int)tessQuality);
            Noesis_RendererFlags(_rendererId, (int)flags);
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void UpdateInputs(bool enableMouse, bool enableTouch)
        {
#if !UNITY_STANDALONE && !UNITY_EDITOR
            enableMouse = false;
#endif
            if (enableMouse)
            {
                // mouse move
                if (_mousePos != UnityEngine.Input.mousePosition)
                {
                    _mousePos = UnityEngine.Input.mousePosition;
                    UnityEngine.Vector2 mouse = ProjectPointer(_mousePos.x, _mousePos.y);
                    Noesis_MouseMove(_rendererId, mouse.x, mouse.y);
                }

                // mouse wheel
                int mouseWheel = (int)(UnityEngine.Input.GetAxis("Mouse ScrollWheel") * 10.0f);
                if (mouseWheel != 0)
                {
                    UnityEngine.Vector2 mouse = ProjectPointer(_mousePos.x, _mousePos.y);
                    Noesis_MouseWheel(_rendererId, mouse.x, mouse.y, mouseWheel);
                }
            }

            if (enableTouch)
            {
                for (int i = 0; i < UnityEngine.Input.touchCount; i++) 
                {
                    UnityEngine.Touch touch = UnityEngine.Input.GetTouch(i);
                    int id = touch.fingerId;
                    UnityEngine.Vector2 pos = ProjectPointer(touch.position.x, touch.position.y);
                    UnityEngine.TouchPhase phase = touch.phase;

                    if (phase == UnityEngine.TouchPhase.Began)
                    {
                        Noesis_TouchDown(_rendererId, pos.x, pos.y, id);
                    }
                    else if (phase == UnityEngine.TouchPhase.Moved ||
                        phase == UnityEngine.TouchPhase.Stationary)
                    {
                        Noesis_TouchMove(_rendererId, pos.x, pos.y, id);
                    }
                    else
                    {
                        Noesis_TouchUp(_rendererId, pos.x, pos.y, id);
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        private UnityEngine.Vector2 ProjectPointer(float x, float y)
        {
            if (!IsRenderToTexture())
            {
                // Screen coordinates
                return new UnityEngine.Vector2(x, UnityEngine.Screen.height - y);
            }
            else
            {
                // Texture coordinates

                // NOTE: A MeshCollider must be attached to the target to obtain valid
                // texture coordintates, otherwise Hit Testing won't work

                UnityEngine.Ray ray = UnityEngine.Camera.main.ScreenPointToRay(
                    new UnityEngine.Vector3(x, y, 0));

                UnityEngine.RaycastHit hit;
                if (UnityEngine.Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == _target)
                    {
                        float localX = hit.textureCoord.x * _texture.width;
                        float localY = _texture.height - hit.textureCoord.y * _texture.height;
                        return new UnityEngine.Vector2(localX, localY);
                    }
                }

                return new UnityEngine.Vector2(-1, -1);
            }
        }
        
        /////////////////////////////////////////////////////////////////////////////////
        private bool HitTest(float x, float y)
        {
            return Noesis_HitTest(Noesis.Visual.getCPtr(_root).Handle, x, y);
        }

        /////////////////////////////////////////////////////////////////////////////////
        private UnityEngine.RenderTexture FindTexture()
        {
            // Check if NoesisGUI was attached to a GameObject with a RenderTexture set
            // in the diffuse texture of its main Material
            Renderer renderer = _target.GetComponent<Renderer>();
            if (renderer != null && renderer.material != null)
            {
                return renderer.material.mainTexture as UnityEngine.RenderTexture;
            }
            else
            {
                return null;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void IssueRenderEvent(RenderEvent renderEvent)
        {
            // This triggers the Noesis rendering event
            if (_isMobile)
            {
                // NOTE: We have to make an indirect call to the PInvoke function to avoid
                //  that referenced library gets loaded just by entering current function
                IssuePluginEventMobile((int)renderEvent + _rendererId);
            }
            else
            {
                GL.IssuePluginEvent((int)renderEvent + _rendererId);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////
        private void IssuePluginEventMobile(int eventId)
        {
            Noesis_UnityRenderEvent(eventId);
        }

        /////////////////////////////////////////////////////////////////////////////////
        enum GfxDeviceRenderer
        {
            OpenGL = 0,              // OpenGL
            D3D9 = 1,                // Direct3D 9
            D3D11 = 2,               // Direct3D 11
            GCM = 3,                 // Sony PlayStation 3 GCM
            Null = 4,                // "null" device (used in batch mode)
            Hollywood = 5,           // Nintendo Wii
            Xenon = 6,               // Xbox 360
            OpenGLES = 7,            // OpenGL ES 1.1
            OpenGLES20Mobile = 8,    // OpenGL ES 2.0 mobile variant
            Molehill = 9,            // Flash 11 Stage3D
            OpenGLES20Desktop = 10   // OpenGL ES 2.0 desktop variant (i.e. NaCl)
        };

        private static bool _isGraphicsDeviceDirectX = false;
        private static bool _isWindowsGL = false;
        private static bool _isMobile = false;

        public static void SetDeviceType(int deviceType)
        {
            GfxDeviceRenderer gfxDeviceRenderer = (GfxDeviceRenderer)deviceType;

            _isGraphicsDeviceDirectX = gfxDeviceRenderer == GfxDeviceRenderer.D3D9 ||
                gfxDeviceRenderer == GfxDeviceRenderer.D3D11;

            UnityEngine.RuntimePlatform platform = UnityEngine.Application.platform;

            _isWindowsGL = gfxDeviceRenderer == GfxDeviceRenderer.OpenGL && (
                platform == UnityEngine.RuntimePlatform.WindowsEditor ||
                platform == UnityEngine.RuntimePlatform.WindowsPlayer);

            _isMobile = platform == UnityEngine.RuntimePlatform.IPhonePlayer ||
                platform == UnityEngine.RuntimePlatform.Android;
        }
    }
}
