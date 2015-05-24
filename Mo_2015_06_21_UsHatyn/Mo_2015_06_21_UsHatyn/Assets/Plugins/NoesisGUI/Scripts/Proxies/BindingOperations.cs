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

public static class BindingOperations {
  public static void ClearAllBindings(DependencyObject target) {
    NoesisGUI_PINVOKE.BindingOperations_ClearAllBindings(DependencyObject.getCPtr(target));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public static void ClearBinding(DependencyObject target, DependencyProperty dp) {
    NoesisGUI_PINVOKE.BindingOperations_ClearBinding(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  public static BindingBase GetBindingBase(DependencyObject target, DependencyProperty dp) {
    IntPtr cPtr = NoesisGUI_PINVOKE.BindingOperations_GetBindingBase(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.GetProxy(cPtr, false) as BindingBase;
  }

  public static Binding GetBinding(DependencyObject target, DependencyProperty dp) {
    IntPtr cPtr = NoesisGUI_PINVOKE.BindingOperations_GetBinding(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.GetProxy(cPtr, false) as Binding;
  }

  public static BaseExpression GetBindingExpression(DependencyObject target, DependencyProperty dp) {
    IntPtr cPtr = NoesisGUI_PINVOKE.BindingOperations_GetBindingExpression(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp));
    BaseExpression ret = (cPtr == IntPtr.Zero) ? null : new BaseExpression(cPtr, false);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public static bool IsDataBound(DependencyObject target, DependencyProperty dp) {
    bool ret = NoesisGUI_PINVOKE.BindingOperations_IsDataBound(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public static BaseExpression SetBinding(DependencyObject target, DependencyProperty dp, BindingBase binding) {
    IntPtr cPtr = NoesisGUI_PINVOKE.BindingOperations_SetBinding(DependencyObject.getCPtr(target), DependencyProperty.getCPtr(dp), BindingBase.getCPtr(binding));
    BaseExpression ret = (cPtr == IntPtr.Zero) ? null : new BaseExpression(cPtr, false);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

