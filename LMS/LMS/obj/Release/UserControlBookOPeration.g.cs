#pragma checksum "..\..\UserControlBookOPeration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA5467F1DE3F1D4C597C4CE3D7CCF807936CF1325703D06127A4A8FD147330C4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using NavigationDrawerPopUpMenu2;
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


namespace NavigationDrawerPopUpMenu2 {
    
    
    /// <summary>
    /// UserControlBookOPeration
    /// </summary>
    public partial class UserControlBookOPeration : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\UserControlBookOPeration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border book_management;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\UserControlBookOPeration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_addbooks;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\UserControlBookOPeration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border br_addbooks_Copy;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\UserControlBookOPeration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border book_management_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/NavigationDrawerPopUpMenu2;component/usercontrolbookoperation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserControlBookOPeration.xaml"
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
            this.book_management = ((System.Windows.Controls.Border)(target));
            
            #line 58 "..\..\UserControlBookOPeration.xaml"
            this.book_management.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.book_management_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.br_addbooks = ((System.Windows.Controls.Border)(target));
            
            #line 64 "..\..\UserControlBookOPeration.xaml"
            this.br_addbooks.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.br_addbooks_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.br_addbooks_Copy = ((System.Windows.Controls.Border)(target));
            
            #line 70 "..\..\UserControlBookOPeration.xaml"
            this.br_addbooks_Copy.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.br_addbooks_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.book_management_Copy = ((System.Windows.Controls.Border)(target));
            
            #line 76 "..\..\UserControlBookOPeration.xaml"
            this.book_management_Copy.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.book_management_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

