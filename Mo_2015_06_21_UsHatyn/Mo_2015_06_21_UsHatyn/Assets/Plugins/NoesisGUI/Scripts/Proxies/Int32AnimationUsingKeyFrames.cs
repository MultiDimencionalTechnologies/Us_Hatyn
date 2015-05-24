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

public class Int32AnimationUsingKeyFrames : AnimationTimeline {

  internal Int32AnimationUsingKeyFrames(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.Int32AnimationUsingKeyFrames_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(Int32AnimationUsingKeyFrames obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public Int32AnimationUsingKeyFrames() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_Int32AnimationUsingKeyFrames();
  }

  public Int32KeyFrameCollection KeyFrames {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.Int32AnimationUsingKeyFrames_KeyFrames_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as Int32KeyFrameCollection;
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.Int32AnimationUsingKeyFrames_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

