﻿#pragma checksum "C:\WrkFldr\NurseAgenda3\NurseAgenda3\AttributionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FDBF6AEFEAB9B64F8C65F4DAA5049A21"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NurseAgenda3
{
    partial class AttributionPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.MenuButton4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 3:
                {
                    this.MenuButton3 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\AttributionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuButton3).Click += this.AttributionButton_Click;
                    #line default
                }
                break;
            case 4:
                {
                    this.MenuButton2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 23 "..\..\..\AttributionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.MenuButton2).Click += this.DeleteButton_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.FeuilleRouteButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\AttributionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.FeuilleRouteButton).Click += this.FeuilleRouteButton_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 15 "..\..\..\AttributionPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HamburgerButton).Click += this.HamburgerButton_Click;
                    #line default
                }
                break;
            case 7:
                {
                    this.TitleBar = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8:
                {
                    this.Content = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9:
                {
                    this.validate = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 10:
                {
                    this.txtDate = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.DateSoin = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 12:
                {
                    this.txtInfirmier = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.Infirmiere = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 14:
                {
                    this.txtPatient = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.Patient = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

