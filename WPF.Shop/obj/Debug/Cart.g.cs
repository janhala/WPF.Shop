﻿#pragma checksum "..\..\Cart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "536E90CC9E1657E6A249A8E7388C740F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
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
using WPF.Shop;


namespace WPF.Shop {
    
    
    /// <summary>
    /// Cart
    /// </summary>
    public partial class Cart : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 61 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CartLV;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jmeno;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prijmeni;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox telefon;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox email;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pin;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ulice;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox obec;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox psc;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox DopravaCheckBox;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox DopravaCheckBoxCP;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\Cart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label celkovaCena;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF.Shop;component/cart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Cart.xaml"
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
            this.CartLV = ((System.Windows.Controls.ListView)(target));
            
            #line 61 "..\..\Cart.xaml"
            this.CartLV.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CartLV_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.jmeno = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.prijmeni = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.telefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.pin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.ulice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.obec = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.psc = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.DopravaCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 140 "..\..\Cart.xaml"
            this.DopravaCheckBox.Checked += new System.Windows.RoutedEventHandler(this.DopravaCheckBox_Checked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.DopravaCheckBoxCP = ((System.Windows.Controls.CheckBox)(target));
            
            #line 141 "..\..\Cart.xaml"
            this.DopravaCheckBoxCP.Checked += new System.Windows.RoutedEventHandler(this.DopravaCheckBoxCP_Checked);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 142 "..\..\Cart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VyprazdnitKosik);
            
            #line default
            #line hidden
            return;
            case 14:
            this.celkovaCena = ((System.Windows.Controls.Label)(target));
            return;
            case 15:
            
            #line 146 "..\..\Cart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveOrder);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 82 "..\..\Cart.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OdstranitZeSeznamu);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

