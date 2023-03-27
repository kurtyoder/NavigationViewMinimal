# Runtime errors with NavigationView

Here are some bugs that I have encountered with the NavigationView in both v5 and v6.

While not entirely a bug, you can also see that the NavigationView deselects the selected category when you move between tabs.

## Error with any ViewModel with CompileBindings Enabled 

Exception occurs when all Views are using CompileBindings, and user selects an item, moves to Tab Page 1, then back to Tab Page 2 and re-selects an item.

I have only been able to get this exception with the DetailsViewModel, though is hard to test because of the bug related specifically to the SettingsViewModel shown below.
The DetailsViewModel is using WhenActivated to run a loading simulation, and since the SettingsView inherits from _UserControl_ instead of _ReactiveUserControl_ 
WhenActivated isn't triggered for this ViewModel.


``System.InvalidCastException: Unable to cast object of type 'NavigationViewMinimal.Avalonia.ViewModels.TabPage.HasNavigationViewModel' to type 'NavigationViewMinimal.Avalonia.ViewModels.Dashboard.DetailsViewModel'.
at CompiledAvaloniaXaml.XamlIlHelpers.NavigationViewMinimal.Avalonia.ViewModels.Dashboard.DetailsViewModel,NavigationViewMinimal.Avalonia.Details!Getter(Object)
at Avalonia.Data.Core.ClrPropertyInfo.Get(Object target) in /_/src/Avalonia.Base/Data/Core/ClrPropertyInfo.cs:line 27
at Avalonia.Markup.Xaml.MarkupExtensions.CompiledBindings.InpcPropertyAccessor.get_Value() in /_/src/Markup/Avalonia.Markup.Xaml/MarkupExtensions/CompiledBindings/PropertyInfoAccessorFactory.cs:line 88
at Avalonia.Markup.Xaml.MarkupExtensions.CompiledBindings.InpcPropertyAccessor.SendCurrentValue() in /_/src/Markup/Avalonia.Markup.Xaml/MarkupExtensions/CompiledBindings/PropertyInfoAccessorFactory.cs:line 132``

## Error with NavigationView
Spam clicking (4+) an entry in the navigation view and then moving to another tab will crash the app.

