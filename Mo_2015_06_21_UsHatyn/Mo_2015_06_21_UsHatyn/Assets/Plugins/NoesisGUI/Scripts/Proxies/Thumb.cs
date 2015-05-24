/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.4
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

namespace Noesis
{

public class Thumb : Control {

  internal Thumb(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.Thumb_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Thumb obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }


  public delegate void DragCompletedHandler(object sender, DragCompletedEventArgs e);
  public event DragCompletedHandler DragCompleted {
    add {
      if (!_DragCompleted.ContainsKey(swigCPtr.Handle)) {
        _DragCompleted.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Thumb_DragCompleted(_raiseDragCompleted, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _DragCompleted[swigCPtr.Handle] += value;
    }
    remove {
      if (_DragCompleted.ContainsKey(swigCPtr.Handle)) {

        _DragCompleted[swigCPtr.Handle] -= value;

        if (_DragCompleted[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Thumb_DragCompleted(_raiseDragCompleted, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _DragCompleted.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseDragCompletedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseDragCompletedCallback _raiseDragCompleted = RaiseDragCompleted;

  [MonoPInvokeCallback(typeof(RaiseDragCompletedCallback))]
  private static void RaiseDragCompleted(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_DragCompleted.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for DragCompleted event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _DragCompleted.Remove(cPtr);
        return;
      }
      DragCompletedHandler handler = _DragCompleted[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new DragCompletedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, DragCompletedHandler> _DragCompleted =
      new System.Collections.Generic.Dictionary<System.IntPtr, DragCompletedHandler>();


  public delegate void DragDeltaHandler(object sender, DragDeltaEventArgs e);
  public event DragDeltaHandler DragDelta {
    add {
      if (!_DragDelta.ContainsKey(swigCPtr.Handle)) {
        _DragDelta.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Thumb_DragDelta(_raiseDragDelta, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _DragDelta[swigCPtr.Handle] += value;
    }
    remove {
      if (_DragDelta.ContainsKey(swigCPtr.Handle)) {

        _DragDelta[swigCPtr.Handle] -= value;

        if (_DragDelta[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Thumb_DragDelta(_raiseDragDelta, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _DragDelta.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseDragDeltaCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseDragDeltaCallback _raiseDragDelta = RaiseDragDelta;

  [MonoPInvokeCallback(typeof(RaiseDragDeltaCallback))]
  private static void RaiseDragDelta(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_DragDelta.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for DragDelta event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _DragDelta.Remove(cPtr);
        return;
      }
      DragDeltaHandler handler = _DragDelta[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new DragDeltaEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, DragDeltaHandler> _DragDelta =
      new System.Collections.Generic.Dictionary<System.IntPtr, DragDeltaHandler>();


  public delegate void DragStartedHandler(object sender, DragStartedEventArgs e);
  public event DragStartedHandler DragStarted {
    add {
      if (!_DragStarted.ContainsKey(swigCPtr.Handle)) {
        _DragStarted.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_Thumb_DragStarted(_raiseDragStarted, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _DragStarted[swigCPtr.Handle] += value;
    }
    remove {
      if (_DragStarted.ContainsKey(swigCPtr.Handle)) {

        _DragStarted[swigCPtr.Handle] -= value;

        if (_DragStarted[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_Thumb_DragStarted(_raiseDragStarted, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _DragStarted.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseDragStartedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseDragStartedCallback _raiseDragStarted = RaiseDragStarted;

  [MonoPInvokeCallback(typeof(RaiseDragStartedCallback))]
  private static void RaiseDragStarted(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_DragStarted.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for DragStarted event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _DragStarted.Remove(cPtr);
        return;
      }
      DragStartedHandler handler = _DragStarted[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new DragStartedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, DragStartedHandler> _DragStarted =
      new System.Collections.Generic.Dictionary<System.IntPtr, DragStartedHandler>();


  public Thumb() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(Thumb).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_Thumb();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public void CancelDrag() {
    NoesisGUI_PINVOKE.Thumb_CancelDrag(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public static DependencyProperty IsDraggingProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Thumb_IsDraggingProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public bool IsDragging {
    get {
      bool ret = NoesisGUI_PINVOKE.Thumb_IsDragging_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Thumb_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }


  internal new static IntPtr Extend(System.Type type) {
    IntPtr unityType = Noesis.Extend.GetPtrForType(type);
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_Thumb(unityType);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

