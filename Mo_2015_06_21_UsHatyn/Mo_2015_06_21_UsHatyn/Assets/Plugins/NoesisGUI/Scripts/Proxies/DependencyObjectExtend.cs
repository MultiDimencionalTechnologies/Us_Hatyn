using System;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections.Generic;

namespace Noesis
{

    public partial class DependencyObject
    {
        private delegate object GetDelegate(IntPtr cPtr, DependencyProperty dp);
        private static Dictionary<Type, GetDelegate> _getFunctions = CreateGetFunctions();

        private static Dictionary<Type, GetDelegate> CreateGetFunctions()
        {
            Dictionary<Type, GetDelegate> getFunctions = new Dictionary<Type, GetDelegate>();

            getFunctions[typeof(bool)] = (cPtr, dp) => Noesis_DependencyGet_Bool_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(float)] = (cPtr, dp) => Noesis_DependencyGet_Float_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(int)] = (cPtr, dp) => Noesis_DependencyGet_Int_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(uint)] = (cPtr, dp) => Noesis_DependencyGet_UInt_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(short)] = (cPtr, dp) => Noesis_DependencyGet_Short_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(ushort)] = (cPtr, dp) => Noesis_DependencyGet_UShort_(cPtr, DependencyProperty.getCPtr(dp).Handle);
            getFunctions[typeof(string)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_String_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                string value = Marshal.PtrToStringAnsi(ptr);
                if (dp.EnumType != null)
                {
                    return Noesis.Extend.ParseEnum(dp.EnumType, value, dp.OwnerType.Name, dp.Name);
                }
                return value;
            };
            getFunctions[typeof(Noesis.Color)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_Color_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.Color>(ptr);
            };
            getFunctions[typeof(Noesis.Point)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_Point_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.Point>(ptr);
            };
            getFunctions[typeof(Noesis.Rect)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_Rect_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.Rect>(ptr);
            };
            getFunctions[typeof(Noesis.Size)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_Size_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.Size>(ptr);
            };
            getFunctions[typeof(Noesis.Thickness)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_Thickness_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.Thickness>(ptr);
            };
            getFunctions[typeof(Noesis.CornerRadius)] = (cPtr, dp) =>
            {
                IntPtr ptr = Noesis_DependencyGet_CornerRadius_(cPtr, DependencyProperty.getCPtr(dp).Handle);
                return Marshal.PtrToStructure<Noesis.CornerRadius>(ptr);
            };

            return getFunctions;
        }

        public object GetValue(DependencyProperty dp)
        {
            if (dp == null)
            {
                throw new Exception("Can't get value, DependencyProperty is null");
            }

            GetDelegate getDelegate;
            if (_getFunctions.TryGetValue(dp.PropertyType, out getDelegate))
            {
                return getDelegate(swigCPtr.Handle, dp);
            }
            else
            {
                return Noesis.Extend.GetProxy(Noesis_DependencyGet_BaseComponent_(
                    swigCPtr.Handle, DependencyProperty.getCPtr(dp).Handle), false);
            }
        }

        private delegate void SetDelegate(IntPtr cPtr, IntPtr dp, object value);
        private static Dictionary<Type, SetDelegate> _setFunctions = CreateSetFunctions();

        private static Dictionary<Type, SetDelegate> CreateSetFunctions()
        {
            Dictionary<Type, SetDelegate> setFunctions = new Dictionary<Type, SetDelegate>();

            setFunctions[typeof(bool)] = (cPtr, dp, value) => Noesis_DependencySet_Bool_(cPtr, dp, (bool)value);
            setFunctions[typeof(float)] = (cPtr, dp, value) => Noesis_DependencySet_Float_(cPtr, dp, (float)value);
            setFunctions[typeof(int)] = (cPtr, dp, value) => Noesis_DependencySet_Int_(cPtr, dp, (int)value);
            setFunctions[typeof(uint)] = (cPtr, dp, value) => Noesis_DependencySet_UInt_(cPtr, dp, (uint)value);
            setFunctions[typeof(short)] = (cPtr, dp, value) => Noesis_DependencySet_Short_(cPtr, dp, (short)value);
            setFunctions[typeof(ushort)] = (cPtr, dp, value) => Noesis_DependencySet_UShort_(cPtr, dp, (ushort)value);
            setFunctions[typeof(string)] = (cPtr, dp, value) => Noesis_DependencySet_String_(cPtr, dp, value.ToString());
            setFunctions[typeof(Noesis.Color)] = (cPtr, dp, value) => Noesis_DependencySet_Color_(cPtr, dp, (Noesis.Color)value);
            setFunctions[typeof(Noesis.Point)] = (cPtr, dp, value) => Noesis_DependencySet_Point_(cPtr, dp, (Noesis.Point)value);
            setFunctions[typeof(Noesis.Rect)] = (cPtr, dp, value) => Noesis_DependencySet_Rect_(cPtr, dp, (Noesis.Rect)value);
            setFunctions[typeof(Noesis.Size)] = (cPtr, dp, value) => Noesis_DependencySet_Size_(cPtr, dp, (Noesis.Size)value);
            setFunctions[typeof(Noesis.Thickness)] = (cPtr, dp, value) => Noesis_DependencySet_Thickness_(cPtr, dp, (Noesis.Thickness)value);
            setFunctions[typeof(Noesis.CornerRadius)] = (cPtr, dp, value) => Noesis_DependencySet_CornerRadius_(cPtr, dp, (Noesis.CornerRadius)value);

            return setFunctions;
        }

        public void SetValue(DependencyProperty dp, object value)
        {
            if (dp == null)
            {
                throw new Exception("Can't get value, DependencyProperty is null");
            }

            SetDelegate setDelegate;
            if (_setFunctions.TryGetValue(dp.PropertyType, out setDelegate))
            {
                setDelegate(swigCPtr.Handle, DependencyProperty.getCPtr(dp).Handle, value);
            }
            else
            {
                Noesis_DependencySet_BaseComponent_(swigCPtr.Handle, DependencyProperty.getCPtr(dp).Handle,
                    Noesis.Extend.GetInstanceHandle(value).Handle);
            }
        }

        #region Imports
        ////////////////////////////////////////////////////////////////////////////////////////////////
        private static void CheckProperty(IntPtr dependencyObject, IntPtr dependencyProperty, string msg)
        {
            if (dependencyObject == IntPtr.Zero)
            {
                throw new Exception("Can't " + msg + " value, DependencyObject is null");
            }

            if (dependencyProperty == IntPtr.Zero)
            {
                throw new Exception("Can't " + msg + " value, DependencyProperty is null");
            }
        }

        private static bool Noesis_DependencyGet_Bool_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            bool result = Noesis_DependencyGet_Bool(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static float Noesis_DependencyGet_Float_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            float result = Noesis_DependencyGet_Float(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static int Noesis_DependencyGet_Int_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            int result = Noesis_DependencyGet_Int(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static uint Noesis_DependencyGet_UInt_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            uint result = Noesis_DependencyGet_UInt(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static short Noesis_DependencyGet_Short_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            short result = Noesis_DependencyGet_Short(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static ushort Noesis_DependencyGet_UShort_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            ushort result = Noesis_DependencyGet_UShort(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_String_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_String(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_Color_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_Color(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_Point_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_Point(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_Rect_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_Rect(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_Size_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_Size(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_Thickness_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_Thickness(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_CornerRadius_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_CornerRadius(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_DependencyGet_BaseComponent_(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            CheckProperty(dependencyObject, dependencyProperty, "get");
            IntPtr result = Noesis_DependencyGet_BaseComponent(dependencyObject, dependencyProperty);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static void Noesis_DependencySet_Bool_(IntPtr dependencyObject, IntPtr dependencyProperty, bool val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Bool(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Float_(IntPtr dependencyObject, IntPtr dependencyProperty, float val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Float(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Int_(IntPtr dependencyObject, IntPtr dependencyProperty, int val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Int(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_UInt_(IntPtr dependencyObject, IntPtr dependencyProperty, uint val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_UInt(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Short_(IntPtr dependencyObject, IntPtr dependencyProperty, short val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Short(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_UShort_(IntPtr dependencyObject, IntPtr dependencyProperty, ushort val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_UShort(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_String_(IntPtr dependencyObject, IntPtr dependencyProperty, string val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_String(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Color_(IntPtr dependencyObject, IntPtr dependencyProperty,
            Color val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Color(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Point_(IntPtr dependencyObject, IntPtr dependencyProperty,
            Point val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Point(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Rect_(IntPtr dependencyObject, IntPtr dependencyProperty,
            Rect val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Rect(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Size_(IntPtr dependencyObject, IntPtr dependencyProperty,
            Size val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Size(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_Thickness_(IntPtr dependencyObject, IntPtr dependencyProperty,
            Thickness val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_Thickness(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_CornerRadius_(IntPtr dependencyObject, IntPtr dependencyProperty,
            CornerRadius val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_CornerRadius(dependencyObject, dependencyProperty, ref val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

        private static void Noesis_DependencySet_BaseComponent_(IntPtr dependencyObject, IntPtr dependencyProperty,
            IntPtr val)
        {
            CheckProperty(dependencyObject, dependencyProperty, "set");
            Noesis_DependencySet_BaseComponent(dependencyObject, dependencyProperty, val);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

    #if UNITY_EDITOR

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static void RegisterFunctions(Library lib)
        {
            // DependencyObject Get/Set
            _DependencyGet_Bool = lib.Find<DependencyGet_BoolDelegate>(
                "Noesis_DependencyGet_Bool");
            _DependencyGet_Float = lib.Find<DependencyGet_FloatDelegate>(
                "Noesis_DependencyGet_Float");
            _DependencyGet_Int = lib.Find<DependencyGet_IntDelegate>(
                "Noesis_DependencyGet_Int");
            _DependencyGet_UInt = lib.Find<DependencyGet_UIntDelegate>(
                "Noesis_DependencyGet_UInt");
            _DependencyGet_Short = lib.Find<DependencyGet_ShortDelegate>(
                "Noesis_DependencyGet_Short");
            _DependencyGet_UShort = lib.Find<DependencyGet_UShortDelegate>(
                "Noesis_DependencyGet_UShort");
            _DependencyGet_String = lib.Find<DependencyGet_StringDelegate>(
                "Noesis_DependencyGet_String");
            _DependencyGet_Color = lib.Find<DependencyGet_ColorDelegate>(
                "Noesis_DependencyGet_Color");
            _DependencyGet_Point = lib.Find<DependencyGet_PointDelegate>(
                "Noesis_DependencyGet_Point");
            _DependencyGet_Rect = lib.Find<DependencyGet_RectDelegate>(
                "Noesis_DependencyGet_Rect");
            _DependencyGet_Size = lib.Find<DependencyGet_SizeDelegate>(
                "Noesis_DependencyGet_Size");
            _DependencyGet_Thickness = lib.Find<DependencyGet_ThicknessDelegate>(
                "Noesis_DependencyGet_Thickness");
            _DependencyGet_CornerRadius = lib.Find<DependencyGet_CornerRadiusDelegate>(
                "Noesis_DependencyGet_CornerRadius");
            _DependencyGet_BaseComponent = lib.Find<DependencyGet_BaseComponentDelegate>(
                "Noesis_DependencyGet_BaseComponent");

            _DependencySet_Bool = lib.Find<DependencySet_BoolDelegate>(
                "Noesis_DependencySet_Bool");
            _DependencySet_Float = lib.Find<DependencySet_FloatDelegate>(
                "Noesis_DependencySet_Float");
            _DependencySet_Int = lib.Find<DependencySet_IntDelegate>(
                "Noesis_DependencySet_Int");
            _DependencySet_UInt = lib.Find<DependencySet_UIntDelegate>(
                "Noesis_DependencySet_UInt");
            _DependencySet_Short = lib.Find<DependencySet_ShortDelegate>(
                "Noesis_DependencySet_Short");
            _DependencySet_UShort = lib.Find<DependencySet_UShortDelegate>(
                "Noesis_DependencySet_UShort");
            _DependencySet_String = lib.Find<DependencySet_StringDelegate>(
                "Noesis_DependencySet_String");
            _DependencySet_Color = lib.Find<DependencySet_ColorDelegate>(
                "Noesis_DependencySet_Color");
            _DependencySet_Point = lib.Find<DependencySet_PointDelegate>(
                "Noesis_DependencySet_Point");
            _DependencySet_Rect = lib.Find<DependencySet_RectDelegate>(
                "Noesis_DependencySet_Rect");
            _DependencySet_Size = lib.Find<DependencySet_SizeDelegate>(
                "Noesis_DependencySet_Size");
            _DependencySet_Thickness = lib.Find<DependencySet_ThicknessDelegate>(
                "Noesis_DependencySet_Thickness");
            _DependencySet_CornerRadius = lib.Find<DependencySet_CornerRadiusDelegate>(
                "Noesis_DependencySet_CornerRadius");
            _DependencySet_BaseComponent = lib.Find<DependencySet_BaseComponentDelegate>(
                "Noesis_DependencySet_BaseComponent");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static void UnregisterFunctions()
        {
            // DependencyObject Get/Set
            _DependencyGet_Bool = null;
            _DependencyGet_Float = null;
            _DependencyGet_Int = null;
            _DependencyGet_UInt = null;
            _DependencyGet_Short = null;
            _DependencyGet_UShort = null;
            _DependencyGet_String = null;
            _DependencyGet_Color = null;
            _DependencyGet_Point = null;
            _DependencyGet_Rect = null;
            _DependencyGet_Size = null;
            _DependencyGet_Thickness = null;
            _DependencyGet_CornerRadius = null;
            _DependencyGet_BaseComponent = null;

            _DependencySet_Bool = null;
            _DependencySet_Float = null;
            _DependencySet_Int = null;
            _DependencySet_UInt = null;
            _DependencySet_Short = null;
            _DependencySet_UShort = null;
            _DependencySet_String = null;
            _DependencySet_Color = null;
            _DependencySet_Point = null;
            _DependencySet_Rect = null;
            _DependencySet_Size = null;
            _DependencySet_Thickness = null;
            _DependencySet_CornerRadius = null;
            _DependencySet_BaseComponent = null;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////
        [return: MarshalAs(UnmanagedType.U1)]
        delegate bool DependencyGet_BoolDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_BoolDelegate _DependencyGet_Bool;
        private static bool Noesis_DependencyGet_Bool(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Bool(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate float DependencyGet_FloatDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_FloatDelegate _DependencyGet_Float;
        private static float Noesis_DependencyGet_Float(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Float(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate int DependencyGet_IntDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_IntDelegate _DependencyGet_Int;
        private static int Noesis_DependencyGet_Int(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Int(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate uint DependencyGet_UIntDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_UIntDelegate _DependencyGet_UInt;
        private static uint Noesis_DependencyGet_UInt(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_UInt(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate short DependencyGet_ShortDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_ShortDelegate _DependencyGet_Short;
        private static short Noesis_DependencyGet_Short(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Short(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate ushort DependencyGet_UShortDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_UShortDelegate _DependencyGet_UShort;
        private static ushort Noesis_DependencyGet_UShort(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_UShort(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_StringDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_StringDelegate _DependencyGet_String;
        private static IntPtr Noesis_DependencyGet_String(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_String(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_ColorDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_ColorDelegate _DependencyGet_Color;
        private static IntPtr Noesis_DependencyGet_Color(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Color(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_PointDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_PointDelegate _DependencyGet_Point;
        private static IntPtr Noesis_DependencyGet_Point(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Point(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_RectDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_RectDelegate _DependencyGet_Rect;
        private static IntPtr Noesis_DependencyGet_Rect(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Rect(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_SizeDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_SizeDelegate _DependencyGet_Size;
        private static IntPtr Noesis_DependencyGet_Size(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Size(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_ThicknessDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_ThicknessDelegate _DependencyGet_Thickness;
        private static IntPtr Noesis_DependencyGet_Thickness(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_Thickness(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_CornerRadiusDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_CornerRadiusDelegate _DependencyGet_CornerRadius;
        private static IntPtr Noesis_DependencyGet_CornerRadius(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_CornerRadius(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr DependencyGet_BaseComponentDelegate(IntPtr dependencyObject, IntPtr dependencyProperty);
        static DependencyGet_BaseComponentDelegate _DependencyGet_BaseComponent;
        private static IntPtr Noesis_DependencyGet_BaseComponent(IntPtr dependencyObject, IntPtr dependencyProperty)
        {
            return _DependencyGet_BaseComponent(dependencyObject, dependencyProperty);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_BoolDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            [MarshalAs(UnmanagedType.U1)] bool val);
        static DependencySet_BoolDelegate _DependencySet_Bool;
        private static void Noesis_DependencySet_Bool(IntPtr dependencyObject, IntPtr dependencyProperty, bool val)
        {
            _DependencySet_Bool(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_FloatDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, float val);
        static DependencySet_FloatDelegate _DependencySet_Float;
        private static void Noesis_DependencySet_Float(IntPtr dependencyObject, IntPtr dependencyProperty, float val)
        {
            _DependencySet_Float(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_IntDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, int val);
        static DependencySet_IntDelegate _DependencySet_Int;
        private static void Noesis_DependencySet_Int(IntPtr dependencyObject, IntPtr dependencyProperty, int val)
        {
            _DependencySet_Int(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_UIntDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, uint val);
        static DependencySet_UIntDelegate _DependencySet_UInt;
        private static void Noesis_DependencySet_UInt(IntPtr dependencyObject, IntPtr dependencyProperty, uint val)
        {
            _DependencySet_UInt(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_ShortDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, short val);
        static DependencySet_ShortDelegate _DependencySet_Short;
        private static void Noesis_DependencySet_Short(IntPtr dependencyObject, IntPtr dependencyProperty, short val)
        {
            _DependencySet_Short(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_UShortDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, ushort val);
        static DependencySet_UShortDelegate _DependencySet_UShort;
        private static void Noesis_DependencySet_UShort(IntPtr dependencyObject, IntPtr dependencyProperty, ushort val)
        {
            _DependencySet_UShort(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_StringDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, string val);
        static DependencySet_StringDelegate _DependencySet_String;
        private static void Noesis_DependencySet_String(IntPtr dependencyObject, IntPtr dependencyProperty, string val)
        {
            _DependencySet_String(dependencyObject, dependencyProperty, val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_ColorDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Color val);
        static DependencySet_ColorDelegate _DependencySet_Color;
        private static void Noesis_DependencySet_Color(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Color val)
        {
            _DependencySet_Color(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_PointDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Point val);
        static DependencySet_PointDelegate _DependencySet_Point;
        private static void Noesis_DependencySet_Point(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Point val)
        {
            _DependencySet_Point(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_RectDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Rect val);
        static DependencySet_RectDelegate _DependencySet_Rect;
        private static void Noesis_DependencySet_Rect(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Rect val)
        {
            _DependencySet_Rect(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_SizeDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Size val);
        static DependencySet_SizeDelegate _DependencySet_Size;
        private static void Noesis_DependencySet_Size(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Size val)
        {
            _DependencySet_Size(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_ThicknessDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Thickness val);
        static DependencySet_ThicknessDelegate _DependencySet_Thickness;
        private static void Noesis_DependencySet_Thickness(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref Thickness val)
        {
            _DependencySet_Thickness(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_CornerRadiusDelegate(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref CornerRadius val);
        static DependencySet_CornerRadiusDelegate _DependencySet_CornerRadius;
        private static void Noesis_DependencySet_CornerRadius(IntPtr dependencyObject, IntPtr dependencyProperty,
            ref CornerRadius val)
        {
            _DependencySet_CornerRadius(dependencyObject, dependencyProperty, ref val);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void DependencySet_BaseComponentDelegate(IntPtr dependencyObject, IntPtr dependencyProperty, IntPtr val);
        static DependencySet_BaseComponentDelegate _DependencySet_BaseComponent;
        private static void Noesis_DependencySet_BaseComponent(IntPtr dependencyObject, IntPtr dependencyProperty,
            IntPtr val)
        {
            _DependencySet_BaseComponent(dependencyObject, dependencyProperty, val);
        }

    #else

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Bool")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Bool")]
        #endif
        [return: MarshalAs(UnmanagedType.U1)]
        private static extern bool Noesis_DependencyGet_Bool(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Float")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Float")]
        #endif
        private static extern float Noesis_DependencyGet_Float(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Int")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Int")]
        #endif
        private static extern int Noesis_DependencyGet_Int(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_UInt")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_UInt")]
        #endif
        private static extern uint Noesis_DependencyGet_UInt(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Short")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Short")]
        #endif
        private static extern short Noesis_DependencyGet_Short(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_UShort")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_UShort")]
        #endif
        private static extern ushort Noesis_DependencyGet_UShort(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_String")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_String")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_String(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Color")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Color")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_Color(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Point")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Point")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_Point(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Rect")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Rect")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_Rect(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Size")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Size")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_Size(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_Thickness")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_Thickness")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_Thickness(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_CornerRadius")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_CornerRadius")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_CornerRadius(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencyGet_BaseComponent")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencyGet_BaseComponent")]
        #endif
        private static extern IntPtr Noesis_DependencyGet_BaseComponent(IntPtr dependencyObject,
            IntPtr dependencyProperty);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Bool")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Bool")]
        #endif
        private static extern void Noesis_DependencySet_Bool(IntPtr dependencyObject,
            IntPtr dependencyProperty, [MarshalAs(UnmanagedType.U1)] bool val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Float")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Float")]
        #endif
        private static extern void Noesis_DependencySet_Float(IntPtr dependencyObject,
            IntPtr dependencyProperty, float val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Int")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Int")]
        #endif
        private static extern void Noesis_DependencySet_Int(IntPtr dependencyObject,
            IntPtr dependencyProperty, int val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_UInt")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_UInt")]
        #endif
        private static extern void Noesis_DependencySet_UInt(IntPtr dependencyObject,
            IntPtr dependencyProperty, uint val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Short")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Short")]
        #endif
        private static extern void Noesis_DependencySet_Short(IntPtr dependencyObject,
            IntPtr dependencyProperty, short val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_UShort")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_UShort")]
        #endif
        private static extern void Noesis_DependencySet_UShort(IntPtr dependencyObject,
            IntPtr dependencyProperty, ushort val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_String")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_String")]
        #endif
        private static extern void Noesis_DependencySet_String(IntPtr dependencyObject,
            IntPtr dependencyProperty, string val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Color")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Color")]
        #endif
        private static extern void Noesis_DependencySet_Color(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref Color val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Point")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Point")]
        #endif
        private static extern void Noesis_DependencySet_Point(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref Point val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Rect")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Rect")]
        #endif
        private static extern void Noesis_DependencySet_Rect(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref Rect val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Size")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Size")]
        #endif
        private static extern void Noesis_DependencySet_Size(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref Size val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_Thickness")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_Thickness")]
        #endif
        private static extern void Noesis_DependencySet_Thickness(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref Thickness val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_CornerRadius")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_CornerRadius")]
        #endif
        private static extern void Noesis_DependencySet_CornerRadius(IntPtr dependencyObject,
            IntPtr dependencyProperty, ref CornerRadius val);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_DependencySet_BaseComponent")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_DependencySet_BaseComponent")]
        #endif
        private static extern void Noesis_DependencySet_BaseComponent(IntPtr dependencyObject,
            IntPtr dependencyProperty, IntPtr val);

    #endif
        #endregion
    }

}
