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

public class RectAnimation : BaseAnimation {

  internal RectAnimation(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.RectAnimation_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(RectAnimation obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public RectAnimation() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_RectAnimation();
  }

  public static DependencyProperty ByProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RectAnimation_ByProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty FromProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RectAnimation_FromProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ToProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.RectAnimation_ToProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public System.Nullable<Rect> From {
    set {
      NullableRect tempvalue = value;
      NoesisGUI_PINVOKE.RectAnimation_From_set(swigCPtr, ref tempvalue);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.RectAnimation_From_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableRect>(ret);
      }
      else {
        return new System.Nullable<Rect>();
      }
    }

  }

  public System.Nullable<Rect> To {
    set {
      NullableRect tempvalue = value;
      NoesisGUI_PINVOKE.RectAnimation_To_set(swigCPtr, ref tempvalue);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.RectAnimation_To_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableRect>(ret);
      }
      else {
        return new System.Nullable<Rect>();
      }
    }

  }

  public System.Nullable<Rect> By {
    set {
      NullableRect tempvalue = value;
      NoesisGUI_PINVOKE.RectAnimation_By_set(swigCPtr, ref tempvalue);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.RectAnimation_By_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<NullableRect>(ret);
      }
      else {
        return new System.Nullable<Rect>();
      }
    }

  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.RectAnimation_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

