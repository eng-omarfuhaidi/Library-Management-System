﻿#pragma checksum "..\..\..\PL\UserControlReturnBooks.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2EA3655772A72BB2CCD6A0FEE745B8DBBF095689EF7D0F90604E5C77033041F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LMS.UserControls;
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


namespace LMS.UserControls {
    
    
    /// <summary>
    /// UserControlReturnBooks
    /// </summary>
    public partial class UserControlReturnBooks : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_blok1;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txt_search_for_borrname;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_blok2;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker search_for_loan_date;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_detailes;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\PL\UserControlReturnBooks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid grid_loan_laters;
        
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
            System.Uri resourceLocater = new System.Uri("/LMS;component/pl/usercontrolreturnbooks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PL\UserControlReturnBooks.xaml"
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
            this.txt_blok1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txt_search_for_borrname = ((System.Windows.Controls.TextBox)(target));
            
            #line 44 "..\..\..\PL\UserControlReturnBooks.xaml"
            this.txt_search_for_borrname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_search_for_borrname_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txt_blok2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.search_for_loan_date = ((System.Windows.Controls.DatePicker)(target));
            
            #line 47 "..\..\..\PL\UserControlReturnBooks.xaml"
            this.search_for_loan_date.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.search_for_loan_date_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dg_detailes = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.grid_loan_laters = ((System.Windows.Controls.DataGrid)(target));
            
            #line 58 "..\..\..\PL\UserControlReturnBooks.xaml"
            this.grid_loan_laters.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.grid_loan_laters_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

