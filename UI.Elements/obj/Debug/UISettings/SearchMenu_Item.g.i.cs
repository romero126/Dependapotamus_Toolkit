﻿#pragma checksum "..\..\..\UISettings\SearchMenu_Item.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C376AD867571315D559B621D049244DF"
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


namespace UI.Elements.UISettings {
    
    
    /// <summary>
    /// SearchMenu_Item
    /// </summary>
    public partial class SearchMenu_Item : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Left_Grid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Left_OBJ;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Text_Grid;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Text_OBJ;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Right_Grid;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\UISettings\SearchMenu_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Right_OBJ;
        
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
            System.Uri resourceLocater = new System.Uri("/UI.Elements;component/uisettings/searchmenu_item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UISettings\SearchMenu_Item.xaml"
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
            
            #line 5 "..\..\..\UISettings\SearchMenu_Item.xaml"
            ((UI.Elements.UISettings.SearchMenu_Item)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.border = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Left_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 38 "..\..\..\UISettings\SearchMenu_Item.xaml"
            this.Left_Grid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Event_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Left_OBJ = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.Text_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 43 "..\..\..\UISettings\SearchMenu_Item.xaml"
            this.Text_Grid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Event_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Text_OBJ = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Right_Grid = ((System.Windows.Controls.Grid)(target));
            
            #line 54 "..\..\..\UISettings\SearchMenu_Item.xaml"
            this.Right_Grid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Event_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Right_OBJ = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

