﻿#pragma checksum "..\..\..\UserCtrl\ucSetting.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "63455BDB82CEAAB380B7DD0D67314C14698541C487CDCA1A7B2D1CC4DA6E4F24"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EW12SG.UserCtrl;
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


namespace EW12SG.UserCtrl {
    
    
    /// <summary>
    /// ucSetting
    /// </summary>
    public partial class ucSetting : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 126 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbFactory;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbLine;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbStationName;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbbStationNumber;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox rtb_maccode;
        
        #line default
        #line hidden
        
        
        #line 208 "..\..\..\UserCtrl\ucSetting.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbb_product_name;
        
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
            System.Uri resourceLocater = new System.Uri("/EW12SG;component/userctrl/ucsetting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserCtrl\ucSetting.xaml"
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
            case 3:
            this.cbbFactory = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbbLine = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbbStationName = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.cbbStationNumber = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.rtb_maccode = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 8:
            
            #line 176 "..\..\..\UserCtrl\ucSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.cbb_product_name = ((System.Windows.Controls.ComboBox)(target));
            
            #line 209 "..\..\..\UserCtrl\ucSetting.xaml"
            this.cbb_product_name.DropDownOpened += new System.EventHandler(this.Cbb_product_name_DropDownOpened);
            
            #line default
            #line hidden
            
            #line 210 "..\..\..\UserCtrl\ucSetting.xaml"
            this.cbb_product_name.DropDownClosed += new System.EventHandler(this.Cbb_product_name_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 278 "..\..\..\UserCtrl\ucSetting.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            System.Windows.EventSetter eventSetter;
            switch (connectionId)
            {
            case 1:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.UIElement.PreviewMouseWheelEvent;
            
            #line 79 "..\..\..\UserCtrl\ucSetting.xaml"
            eventSetter.Handler = new System.Windows.Input.MouseWheelEventHandler(this.ComboBox_PreviewMouseWheel);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            case 2:
            eventSetter = new System.Windows.EventSetter();
            eventSetter.Event = System.Windows.Controls.Primitives.ButtonBase.ClickEvent;
            
            #line 88 "..\..\..\UserCtrl\ucSetting.xaml"
            eventSetter.Handler = new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            ((System.Windows.Style)(target)).Setters.Add(eventSetter);
            break;
            }
        }
    }
}
