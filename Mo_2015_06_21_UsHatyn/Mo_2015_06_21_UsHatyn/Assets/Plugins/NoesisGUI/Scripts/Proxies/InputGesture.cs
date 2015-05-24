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

public class InputGesture : BaseComponent {

  internal InputGesture(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.InputGesture_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(InputGesture obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected InputGesture() {
  }

  public virtual bool Matches(object target, RoutedEventArgs args) {
    bool ret = NoesisGUI_PINVOKE.InputGesture_Matches(swigCPtr, Noesis.Extend.GetInstanceHandle(target), RoutedEventArgs.getCPtr(args));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.InputGesture_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

