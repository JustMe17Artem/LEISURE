﻿#pragma checksum "..\..\..\..\Pages\ActivitiesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15967A88C1BF9CBB1ECF0E1943FB98010C9A6D86"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfLeisure.Pages;


namespace WpfLeisure.Pages {
    
    
    /// <summary>
    /// ActivitiesPage
    /// </summary>
    public partial class ActivitiesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnWatchPlaces;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExit;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel SearchPanel;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBType;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBDate;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBPopularity;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\..\Pages\ActivitiesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVActivities;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfLeisure;component/pages/activitiespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\ActivitiesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.16.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.BtnWatchPlaces = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.BtnWatchPlaces.Click += new System.Windows.RoutedEventHandler(this.BtnWatchPlaces_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnExit = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.BtnExit.Click += new System.Windows.RoutedEventHandler(this.BtnExit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 4:
            this.CBType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 89 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.CBType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CBDate = ((System.Windows.Controls.ComboBox)(target));
            
            #line 99 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.CBDate.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBDate_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 100 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 101 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 102 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CBPopularity = ((System.Windows.Controls.ComboBox)(target));
            
            #line 117 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.CBPopularity.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBPopularity_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 118 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 119 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 120 "..\..\..\..\Pages\ActivitiesPage.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 13:
            this.LVActivities = ((System.Windows.Controls.ListView)(target));
            
            #line 137 "..\..\..\..\Pages\ActivitiesPage.xaml"
            this.LVActivities.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LVActivities_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

