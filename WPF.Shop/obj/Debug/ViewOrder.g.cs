﻿#pragma checksum "..\..\ViewOrder.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F0D760F4E3C162B12766E3F5A3A2ADF1"
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
    /// ViewOrder
    /// </summary>
    public partial class ViewOrder : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cisloObjednavky;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView objednavkaLV;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button stornoBTN;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pinLBL;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pin;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ViewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pinBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/WPF.Shop;component/vieworder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ViewOrder.xaml"
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
            this.cisloObjednavky = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 27 "..\..\ViewOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.VypsatObjednavku);
            
            #line default
            #line hidden
            return;
            case 3:
            this.objednavkaLV = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.stornoBTN = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\ViewOrder.xaml"
            this.stornoBTN.Click += new System.Windows.RoutedEventHandler(this.ZobrazitPIN);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pinLBL = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.pin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.pinBTN = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ViewOrder.xaml"
            this.pinBTN.Click += new System.Windows.RoutedEventHandler(this.StornovatObjednavku);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
