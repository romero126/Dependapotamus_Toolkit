﻿#pragma checksum "..\..\..\..\UX\Settings\PSRuntime.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F881ABCEDE3B27A350FB1B75491890B2"
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
using UI.Elements.UX;


namespace UI.Body.PSHostUI.UX.Settings {
    
    
    /// <summary>
    /// PSRuntime
    /// </summary>
    public partial class PSRuntime : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\..\..\UX\Settings\PSRuntime.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal UI.Elements.UX.Settings Settings;
        
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
            System.Uri resourceLocater = new System.Uri("/UI.Body.PSHostUI;component/ux/settings/psruntime.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UX\Settings\PSRuntime.xaml"
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
            
            #line 5 "..\..\..\..\UX\Settings\PSRuntime.xaml"
            ((UI.Body.PSHostUI.UX.Settings.PSRuntime)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.UserControl_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Settings = ((UI.Elements.UX.Settings)(target));
            
            #line 8 "..\..\..\..\UX\Settings\PSRuntime.xaml"
            this.Settings.EventClose += new System.EventHandler(this.Settings_EventClose);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 20 "..\..\..\..\UX\Settings\PSRuntime.xaml"
            ((UI.Elements.UX.FlatButton)(target)).Click += new System.EventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\..\..\UX\Settings\PSRuntime.xaml"
            ((UI.Elements.UX.FlatButton)(target)).Click += new System.EventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

