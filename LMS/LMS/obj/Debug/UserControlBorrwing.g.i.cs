﻿#pragma checksum "..\..\UserControlBorrwing.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D379267836F890EC12F5B51BEE51231C10C9684F4D4DE593B92C914CB5054B77"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LMS;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace LMS {
    
    
    /// <summary>
    /// UserControlBorrwing
    /// </summary>
    public partial class UserControlBorrwing : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 69 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_addlanguage;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_addtypes;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_loanmanagement;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border add_borrower;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_addauthor;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\UserControlBorrwing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border new_borrowing;
        
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
            System.Uri resourceLocater = new System.Uri("/LMS;component/usercontrolborrwing.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlBorrwing.xaml"
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
            this.br_addlanguage = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.br_addtypes = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.br_loanmanagement = ((System.Windows.Controls.Border)(target));
            
            #line 84 "..\..\UserControlBorrwing.xaml"
            this.br_loanmanagement.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.br_loanmanagement_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.add_borrower = ((System.Windows.Controls.Border)(target));
            
            #line 90 "..\..\UserControlBorrwing.xaml"
            this.add_borrower.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.add_borrower_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.br_addauthor = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.new_borrowing = ((System.Windows.Controls.Border)(target));
            
            #line 106 "..\..\UserControlBorrwing.xaml"
            this.new_borrowing.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.new_borrowing_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

