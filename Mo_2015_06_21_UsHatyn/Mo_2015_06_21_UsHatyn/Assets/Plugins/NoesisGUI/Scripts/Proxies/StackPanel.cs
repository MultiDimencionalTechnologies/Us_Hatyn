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

public class StackPanel : Panel {

  internal StackPanel(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.StackPanel_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(StackPanel obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public StackPanel() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(StackPanel).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_StackPanel();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public static DependencyProperty OrientationProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.StackPanel_OrientationProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public Orientation Orientation {
    set {
      NoesisGUI_PINVOKE.StackPanel_Orientation_set(swigCPtr, (int)value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      Orientation ret = (Orientation)NoesisGUI_PINVOKE.StackPanel_Orientation_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.StackPanel_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }


  internal new static IntPtr Extend(System.Type type) {
    IntPtr unityType = Noesis.Extend.GetPtrForType(type);
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_StackPanel(unityType);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

