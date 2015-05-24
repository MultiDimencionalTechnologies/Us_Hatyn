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

public class TreeViewItem : HeaderedItemsControl {

  internal TreeViewItem(IntPtr cPtr, bool cMemoryOwn) : base(NoesisGUI_PINVOKE.TreeViewItem_SWIGUpcast(cPtr), cMemoryOwn) {
  }

  internal static HandleRef getCPtr(TreeViewItem obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }


  public delegate void CollapsedHandler(object sender, RoutedEventArgs e);
  public event CollapsedHandler Collapsed {
    add {
      if (!_Collapsed.ContainsKey(swigCPtr.Handle)) {
        _Collapsed.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_TreeViewItem_Collapsed(_raiseCollapsed, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _Collapsed[swigCPtr.Handle] += value;
    }
    remove {
      if (_Collapsed.ContainsKey(swigCPtr.Handle)) {

        _Collapsed[swigCPtr.Handle] -= value;

        if (_Collapsed[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_TreeViewItem_Collapsed(_raiseCollapsed, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _Collapsed.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseCollapsedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseCollapsedCallback _raiseCollapsed = RaiseCollapsed;

  [MonoPInvokeCallback(typeof(RaiseCollapsedCallback))]
  private static void RaiseCollapsed(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Collapsed.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for Collapsed event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _Collapsed.Remove(cPtr);
        return;
      }
      CollapsedHandler handler = _Collapsed[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new RoutedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, CollapsedHandler> _Collapsed =
      new System.Collections.Generic.Dictionary<System.IntPtr, CollapsedHandler>();


  public delegate void ExpandedHandler(object sender, RoutedEventArgs e);
  public event ExpandedHandler Expanded {
    add {
      if (!_Expanded.ContainsKey(swigCPtr.Handle)) {
        _Expanded.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_TreeViewItem_Expanded(_raiseExpanded, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _Expanded[swigCPtr.Handle] += value;
    }
    remove {
      if (_Expanded.ContainsKey(swigCPtr.Handle)) {

        _Expanded[swigCPtr.Handle] -= value;

        if (_Expanded[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_TreeViewItem_Expanded(_raiseExpanded, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _Expanded.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseExpandedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseExpandedCallback _raiseExpanded = RaiseExpanded;

  [MonoPInvokeCallback(typeof(RaiseExpandedCallback))]
  private static void RaiseExpanded(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Expanded.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for Expanded event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _Expanded.Remove(cPtr);
        return;
      }
      ExpandedHandler handler = _Expanded[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new RoutedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, ExpandedHandler> _Expanded =
      new System.Collections.Generic.Dictionary<System.IntPtr, ExpandedHandler>();


  public delegate void SelectedHandler(object sender, RoutedEventArgs e);
  public event SelectedHandler Selected {
    add {
      if (!_Selected.ContainsKey(swigCPtr.Handle)) {
        _Selected.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_TreeViewItem_Selected(_raiseSelected, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _Selected[swigCPtr.Handle] += value;
    }
    remove {
      if (_Selected.ContainsKey(swigCPtr.Handle)) {

        _Selected[swigCPtr.Handle] -= value;

        if (_Selected[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_TreeViewItem_Selected(_raiseSelected, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _Selected.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseSelectedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseSelectedCallback _raiseSelected = RaiseSelected;

  [MonoPInvokeCallback(typeof(RaiseSelectedCallback))]
  private static void RaiseSelected(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Selected.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for Selected event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _Selected.Remove(cPtr);
        return;
      }
      SelectedHandler handler = _Selected[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new RoutedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, SelectedHandler> _Selected =
      new System.Collections.Generic.Dictionary<System.IntPtr, SelectedHandler>();


  public delegate void UnselectedHandler(object sender, RoutedEventArgs e);
  public event UnselectedHandler Unselected {
    add {
      if (!_Unselected.ContainsKey(swigCPtr.Handle)) {
        _Unselected.Add(swigCPtr.Handle, null);

        NoesisGUI_PINVOKE.BindEvent_TreeViewItem_Unselected(_raiseUnselected, swigCPtr.Handle);
        #if UNITY_EDITOR || NOESIS_API
        if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
        #endif
      }

      _Unselected[swigCPtr.Handle] += value;
    }
    remove {
      if (_Unselected.ContainsKey(swigCPtr.Handle)) {

        _Unselected[swigCPtr.Handle] -= value;

        if (_Unselected[swigCPtr.Handle] == null) {
          NoesisGUI_PINVOKE.UnbindEvent_TreeViewItem_Unselected(_raiseUnselected, swigCPtr.Handle);
          #if UNITY_EDITOR || NOESIS_API
          if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
          #endif

          _Unselected.Remove(swigCPtr.Handle);
        }
      }
    }
  }

  internal delegate void RaiseUnselectedCallback(IntPtr cPtr, IntPtr sender, IntPtr e);
  private static RaiseUnselectedCallback _raiseUnselected = RaiseUnselected;

  [MonoPInvokeCallback(typeof(RaiseUnselectedCallback))]
  private static void RaiseUnselected(IntPtr cPtr, IntPtr sender, IntPtr e) {
    try {
      if (!_Unselected.ContainsKey(cPtr)) {
        throw new System.InvalidOperationException("Delegate not registered for Unselected event");
      }
      if (sender == System.IntPtr.Zero && e == System.IntPtr.Zero) {
        _Unselected.Remove(cPtr);
        return;
      }
      UnselectedHandler handler = _Unselected[cPtr];
      if (handler != null) {
        handler(Noesis.Extend.Unbox(Noesis.Extend.GetProxy(sender, false)), new RoutedEventArgs(e, false));
      }
    }
    catch (System.Exception exception) {
      Noesis.Error.SetNativePendingError(exception);
    }
  }

  static System.Collections.Generic.Dictionary<System.IntPtr, UnselectedHandler> _Unselected =
      new System.Collections.Generic.Dictionary<System.IntPtr, UnselectedHandler>();


  public TreeViewItem() {
  }

  protected override System.IntPtr CreateCPtr(System.Type type, out bool registerExtend) {
    if ((object)type.TypeHandle == typeof(TreeViewItem).TypeHandle) {
      registerExtend = false;
      return NoesisGUI_PINVOKE.new_TreeViewItem();
    }
    else {
      return base.CreateExtendCPtr(type, out registerExtend);
    }
  }

  public static DependencyProperty IsExpandedProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TreeViewItem_IsExpandedProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty IsSelectedProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TreeViewItem_IsSelectedProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public static DependencyProperty IsSelectionActiveProperty {
    get {
      IntPtr cPtr = NoesisGUI_PINVOKE.TreeViewItem_IsSelectionActiveProperty_get();
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return Noesis.Extend.GetProxy(cPtr, false) as DependencyProperty;
    }
  }

  public bool IsExpanded {
    set {
      NoesisGUI_PINVOKE.TreeViewItem_IsExpanded_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.TreeViewItem_IsExpanded_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  public bool IsSelected {
    set {
      NoesisGUI_PINVOKE.TreeViewItem_IsSelected_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.TreeViewItem_IsSelected_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  public bool IsSelectionActive {
    set {
      NoesisGUI_PINVOKE.TreeViewItem_IsSelectionActive_set(swigCPtr, value);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
    } 
    get {
      bool ret = NoesisGUI_PINVOKE.TreeViewItem_IsSelectionActive_get(swigCPtr);
      #if UNITY_EDITOR || NOESIS_API
      if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
      #endif
      return ret;
    } 
  }

  new internal static IntPtr GetStaticType() {
    IntPtr ret = NoesisGUI_PINVOKE.TreeViewItem_GetStaticType();
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return ret;
  }


  internal new static IntPtr Extend(System.Type type) {
    IntPtr unityType = Noesis.Extend.GetPtrForType(type);
    IntPtr nativeType = NoesisGUI_PINVOKE.Extend_TreeViewItem(unityType);
    #if UNITY_EDITOR || NOESIS_API
    if (NoesisGUI_PINVOKE.SWIGPendingException.Pending) throw NoesisGUI_PINVOKE.SWIGPendingException.Retrieve();
    #endif
    return nativeType;
  }
}

}

