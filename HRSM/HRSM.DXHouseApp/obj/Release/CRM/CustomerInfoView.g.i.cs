﻿#pragma checksum "..\..\..\CRM\CustomerInfoView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B5F8E4247B714E95A939532F7F03DF030E7AE297972CD7B6B7B92E78701A7AF7"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.LayoutControl;
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


namespace HRSM.DXHouseApp.CRM {
    
    
    /// <summary>
    /// CustomerInfoView
    /// </summary>
    public partial class CustomerInfoView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HRSM.DXHouseApp.CRM.CustomerInfoView ucCustomerInfo;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtCustomerName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtContactor;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtPhone;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnPersonal;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbtnUnit;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtAddress;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.ComboBoxEdit cboCustStates;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtCreateTime;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Editors.TextEdit txtRemark;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton btnAdd;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\CRM\CustomerInfoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton btnClose;
        
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
            System.Uri resourceLocater = new System.Uri("/HRSM.DXHouseApp;component/crm/customerinfoview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CRM\CustomerInfoView.xaml"
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
            this.ucCustomerInfo = ((HRSM.DXHouseApp.CRM.CustomerInfoView)(target));
            
            #line 10 "..\..\..\CRM\CustomerInfoView.xaml"
            this.ucCustomerInfo.Loaded += new System.Windows.RoutedEventHandler(this.UcCustomerInfo_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtCustomerName = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 3:
            this.txtContactor = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 4:
            this.txtPhone = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 5:
            this.rbtnPersonal = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbtnUnit = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.txtAddress = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 8:
            this.cboCustStates = ((DevExpress.Xpf.Editors.ComboBoxEdit)(target));
            return;
            case 9:
            this.txtCreateTime = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 10:
            this.txtRemark = ((DevExpress.Xpf.Editors.TextEdit)(target));
            return;
            case 11:
            this.btnAdd = ((DevExpress.Xpf.Core.SimpleButton)(target));
            return;
            case 12:
            this.btnClose = ((DevExpress.Xpf.Core.SimpleButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
