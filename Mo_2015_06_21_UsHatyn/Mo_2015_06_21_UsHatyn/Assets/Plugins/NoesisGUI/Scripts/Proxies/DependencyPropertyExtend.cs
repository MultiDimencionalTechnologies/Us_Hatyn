using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Noesis
{

    public partial class DependencyProperty
    {
        internal Type EnumType { get; private set; }

        public static DependencyProperty Register(string propertyName, System.Type propertyType,
            System.Type ownerType, PropertyMetadata propertyMetadata)
        {
            // Force native type registration, but skip DP registration because we are inside
            // static constructor and DP are already being registered
            Noesis.Extend.EnsureNativeType(ownerType, false);

            IntPtr ownerTypePtr = Noesis.Extend.GetPtrForType(ownerType);
            IntPtr propertyNamePtr = new Noesis.Extend.StringMarshal(propertyName);
            DependencyProperty dependencyProperty = null;
            if ((object)propertyType.TypeHandle == typeof(bool).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(bool));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Bool_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(float).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(float));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Float_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(int).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(int));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Int_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(uint).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(uint));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_UInt_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(short).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(short));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Short_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(ushort).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(ushort));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_UShort_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(string).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(default(string));
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_String_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.Color).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.Color());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Color_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.Point).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.Point());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Point_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.Rect).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.Rect());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Rect_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.Size).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.Size());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Size_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.Thickness).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.Thickness());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_Thickness_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if ((object)propertyType.TypeHandle == typeof(Noesis.CornerRadius).TypeHandle)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(new Noesis.CornerRadius());
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_CornerRadius_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }
            else if (propertyType.GetTypeInfo().IsEnum)
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    string val = Enum.GetName(propertyType, 0);
                    propertyMetadata = new PropertyMetadata(val != null ? val : string.Empty);
                }
                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_String_(ownerTypePtr,
                    propertyNamePtr, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
                dependencyProperty.EnumType = propertyType;
            }
            else
            {
                if (propertyMetadata == null || !propertyMetadata.HasDefaultValue)
                {
                    propertyMetadata = new PropertyMetadata(null);
                }

                IntPtr nativeType = Noesis.Extend.EnsureNativeType(propertyType);

                IntPtr dependencyPtr = Noesis_RegisterDependencyProperty_BaseComponent_(ownerTypePtr,
                    propertyNamePtr, nativeType, PropertyMetadata.getCPtr(propertyMetadata).Handle);
                dependencyProperty = new DependencyProperty(dependencyPtr, false);
            }

            RegisterCalled = true;
            return dependencyProperty;
        }

        public static DependencyProperty RegisterAttached(string propertyName, System.Type propertyType,
            System.Type ownerType, PropertyMetadata propertyMetadata)
        {
            return Register(propertyName, propertyType, ownerType, propertyMetadata);
        }

        public void OverrideMetadata(System.Type forType, PropertyMetadata propertyMetadata)
        {
            Noesis_OverrideMetadata_(Noesis.Extend.GetPtrForType(forType), swigCPtr.Handle,
                PropertyMetadata.getCPtr(propertyMetadata).Handle);
        }

        internal static bool RegisterCalled;

        #region Imports
        private static IntPtr Noesis_RegisterDependencyProperty_Bool_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Bool(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Float_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Float(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Int_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Int(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_UInt_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_UInt(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Short_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Short(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_UShort_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_UShort(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_String_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_String(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Color_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Color(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Point_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Point(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Rect_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Rect(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Size_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Size(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_Thickness_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_Thickness(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_CornerRadius_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_CornerRadius(classType, propertyName, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static IntPtr Noesis_RegisterDependencyProperty_BaseComponent_(IntPtr classType,
            IntPtr propertyName, IntPtr propertyType, IntPtr propertyMetadata)
        {
            IntPtr result = Noesis_RegisterDependencyProperty_BaseComponent(classType, propertyName, propertyType, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
            return result;
        }

        private static void Noesis_OverrideMetadata_(IntPtr classType, IntPtr dependencyProperty,
            IntPtr propertyMetadata)
        {
            Noesis_OverrideMetadata(classType, dependencyProperty, propertyMetadata);
            #if UNITY_EDITOR || NOESIS_API
            Error.Check();
            #endif
        }

    #if UNITY_EDITOR

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static void RegisterFunctions(Library lib)
        {
            // register DependencyProperty
            _RegisterDependencyProperty_Bool = lib.Find<RegisterDependencyPropertyDelegate_Bool>(
                "Noesis_RegisterDependencyProperty_Bool");
            _RegisterDependencyProperty_Float = lib.Find<RegisterDependencyPropertyDelegate_Float>(
                "Noesis_RegisterDependencyProperty_Float");
            _RegisterDependencyProperty_Int = lib.Find<RegisterDependencyPropertyDelegate_Int>(
                "Noesis_RegisterDependencyProperty_Int");
            _RegisterDependencyProperty_UInt = lib.Find<RegisterDependencyPropertyDelegate_UInt>(
                "Noesis_RegisterDependencyProperty_UInt");
            _RegisterDependencyProperty_Short = lib.Find<RegisterDependencyPropertyDelegate_Short>(
                "Noesis_RegisterDependencyProperty_Short");
            _RegisterDependencyProperty_UShort = lib.Find<RegisterDependencyPropertyDelegate_UShort>(
                "Noesis_RegisterDependencyProperty_UShort");
            _RegisterDependencyProperty_String = lib.Find<RegisterDependencyPropertyDelegate_String>(
                "Noesis_RegisterDependencyProperty_String");
            _RegisterDependencyProperty_Color = lib.Find<RegisterDependencyPropertyDelegate_Color>(
                "Noesis_RegisterDependencyProperty_Color");
            _RegisterDependencyProperty_Point = lib.Find<RegisterDependencyPropertyDelegate_Point>(
                "Noesis_RegisterDependencyProperty_Point");
            _RegisterDependencyProperty_Rect = lib.Find<RegisterDependencyPropertyDelegate_Rect>(
                "Noesis_RegisterDependencyProperty_Rect");
            _RegisterDependencyProperty_Size = lib.Find<RegisterDependencyPropertyDelegate_Size>(
                "Noesis_RegisterDependencyProperty_Size");
            _RegisterDependencyProperty_Thickness = lib.Find<RegisterDependencyPropertyDelegate_Thickness>(
                "Noesis_RegisterDependencyProperty_Thickness");
            _RegisterDependencyProperty_CornerRadius = lib.Find<RegisterDependencyPropertyDelegate_CornerRadius>(
                "Noesis_RegisterDependencyProperty_CornerRadius");
            _RegisterDependencyProperty_BaseComponent = lib.Find<RegisterDependencyPropertyDelegate_BaseComponent>(
                "Noesis_RegisterDependencyProperty_BaseComponent");

            // override PropertyMetadata 
            _OverrideMetadata = lib.Find<OverrideMetadataDelegate>("Noesis_OverrideMetadata");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        public static void UnregisterFunctions()
        {
            // register DependencyProperty
            _RegisterDependencyProperty_Bool = null;
            _RegisterDependencyProperty_Float = null;
            _RegisterDependencyProperty_Int = null;
            _RegisterDependencyProperty_UInt = null;
            _RegisterDependencyProperty_Short = null;
            _RegisterDependencyProperty_UShort = null;
            _RegisterDependencyProperty_String = null;
            _RegisterDependencyProperty_Color = null;
            _RegisterDependencyProperty_Point = null;
            _RegisterDependencyProperty_Rect = null;
            _RegisterDependencyProperty_Size = null;
            _RegisterDependencyProperty_Thickness = null;
            _RegisterDependencyProperty_CornerRadius = null;
            _RegisterDependencyProperty_BaseComponent = null;
            _OverrideMetadata = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Bool(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Bool _RegisterDependencyProperty_Bool;
        private static IntPtr Noesis_RegisterDependencyProperty_Bool(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Bool(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Float(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Float _RegisterDependencyProperty_Float;
        private static IntPtr Noesis_RegisterDependencyProperty_Float(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Float(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Int(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Int _RegisterDependencyProperty_Int;
        private static IntPtr Noesis_RegisterDependencyProperty_Int(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Int(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_UInt(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_UInt _RegisterDependencyProperty_UInt;
        private static IntPtr Noesis_RegisterDependencyProperty_UInt(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_UInt(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Short(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Short _RegisterDependencyProperty_Short;
        private static IntPtr Noesis_RegisterDependencyProperty_Short(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Short(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_UShort(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_UShort _RegisterDependencyProperty_UShort;
        private static IntPtr Noesis_RegisterDependencyProperty_UShort(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_UShort(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_String(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_String _RegisterDependencyProperty_String;
        private static IntPtr Noesis_RegisterDependencyProperty_String(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_String(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Color(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Color _RegisterDependencyProperty_Color;
        private static IntPtr Noesis_RegisterDependencyProperty_Color(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Color(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Point(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Point _RegisterDependencyProperty_Point;
        private static IntPtr Noesis_RegisterDependencyProperty_Point(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Point(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Rect(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Rect _RegisterDependencyProperty_Rect;
        private static IntPtr Noesis_RegisterDependencyProperty_Rect(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Rect(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Size(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Size _RegisterDependencyProperty_Size;
        private static IntPtr Noesis_RegisterDependencyProperty_Size(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Size(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_Thickness(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_Thickness _RegisterDependencyProperty_Thickness;
        private static IntPtr Noesis_RegisterDependencyProperty_Thickness(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_Thickness(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_CornerRadius(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_CornerRadius _RegisterDependencyProperty_CornerRadius;
        private static IntPtr Noesis_RegisterDependencyProperty_CornerRadius(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_CornerRadius(classType, propertyName, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate IntPtr RegisterDependencyPropertyDelegate_BaseComponent(IntPtr classType,
            IntPtr propertyName, IntPtr propertyType, IntPtr propertyMetadata);
        static RegisterDependencyPropertyDelegate_BaseComponent _RegisterDependencyProperty_BaseComponent;
        private static IntPtr Noesis_RegisterDependencyProperty_BaseComponent(IntPtr classType,
            IntPtr propertyName, IntPtr propertyType, IntPtr propertyMetadata)
        {
            return _RegisterDependencyProperty_BaseComponent(classType, propertyName, propertyType, propertyMetadata);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////
        delegate void OverrideMetadataDelegate(IntPtr classType, IntPtr dependencyProperty,
            IntPtr propertyMetadata);
        static OverrideMetadataDelegate _OverrideMetadata;
        private static void Noesis_OverrideMetadata(IntPtr classType, IntPtr dependencyProperty,
            IntPtr propertyMetadata)
        {
            _OverrideMetadata(classType, dependencyProperty, propertyMetadata);
        }

    #else

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Bool")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Bool")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Bool(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Float")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Float")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Float(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Int")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Int")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Int(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_UInt")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_UInt")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_UInt(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Short")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Short")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Short(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_UShort")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_UShort")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_UShort(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_String")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_String")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_String(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Color")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Color")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Color(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Point")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Point")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Point(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Rect")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Rect")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Rect(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Size")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Size")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Size(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_Thickness")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_Thickness")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_Thickness(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_CornerRadius")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_CornerRadius")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_CornerRadius(IntPtr classType,
            IntPtr propertyName, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_RegisterDependencyProperty_BaseComponent")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_RegisterDependencyProperty_BaseComponent")]
        #endif
        private static extern IntPtr Noesis_RegisterDependencyProperty_BaseComponent(IntPtr classType,
            IntPtr propertyName, IntPtr propertyType, IntPtr propertyMetadata);

        ////////////////////////////////////////////////////////////////////////////////////////////////
        #if UNITY_IPHONE || UNITY_XBOX360
        [DllImport("__Internal", EntryPoint="Noesis_OverrideMetadata")]
        #else
        [DllImport("Noesis", EntryPoint = "Noesis_OverrideMetadata")]
        #endif
        private static extern void Noesis_OverrideMetadata(IntPtr classType,
            IntPtr dependencyProperty, IntPtr propertyMetadata);

    #endif
        #endregion
    }

}
