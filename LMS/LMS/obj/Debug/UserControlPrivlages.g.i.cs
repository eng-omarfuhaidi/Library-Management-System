#pragma checksum "..\..\UserControlPrivlages.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3EF2E08F0B0C4D86E1D077FC8D0AF5E2AC190C7D106F2A0E484A33A4A4D24EC4"
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


namespace LSM {
    
    
    /// <summary>
    /// UserControlPrivlages
    /// </summary>
    public partial class UserControlPrivlages : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\UserControlPrivlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list_show_list;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\UserControlPrivlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text_search;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\UserControlPrivlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox list_user;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\UserControlPrivlages.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gr_privlages;
        
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
            System.Uri resourceLocater = new System.Uri("/LMS;component/usercontrolprivlages.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlPrivlages.xaml"
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
            this.list_show_list = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.text_search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.list_user = ((System.Windows.Controls.ListBox)(target));
            
            #line 71 "..\..\UserControlPrivlages.xaml"
            this.list_user.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.list_user_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.gr_privlages = ((System.Windows.Controls.DataGrid)(target));
            
            #line 74 "..\..\UserControlPrivlages.xaml"
            this.gr_privlages.Loaded += new System.Windows.RoutedEventHandler(this.gr_privlages_Loaded);
            
            #line default
            #line hidden
            
            #line 74 "..\..\UserControlPrivlages.xaml"
            this.gr_privlages.LoadingRowDetails += new System.EventHandler<System.Windows.Controls.DataGridRowDetailsEventArgs>(this.gr_privlages_LoadingRowDetails);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

