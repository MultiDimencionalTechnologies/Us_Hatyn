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

public class BooleanKeyFrame : Freezable {

  internal BooleanKeyFrame(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.BooleanKeyFrame_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(BooleanKeyFrame obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected BooleanKeyFrame() {
  }

  public static DependencyProperty KeyTimeProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.BooleanKeyFrame_KeyTimeProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ValueProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.BooleanKeyFrame_ValueProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public KeyTime KeyTime {
    set {
      NoesisGUI_PINVOKE.BooleanKeyFrame_KeyTime_set(swigCPtr, ref value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.BooleanKeyFrame_KeyTime_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<KeyTime>(ret);
      }
      else {
        return new KeyTime();
      }
    }

  }

  public bool Value {
    set {
      NoesisGUI_PINVOKE.BooleanKeyFrame_Value_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.BooleanKeyFrame_Value_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.BooleanKeyFrame_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

