﻿#pragma checksum "..\..\..\pgAllergenes.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B2B7ADA569CFAD9DD13FB358F00C9E28DBAE6F05"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
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
using WpfENVRAC;


namespace WpfENVRAC {
    
    
    /// <summary>
    /// pgAllergenes
    /// </summary>
    public partial class pgAllergenes : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\pgAllergenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox grpAllergenes;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\pgAllergenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvAllergenes;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\pgAllergenes.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid inboxAjouterAllergene;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfENVRAC;component/pgallergenes.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pgAllergenes.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.grpAllergenes = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 2:
            this.lvAllergenes = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            
            #line 16 "..\..\..\pgAllergenes.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SupprimerAllergene);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\pgAllergenes.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterAllergene);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 28 "..\..\..\pgAllergenes.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterAllergene);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 35 "..\..\..\pgAllergenes.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.inboxAjouterAllergene = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            
            #line 68 "..\..\..\pgAllergenes.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AjouterAllergeneAnnulerAction);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
