﻿#pragma checksum "..\..\..\View\AzuriranjeProfila.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1A8A938597E0648DAB09E365669E84392D12BC3E220E69705E3769CAD3E77F08"
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
using WpfApp1.View;


namespace WpfApp1.View {
    
    
    /// <summary>
    /// AzuriranjeProfila
    /// </summary>
    public partial class AzuriranjeProfila : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ime;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prezime;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox korIme;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lozinka;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox brTel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SacuvajPromene;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\View\AzuriranjeProfila.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Odbaci;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/view/azuriranjeprofila.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\AzuriranjeProfila.xaml"
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
            this.ime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.prezime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.korIme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lozinka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.brTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.SacuvajPromene = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\View\AzuriranjeProfila.xaml"
            this.SacuvajPromene.Click += new System.Windows.RoutedEventHandler(this.SacuvajPromene_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Odbaci = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\View\AzuriranjeProfila.xaml"
            this.Odbaci.Click += new System.Windows.RoutedEventHandler(this.Odbaci_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

