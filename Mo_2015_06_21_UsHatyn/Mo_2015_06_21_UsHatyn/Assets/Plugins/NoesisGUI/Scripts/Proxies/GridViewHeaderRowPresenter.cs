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

public class GridViewHeaderRowPresenter : GridViewRowPresenterBase {

  internal GridViewHeaderRowPresenter(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(GridViewHeaderRowPresenter obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  public GridViewHeaderRowPresenter() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    registerExtend = false;
    return NoesisGUI_PINVOKE.new_GridViewHeaderRowPresenter();
  }

  public static DependencyProperty AllowsColumnReorderProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_AllowsColumnReorderProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderContainerStyleProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContainerStyleProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderContextMenuProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContextMenuProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderStringFormatProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderStringFormatProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderTemplateProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplateProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderTemplateSelectorProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplateSelectorProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty ColumnHeaderToolTipProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderToolTipProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public bool AllowsColumnReorder {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_AllowsColumnReorder_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_AllowsColumnReorder_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  public Style ColumnHeaderContainerStyle {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContainerStyle_set(swigCPtr, Style.getCPtr(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContainerStyle_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as Style;
    }
  }

  public ContextMenu ColumnHeaderContextMenu {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContextMenu_set(swigCPtr, ContextMenu.getCPtr(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderContextMenu_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as ContextMenu;
    }
  }

  public string ColumnHeaderStringFormat {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderStringFormat_set(swigCPtr, value != null ? value : string.Empty);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }
    get {
      string ret = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderStringFormat_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    }
  }

  public DataTemplate ColumnHeaderTemplate {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplate_set(swigCPtr, DataTemplate.getCPtr(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplate_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DataTemplate;
    }
  }

  public DataTemplateSelector ColumnHeaderTemplateSelector {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplateSelector_set(swigCPtr, DataTemplateSelector.getCPtr(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderTemplateSelector_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DataTemplateSelector;
    }
  }

  public object ColumnHeaderToolTip {
    set {
      NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderToolTip_set(swigCPtr, Noesis.Extend.GetInstanceHandle(value));
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    }
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_ColumnHeaderToolTip_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.Unbox(Noesis.Extend.GetProxy(cPtr, false));
    }
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.GridViewHeaderRowPresenter_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }

}

}

