﻿#pragma checksum "..\..\..\HSat\HouseStatisticsView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1CF10DF0E2F4C90F9A38B40FB0998C06F3D0725A3DFB1099D1A57026A95B45C1"
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
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using HRSM.DXHouseApp.ViewModels.HSat;
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
using System.Windows.Interactivity;
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


namespace HRSM.DXHouseApp.HSat {
    
    
    /// <summary>
    /// HouseStatisticsView
    /// </summary>
    public partial class HouseStatisticsView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 101 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.GridControl gridHouseData;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView tvList;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.ChartControl chartHouses;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.BarSideBySideSeries2D totalSeries;
        
        #line default
        #line hidden
        
        
        #line 172 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.BarSideBySideSeries2D pubSeries;
        
        #line default
        #line hidden
        
        
        #line 175 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform pubSeriesAngle;
        
        #line default
        #line hidden
        
        
        #line 184 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.BarSideBySideSeries2D unPubSeries;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.BarSideBySideSeries2D hasRSSeries;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Charts.BarSideBySideSeries2D unRSSeries;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.Storyboard st;
        
        #line default
        #line hidden
        
        
        #line 234 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.RotateTransform chartAngle;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\HSat\HouseStatisticsView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Core.SimpleButton btnOut;
        
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
            System.Uri resourceLocater = new System.Uri("/HRSM.DXHouseApp;component/hsat/housestatisticsview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HSat\HouseStatisticsView.xaml"
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
            
            #line 13 "..\..\..\HSat\HouseStatisticsView.xaml"
            ((HRSM.DXHouseApp.HSat.HouseStatisticsView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridHouseData = ((DevExpress.Xpf.Grid.GridControl)(target));
            return;
            case 3:
            this.tvList = ((DevExpress.Xpf.Grid.TableView)(target));
            
            #line 104 "..\..\..\HSat\HouseStatisticsView.xaml"
            this.tvList.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.TvList_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.chartHouses = ((DevExpress.Xpf.Charts.ChartControl)(target));
            return;
            case 5:
            this.totalSeries = ((DevExpress.Xpf.Charts.BarSideBySideSeries2D)(target));
            return;
            case 6:
            this.pubSeries = ((DevExpress.Xpf.Charts.BarSideBySideSeries2D)(target));
            return;
            case 7:
            this.pubSeriesAngle = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 8:
            this.unPubSeries = ((DevExpress.Xpf.Charts.BarSideBySideSeries2D)(target));
            return;
            case 9:
            this.hasRSSeries = ((DevExpress.Xpf.Charts.BarSideBySideSeries2D)(target));
            return;
            case 10:
            this.unRSSeries = ((DevExpress.Xpf.Charts.BarSideBySideSeries2D)(target));
            return;
            case 11:
            this.st = ((System.Windows.Media.Animation.Storyboard)(target));
            return;
            case 12:
            this.chartAngle = ((System.Windows.Media.RotateTransform)(target));
            return;
            case 13:
            this.btnOut = ((DevExpress.Xpf.Core.SimpleButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

