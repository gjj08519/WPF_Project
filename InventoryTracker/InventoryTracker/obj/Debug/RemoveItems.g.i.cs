﻿#pragma checksum "..\..\RemoveItems.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9BB5E38202C56F7285264743E76B2B35DCF3857A97ADFC3ED4D9CFC5E6C772EA"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using InventoryTracker;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace InventoryTracker {
    
    
    /// <summary>
    /// RemoveItems
    /// </summary>
    public partial class RemoveItems : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbItemsRemove;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Quantity;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock MinQuantity;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Location;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock supplier;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock category;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\RemoveItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemove;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/InventoryTracker;component/removeitems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RemoveItems.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cmbItemsRemove = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\RemoveItems.xaml"
            this.cmbItemsRemove.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CmbItemsRemove_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Quantity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.MinQuantity = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Location = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.supplier = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.category = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnRemove = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\RemoveItems.xaml"
            this.btnRemove.Click += new System.Windows.RoutedEventHandler(this.BtnRemove_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