``System.NullReferenceException: Object reference not set to an instance of an object.
at FluentAvalonia.UI.Controls.NavigationView.RaiseItemInvoked(Object item, Boolean isSettings, NavigationViewItemBase container, NavigationRecommendedTransitionDirection recDir)
at FluentAvalonia.UI.Controls.NavigationView.ChangeSelection(Object prevItem, Object nextItem)
at FluentAvalonia.UI.Controls.NavigationView.OnSelectedItemPropertyChanged(Object oldItem, Object newItem)
at FluentAvalonia.UI.Controls.NavigationView.OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
at Avalonia.AvaloniaObject.OnPropertyChangedCore(AvaloniaPropertyChangedEventArgs change) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 605
at Avalonia.Animation.Animatable.OnPropertyChangedCore(AvaloniaPropertyChangedEventArgs change) in /_/src/Avalonia.Base/Animation/Animatable.cs:line 182
at Avalonia.AvaloniaObject.RaisePropertyChanged[T](AvaloniaProperty`1 property, Optional`1 oldValue, BindingValue`1 newValue, BindingPriority priority, Boolean isEffectiveValue) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 658
at Avalonia.AvaloniaObject.SetAndRaise[T](AvaloniaProperty`1 property, T& field, T value) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 690
at FluentAvalonia.UI.Controls.NavigationView.set_SelectedItem(Object value)
at FluentAvalonia.UI.Controls.NavigationView.SetSelectedItemAndExpectItemInvokeWhenSelectionChangedIfNotInvokedFromAPI(Object selItem)
at FluentAvalonia.UI.Controls.NavigationView.OnSelectionModelSelectionChanged(Object sender, SelectionModelSelectionChangedEventArgs e)
at FluentAvalonia.UI.Controls.SelectionModel.OnSelectionChanged(SelectionModelSelectionChangedEventArgs e)
at FluentAvalonia.UI.Controls.SelectionModel.OnSelectionInvalidatedDueToCollectionChange(Boolean selectionInvalidated, IReadOnlyList`1 removedItems)
at FluentAvalonia.UI.Controls.SelectionNode.OnSourceListChanged(Object dataSource, NotifyCollectionChangedEventArgs args)
at Avalonia.Controls.ItemsSourceView.Avalonia.Controls.Utils.ICollectionChangedListener.Changed(INotifyCollectionChanged sender, NotifyCollectionChangedEventArgs e) in /_/src/Avalonia.Controls/ItemsSourceView.cs:line 237
at Avalonia.Controls.Utils.CollectionChangedEventManager.Entry.<Avalonia.Utilities.IWeakEventSubscriber<System.Collections.Specialized.NotifyCollectionChangedEventArgs>.OnEvent>g__Notify|6_0(INotifyCollectionChanged incc, NotifyCollectionChangedEventArgs args, WeakReference`1[] listeners) in /_/src/Avalonia.Controls/Utils/CollectionChangedEventManager.cs:line 122
at Avalonia.Controls.Utils.CollectionChangedEventManager.Entry.Avalonia.Utilities.IWeakEventSubscriber<System.Collections.Specialized.NotifyCollectionChangedEventArgs>.OnEvent(Object notifyCollectionChanged, WeakEvent ev, NotifyCollectionChangedEventArgs e) in /_/src/Avalonia.Controls/Utils/CollectionChangedEventManager.cs:line 139
at Avalonia.Utilities.WeakEvent`2.Subscription.OnEvent(Object sender, TEventArgs eventArgs) in /_/src/Avalonia.Base/Utilities/WeakEvent.cs:line 162
at Avalonia.Utilities.WeakEvents.<>c__DisplayClass5_0.<.cctor>b__5(Object _, NotifyCollectionChangedEventArgs e) in /_/src/Avalonia.Base/Utilities/WeakEvents.cs:line 17
at Avalonia.Collections.AvaloniaList`1.set_Item(Int32 index, T value) in /_/src/Avalonia.Base/Collections/AvaloniaList.cs:line 170
at FluentAvalonia.UI.Controls.NavigationView.UpdateRepeaterItemsSource(Boolean forceSelectionModelUpdate)
at FluentAvalonia.UI.Controls.NavigationView.set_MenuItems(IEnumerable value)
at FluentAvalonia.UI.Controls.NavigationView.<>c.<.cctor>b__474_4(NavigationView o, IEnumerable v)
at Avalonia.DirectProperty`2.InvokeSetter(AvaloniaObject instance, BindingValue`1 value) in /_/src/Avalonia.Base/DirectProperty.cs:line 164
at Avalonia.AvaloniaObject.SetDirectValueUnchecked[T](DirectPropertyBase`1 property, BindingValue`1 value) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 725
at Avalonia.PropertyStore.DirectUntypedBindingObserver`1.OnNext(Object value) in /_/src/Avalonia.Base/PropertyStore/DirectUntypedBindingObserver.cs:line 44
at Avalonia.Reactive.LightweightObservableBase`1.PublishNext(T value) in /_/src/Avalonia.Base/Reactive/LightweightObservableBase.cs:line 139
at Avalonia.Data.Core.BindingExpression.InnerListener.OnNext(Object value) in /_/src/Avalonia.Base/Data/Core/BindingExpression.cs:line 368
at Avalonia.Reactive.LightweightObservableBase`1.PublishNext(T value) in /_/src/Avalonia.Base/Reactive/LightweightObservableBase.cs:line 139
at Avalonia.Data.Core.ExpressionObserver.ValueChanged(Object value) in /_/src/Avalonia.Base/Data/Core/ExpressionObserver.cs:line 313
at Avalonia.Data.Core.ExpressionNode.ValueChanged(Object value, Boolean notify) in /_/src/Avalonia.Base/Data/Core/ExpressionNode.cs:line 127
at Avalonia.Data.Core.ExpressionNode.ValueChanged(Object value) in /_/src/Avalonia.Base/Data/Core/ExpressionNode.cs:line 95
at Avalonia.Data.Core.ExpressionNode.StartListening() in /_/src/Avalonia.Base/Data/Core/ExpressionNode.cs:line 139
at Avalonia.Data.Core.ExpressionNode.set_Target(WeakReference`1 value) in /_/src/Avalonia.Base/Data/Core/ExpressionNode.cs:line 43
at Avalonia.Data.Core.ExpressionObserver.<StartRoot>b__33_0(Object x) in /_/src/Avalonia.Base/Data/Core/ExpressionObserver.cs:line 298
at Avalonia.Reactive.AnonymousObserver`1.OnNext(T value) in /_/src/Avalonia.Base/Reactive/AnonymousObserver.cs:line 65
at Avalonia.Reactive.Observable.<>c__DisplayClass2_1`2.<Select>b__1(TSource input) in /_/src/Avalonia.Base/Reactive/Observable.cs:line 43
at Avalonia.Reactive.AnonymousObserver`1.OnNext(T value) in /_/src/Avalonia.Base/Reactive/AnonymousObserver.cs:line 65
at Avalonia.Reactive.SingleSubscriberObservableBase`1.PublishNext(T value) in /_/src/Avalonia.Base/Reactive/SingleSubscriberObservableBase.cs:line 50
at Avalonia.Data.BindingBase.UpdateSignal.PropertyChanged(Object sender, AvaloniaPropertyChangedEventArgs e) in /_/src/Markup/Avalonia.Markup/Data/BindingBase.cs:line 280
at Avalonia.AvaloniaObject.RaisePropertyChanged[T](AvaloniaProperty`1 property, Optional`1 oldValue, BindingValue`1 newValue, BindingPriority priority, Boolean isEffectiveValue) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 663
at Avalonia.PropertyStore.EffectiveValue`1.RaiseInheritedValueChanged(AvaloniaObject owner, AvaloniaProperty property, EffectiveValue oldValue, EffectiveValue newValue) in /_/src/Avalonia.Base/PropertyStore/EffectiveValue`1.cs:line 92
at Avalonia.PropertyStore.ValueStore.InheritedValueChanged(AvaloniaProperty property, EffectiveValue oldValue, EffectiveValue newValue) in /_/src/Avalonia.Base/PropertyStore/ValueStore.cs:line 750
at Avalonia.PropertyStore.ValueStore.InheritedValueChanged(AvaloniaProperty property, EffectiveValue oldValue, EffectiveValue newValue) in /_/src/Avalonia.Base/PropertyStore/ValueStore.cs:line 761
at Avalonia.PropertyStore.ValueStore.InheritedValueChanged(AvaloniaProperty property, EffectiveValue oldValue, EffectiveValue newValue) in /_/src/Avalonia.Base/PropertyStore/ValueStore.cs:line 761
at Avalonia.PropertyStore.ValueStore.SetInheritanceParent(AvaloniaObject newParent) in /_/src/Avalonia.Base/PropertyStore/ValueStore.cs:line 351
at Avalonia.AvaloniaObject.set_InheritanceParent(AvaloniaObject value) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 77
at Avalonia.StyledElement.Avalonia.Controls.ISetLogicalParent.SetParent(ILogical parent) in /_/src/Avalonia.Base/StyledElement.cs:line 492
at Avalonia.StyledElement.ClearLogicalParent(IList children) in /_/src/Avalonia.Base/StyledElement.cs:line 970
at Avalonia.StyledElement.LogicalChildrenCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e) in /_/src/Avalonia.Base/StyledElement.cs:line 563
at Avalonia.Visual.LogicalChildrenCollectionChanged(Object sender, NotifyCollectionChangedEventArgs e) in /_/src/Avalonia.Base/Visual.cs:line 451
at Avalonia.Collections.AvaloniaList`1.NotifyRemove(T item, Int32 index) in /_/src/Avalonia.Base/Collections/AvaloniaList.cs:line 741
at Avalonia.Collections.AvaloniaList`1.Remove(T item) in /_/src/Avalonia.Base/Collections/AvaloniaList.cs:line 495
at Avalonia.Controls.Presenters.ContentPresenter.UpdateChild(Object content) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 457
at Avalonia.Controls.Presenters.ContentPresenter.ContentChanged(AvaloniaPropertyChangedEventArgs e) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 688
at Avalonia.Controls.Presenters.ContentPresenter.OnPropertyChanged(AvaloniaPropertyChangedEventArgs change) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 414
at Avalonia.AvaloniaObject.OnPropertyChangedCore(AvaloniaPropertyChangedEventArgs change) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 605
at Avalonia.Animation.Animatable.OnPropertyChangedCore(AvaloniaPropertyChangedEventArgs change) in /_/src/Avalonia.Base/Animation/Animatable.cs:line 182
at Avalonia.AvaloniaObject.RaisePropertyChanged[T](AvaloniaProperty`1 property, Optional`1 oldValue, BindingValue`1 newValue, BindingPriority priority, Boolean isEffectiveValue) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 658
at Avalonia.PropertyStore.EffectiveValue`1.SetAndRaiseCore(ValueStore owner, StyledProperty`1 property, T value, BindingPriority priority) in /_/src/Avalonia.Base/PropertyStore/EffectiveValue`1.cs:line 194
at Avalonia.PropertyStore.EffectiveValue`1.SetLocalValueAndRaise(ValueStore owner, StyledProperty`1 property, T value) in /_/src/Avalonia.Base/PropertyStore/EffectiveValue`1.cs:line 68
at Avalonia.PropertyStore.ValueStore.SetValue[T](StyledProperty`1 property, T value, BindingPriority priority) in /_/src/Avalonia.Base/PropertyStore/ValueStore.cs:line 198
at Avalonia.AvaloniaObject.SetValue[T](StyledProperty`1 property, T value, BindingPriority priority) in /_/src/Avalonia.Base/AvaloniaObject.cs:line 329
at Avalonia.Controls.Presenters.ContentPresenter.set_Content(Object value) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 345
at FluentAvalonia.UI.Controls.TabView.UpdateTabContent()
at FluentAvalonia.UI.Controls.TabView.OnListViewSelectionChanged(Object sender, SelectionChangedEventArgs args)
at Avalonia.Interactivity.Interactive.<AddHandler>g__InvokeAdapter|4_0[TEventArgs](Delegate baseHandler, Object sender, RoutedEventArgs args) in /_/src/Avalonia.Base/Interactivity/Interactive.cs:line 64
at Avalonia.Interactivity.Interactive.<>c__4`1.<AddHandler>b__4_1(Delegate baseHandler, Object sender, RoutedEventArgs args) in /_/src/Avalonia.Base/Interactivity/Interactive.cs:line 70
at Avalonia.Interactivity.EventRoute.RaiseEventImpl(RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/EventRoute.cs:line 164
at Avalonia.Interactivity.EventRoute.RaiseEvent(Interactive source, RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/EventRoute.cs:line 101
at Avalonia.Interactivity.Interactive.RaiseEvent(RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/Interactive.cs:line 125
at Avalonia.Controls.Primitives.SelectingItemsControl.OnSelectionModelSelectionChanged(Object sender, SelectionModelSelectionChangedEventArgs e) in /_/src/Avalonia.Controls/Primitives/SelectingItemsControl.cs:line 856
at Avalonia.Controls.Selection.SelectionModel`1.CommitOperation(Operation operation, Boolean raisePropertyChanged) in /_/src/Avalonia.Controls/Selection/SelectionModel.cs:line 702
at Avalonia.Controls.Selection.SelectionModel`1.EndBatchUpdate() in /_/src/Avalonia.Controls/Selection/SelectionModel.cs:line 211
at Avalonia.Controls.Selection.SelectionModelExtensions.BatchUpdateOperation.Dispose() in /_/src/Avalonia.Controls/Selection/ISelectionModel.cs:line 58
at Avalonia.Controls.Primitives.SelectingItemsControl.UpdateSelection(Int32 index, Boolean select, Boolean rangeModifier, Boolean toggleModifier, Boolean rightButton, Boolean fromFocus) in /_/src/Avalonia.Controls/Primitives/SelectingItemsControl.cs:line 716
at Avalonia.Controls.Primitives.SelectingItemsControl.UpdateSelection(Control container, Boolean select, Boolean rangeModifier, Boolean toggleModifier, Boolean rightButton, Boolean fromFocus) in /_/src/Avalonia.Controls/Primitives/SelectingItemsControl.cs:line 749
at Avalonia.Controls.Primitives.SelectingItemsControl.UpdateSelectionFromEventSource(Object eventSource, Boolean select, Boolean rangeModifier, Boolean toggleModifier, Boolean rightButton, Boolean fromFocus) in /_/src/Avalonia.Controls/Primitives/SelectingItemsControl.cs:line 779
at Avalonia.Controls.ListBox.OnPointerPressed(PointerPressedEventArgs e) in /_/src/Avalonia.Controls/ListBox.cs:line 135
at Avalonia.Input.InputElement.<>c.<.cctor>b__32_8(InputElement x, PointerPressedEventArgs e) in /_/src/Avalonia.Base/Input/InputElement.cs:line 224
at Avalonia.Interactivity.RoutedEvent`1.<>c__DisplayClass1_0`1.<AddClassHandler>g__Adapter|0(Object sender, RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/RoutedEvent.cs:line 125
at Avalonia.Interactivity.RoutedEvent.<>c__DisplayClass23_0.<AddClassHandler>b__0(ValueTuple`2 args) in /_/src/Avalonia.Base/Interactivity/RoutedEvent.cs:line 92
at Avalonia.Reactive.AnonymousObserver`1.OnNext(T value) in /_/src/Avalonia.Base/Reactive/AnonymousObserver.cs:line 65
at Avalonia.Reactive.LightweightObservableBase`1.PublishNext(T value) in /_/src/Avalonia.Base/Reactive/LightweightObservableBase.cs:line 143
at Avalonia.Reactive.LightweightSubject`1.OnNext(T value) in /_/src/Avalonia.Base/Reactive/LightweightSubject.cs:line 24
at Avalonia.Interactivity.RoutedEvent.InvokeRaised(Object sender, RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/RoutedEvent.cs:line 99
at Avalonia.Interactivity.EventRoute.RaiseEventImpl(RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/EventRoute.cs:line 146
at Avalonia.Interactivity.EventRoute.RaiseEvent(Interactive source, RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/EventRoute.cs:line 101
at Avalonia.Interactivity.Interactive.RaiseEvent(RoutedEventArgs e) in /_/src/Avalonia.Base/Interactivity/Interactive.cs:line 125
at Avalonia.Input.MouseDevice.MouseDown(IMouseDevice device, UInt64 timestamp, IInputElement root, Point p, PointerPointProperties properties, KeyModifiers inputModifiers, IInputElement hitTest) in /_/src/Avalonia.Base/Input/MouseDevice.cs:line 143
at Avalonia.Input.MouseDevice.ProcessRawEvent(RawPointerEventArgs e) in /_/src/Avalonia.Base/Input/MouseDevice.cs:line 74
at Avalonia.Input.MouseDevice.ProcessRawEvent(RawInputEventArgs e) in /_/src/Avalonia.Base/Input/MouseDevice.cs:line 31
at Avalonia.Input.InputManager.ProcessInput(RawInputEventArgs e) in /_/src/Avalonia.Base/Input/InputManager.cs:line 35
at Avalonia.Controls.TopLevel.HandleInput(RawInputEventArgs e) in /_/src/Avalonia.Controls/TopLevel.cs:line 632
at Avalonia.Win32.WindowImpl.AppWndProc(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam) in /_/src/Windows/Avalonia.Win32/WindowImpl.AppWndProc.cs:line 750
at Avalonia.Win32.WindowImpl.WndProc(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam) in /_/src/Windows/Avalonia.Win32/WindowImpl.WndProc.cs:line 30
at Avalonia.Win32.Interop.UnmanagedMethods.DispatchMessage(MSG& lpmsg)
at Avalonia.Win32.Win32Platform.RunLoop(CancellationToken cancellationToken) in /_/src/Windows/Avalonia.Win32/Win32Platform.cs:line 204
at Avalonia.Threading.Dispatcher.MainLoop(CancellationToken cancellationToken) in /_/src/Avalonia.Base/Threading/Dispatcher.cs:line 61
at Avalonia.Controls.ApplicationLifetimes.ClassicDesktopStyleApplicationLifetime.Start(String[] args) in /_/src/Avalonia.Controls/ApplicationLifetimes/ClassicDesktopStyleApplicationLifetime.cs:line 120
at Avalonia.ClassicDesktopStyleApplicationLifetimeExtensions.StartWithClassicDesktopLifetime(AppBuilder builder, String[] args, ShutdownMode shutdownMode) in /_/src/Avalonia.Controls/ApplicationLifetimes/ClassicDesktopStyleApplicationLifetime.cs:line 212
at NavigationViewMinimal.Avalonia.Program.Main(String[] args) in [Directory]\NavigationViewMinimal\NavigationViewMinimal.Avalonia\Program.cs:line 13``

## Error with SettingsViewModel

This occurs whether CompileBindings is on or off. Though it is easier to fire with them on (I think).

Simply select the settings from the navigation view, navigate to Tab Page 1 and the exception will be thrown
when Tab Page 2 is selected. Sometimes you have to spam back and forth, and sometimes it happens right away.

``System.InvalidOperationException: Nullable object must have a value.
at System.Nullable`1.get_Value()
at Avalonia.Layout.WrapLayoutState.GetHeight() in /_/src/Avalonia.Controls.ItemsRepeater/Layout/WrapLayoutState.cs:line 129
at Avalonia.Layout.WrapLayout.MeasureOverride(VirtualizingLayoutContext context, Size availableSize) in /_/src/Avalonia.Controls.ItemsRepeater/Layout/WrapLayout.cs:line 248
at Avalonia.Layout.AttachedLayout.Measure(LayoutContext context, Size availableSize) in /_/src/Avalonia.Controls.ItemsRepeater/Layout/AttachedLayout.cs:line 130
at Avalonia.Controls.ItemsRepeater.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls.ItemsRepeater/Controls/ItemsRepeater.cs:line 339
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.LayoutHelper.MeasureChild(Layoutable control, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 47
at Avalonia.Controls.Presenters.ContentPresenter.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 594
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.LayoutHelper.MeasureChild(Layoutable control, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 47
at Avalonia.Controls.Presenters.ContentPresenter.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 594
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Controls.Grid.MeasureCell(Int32 cell, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 1151
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV, Boolean& hasDesiredSizeUChanged) in /_/src/Avalonia.Controls/Grid.cs:line 1006
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 969
at Avalonia.Controls.Grid.MeasureOverride(Size constraint) in /_/src/Avalonia.Controls/Grid.cs:line 490
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.LayoutHelper.MeasureChild(Layoutable control, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 47
at Avalonia.Controls.Border.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls/Border.cs:line 241
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.LayoutHelper.MeasureChild(Layoutable control, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 47
at Avalonia.Controls.Presenters.ContentPresenter.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 594
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Controls.Grid.MeasureCell(Int32 cell, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 1151
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV, Boolean& hasDesiredSizeUChanged) in /_/src/Avalonia.Controls/Grid.cs:line 1006
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 969
at Avalonia.Controls.Grid.MeasureOverride(Size constraint) in /_/src/Avalonia.Controls/Grid.cs:line 490
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Controls.Grid.MeasureCell(Int32 cell, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 1151
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV, Boolean& hasDesiredSizeUChanged) in /_/src/Avalonia.Controls/Grid.cs:line 1006
at Avalonia.Controls.Grid.MeasureCellsGroup(Int32 cellsHead, Size referenceSize, Boolean ignoreDesiredSizeU, Boolean forceInfinityV) in /_/src/Avalonia.Controls/Grid.cs:line 969
at Avalonia.Controls.Grid.MeasureOverride(Size constraint) in /_/src/Avalonia.Controls/Grid.cs:line 490
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at FluentAvalonia.UI.Controls.NavigationView.MeasureOverride(Size availableSize)
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.LayoutHelper.MeasureChild(Layoutable control, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 47
at Avalonia.Controls.Presenters.ContentPresenter.MeasureOverride(Size availableSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 594
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.MeasureOverride(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 596
at Avalonia.Layout.Layoutable.MeasureCore(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 529
at Avalonia.Layout.Layoutable.Measure(Size availableSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 361
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 398
at Avalonia.Controls.Presenters.ContentPresenter.ArrangeOverrideImpl(Size finalSize, Vector offset) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 671
at Avalonia.Controls.Presenters.ContentPresenter.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 600
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.LayoutHelper.ArrangeChildInternal(Layoutable child, Size availableSize, Thickness padding) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 91
at Avalonia.Layout.LayoutHelper.ArrangeChild(Layoutable child, Size availableSize, Thickness padding, Thickness borderThickness) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 78
at Avalonia.Controls.Border.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Border.cs:line 251
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.Layoutable.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 709
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Controls.Presenters.ContentPresenter.ArrangeOverrideImpl(Size finalSize, Vector offset) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 671
at Avalonia.Controls.Presenters.ContentPresenter.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Presenters/ContentPresenter.cs:line 600
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.LayoutHelper.ArrangeChildInternal(Layoutable child, Size availableSize, Thickness padding) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 91
at Avalonia.Layout.LayoutHelper.ArrangeChild(Layoutable child, Size availableSize, Thickness padding) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 86
at Avalonia.Controls.Decorator.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Decorator.cs:line 60
at Avalonia.Controls.Primitives.VisualLayerManager.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Primitives/VisualLayerManager.cs:line 140
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.Layoutable.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 709
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.LayoutHelper.ArrangeChildInternal(Layoutable child, Size availableSize, Thickness padding) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 91
at Avalonia.Layout.LayoutHelper.ArrangeChild(Layoutable child, Size availableSize, Thickness padding) in /_/src/Avalonia.Base/Layout/LayoutHelper.cs:line 86
at Avalonia.Controls.Decorator.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/Decorator.cs:line 60
at Avalonia.Controls.LayoutTransformControl.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Controls/LayoutTransformControl.cs:line 67
at Avalonia.Layout.Layoutable.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 657
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.Layoutable.ArrangeOverride(Size finalSize) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 709
at Avalonia.Controls.WindowBase.ArrangeCore(Rect finalRect) in /_/src/Avalonia.Controls/WindowBase.cs:line 258
at Avalonia.Layout.Layoutable.Arrange(Rect rect) in /_/src/Avalonia.Base/Layout/Layoutable.cs:line 406
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 311
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.Arrange(Layoutable control) in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 303
at Avalonia.Layout.LayoutManager.ExecuteArrangePass() in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 267
at Avalonia.Layout.LayoutManager.InnerLayoutPass() in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 237
at Avalonia.Layout.LayoutManager.ExecuteLayoutPass() in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 148
at Avalonia.Layout.LayoutManager.ExecuteQueuedLayoutPass() in /_/src/Avalonia.Base/Layout/LayoutManager.cs:line 108
at Avalonia.Threading.JobRunner.Job.Avalonia.Threading.JobRunner.IJob.Run() in /_/src/Avalonia.Base/Threading/JobRunner.cs:line 193
at Avalonia.Threading.JobRunner.RunJobs(Nullable`1 priority) in /_/src/Avalonia.Base/Threading/JobRunner.cs:line 38
at Avalonia.Win32.Win32Platform.WndProc(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam) in /_/src/Windows/Avalonia.Win32/Win32Platform.cs:line 257
at Avalonia.Win32.Interop.UnmanagedMethods.DispatchMessage(MSG& lpmsg)
at Avalonia.Win32.Win32Platform.RunLoop(CancellationToken cancellationToken) in /_/src/Windows/Avalonia.Win32/Win32Platform.cs:line 204
at Avalonia.Threading.Dispatcher.MainLoop(CancellationToken cancellationToken) in /_/src/Avalonia.Base/Threading/Dispatcher.cs:line 61
at Avalonia.Controls.ApplicationLifetimes.ClassicDesktopStyleApplicationLifetime.Start(String[] args) in /_/src/Avalonia.Controls/ApplicationLifetimes/ClassicDesktopStyleApplicationLifetime.cs:line 120
at Avalonia.ClassicDesktopStyleApplicationLifetimeExtensions.StartWithClassicDesktopLifetime(AppBuilder builder, String[] args, ShutdownMode shutdownMode) in /_/src/Avalonia.Controls/ApplicationLifetimes/ClassicDesktopStyleApplicationLifetime.cs:line 212
at NavigationViewMinimal.Avalonia.Program.Main(String[] args) in [Directory]\NavigationViewMinimal\NavigationViewMinimal.``Avalonia\Program.cs:line 13