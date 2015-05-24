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

public class Geometry : Animatable {

  internal Geometry(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.Geometry_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Geometry obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  protected Geometry() {
  }

  public Rect Bounds {
    get {
      Rect bounds;
      GetGeometryBounds(out bounds);
      return bounds;
    }
  }

  public virtual bool IsEmpty() {
    bool ret = NoesisGUI_PINVOKE.Geometry_IsEmpty(swigCPtr);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public Rect GetRenderBounds(Pen pen) {
    IntPtr ret = NoesisGUI_PINVOKE.Geometry_GetRenderBounds(swigCPtr, Pen.getCPtr(pen));
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    if (ret != IntPtr.Zero) {
      return Marshal.PtrToStructure<Rect>(ret);
    }
    else {
      return new Rect();
    }
  }

  public bool FillContains(Point point) {
    bool ret = NoesisGUI_PINVOKE.Geometry_FillContains(swigCPtr, ref point);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public bool StrokeContains(Pen pen, Point point) {
    bool ret = NoesisGUI_PINVOKE.Geometry_StrokeContains(swigCPtr, Pen.getCPtr(pen), ref point);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

  public static DependencyProperty TransformProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Geometry_TransformProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public Transform Transform {
    set {
      NoesisGUI_PINVOKE.Geometry_Transform_set(swigCPtr, Transform.getCPtr(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Geometry_Transform_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as Transform;
    }
  }

  private void GetGeometryBounds(out Rect bounds) {
    NoesisGUI_PINVOKE.Geometry_GetGeometryBounds(swigCPtr, out bounds);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Geometry_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

