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

public class AnimationTimeline : Timeline {

  internal AnimationTimeline(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.AnimationTimeline_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(AnimationTimeline obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected AnimationTimeline() {
  }

  public static DependencyProperty IsAdditiveProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.AnimationTimeline_IsAdditiveProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty IsCumulativeProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.AnimationTimeline_IsCumulativeProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public bool IsAdditive {
    set {
      NoesisGUI_PINVOKE.AnimationTimeline_IsAdditive_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.AnimationTimeline_IsAdditive_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  public bool IsCumulative {
    set {
      NoesisGUI_PINVOKE.AnimationTimeline_IsCumulative_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.AnimationTimeline_IsCumulative_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  public object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock) {
    IntPtr cPtr = NoesisGUI_PINVOKE.AnimationTimeline_GetCurrentValue(swigCPtr, Noesis.Extend.GetInstanceHandle(defaultOriginValue), Noesis.Extend.GetInstanceHandle(defaultDestinationValue), AnimationClock.getCPtr(animationClock));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.Unbox(Noesis.Extend.GetProxy(cPtr, false));
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.AnimationTimeline_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

