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

public class LinearGradientBrush : GradientBrush {

  internal LinearGradientBrush(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.LinearGradientBrush_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(LinearGradientBrush obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public LinearGradientBrush() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_LinearGradientBrush();
  }

  public static DependencyProperty EndPointProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.LinearGradientBrush_EndPointProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty StartPointProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.LinearGradientBrush_StartPointProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public Point StartPoint {
    set {
      NoesisGUI_PINVOKE.LinearGradientBrush_StartPoint_set(swigCPtr, ref value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.LinearGradientBrush_StartPoint_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

  public Point EndPoint {
    set {
      NoesisGUI_PINVOKE.LinearGradientBrush_EndPoint_set(swigCPtr, ref value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }

    get {
      IntPtr ret = NoesisGUI_PINVOKE.LinearGradientBrush_EndPoint_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      if (ret != IntPtr.Zero) {
        return Marshal.PtrToStructure<Point>(ret);
      }
      else {
        return new Point();
      }
    }

  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.LinearGradientBrush_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

