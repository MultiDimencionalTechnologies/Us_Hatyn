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

public class Visual : DependencyObject {

  internal Visual(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.Visual_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Visual obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected Visual() {
  }

  public bool IsAncestorOf(Visual visual) {
    bool ret = NoesisGUI_PINVOKE.Visual_IsAncestorOf(swigCPtr, Visual.getCPtr(visual));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public bool IsDescendantOf(Visual visual) {
    bool ret = NoesisGUI_PINVOKE.Visual_IsDescendantOf(swigCPtr, Visual.getCPtr(visual));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public Visual FindCommonVisualAncestor(Visual visual) {
    IntPtr cPtr = NoesisGUI_PINVOKE.Visual_FindCommonVisualAncestor(swigCPtr, Visual.getCPtr(visual));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return Noesis.Extend.GetProxy(cPtr, false) as Visual;
  }

  public Point PointFromScreen(Point point) {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_PointFromScreen(swigCPtr, ref point);
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

  public Point PointToScreen(Point point) {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_PointToScreen(swigCPtr, ref point);
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

  public Matrix4 TransformToAncestor(Visual ancestor) {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_TransformToAncestor(swigCPtr, Visual.getCPtr(ancestor));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Matrix4>(ret);
    }
    else {
      return new Matrix4();
    }
  }

  public Matrix4 TransformToDescendant(Visual descendant) {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_TransformToDescendant(swigCPtr, Visual.getCPtr(descendant));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Matrix4>(ret);
    }
    else {
      return new Matrix4();
    }
  }

  public Matrix4 TransformToVisual(Visual visual) {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_TransformToVisual(swigCPtr, Visual.getCPtr(visual));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Matrix4>(ret);
    }
    else {
      return new Matrix4();
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Visual_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }


  internal new static IntPtr Extend(System.Type type) {
    IntPtr unityType = Noesis.Extend.GetPtrForType(type);
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_Visual(unityType);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

