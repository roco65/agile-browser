﻿using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp.Structs;
using CefSharp.WinForms.Internals;
using CefSharp;
using CefSharp.WinForms;

namespace AgileBrowser.WinForms.Handlers
{
    public class DisplayHandler : IDisplayHandler
    {
        private Control parent;
        private Form fullScreenForm;

        void IDisplayHandler.OnAddressChanged(IWebBrowser browserControl, AddressChangedEventArgs addressChangedArgs)
        {
            
        }

        bool IDisplayHandler.OnAutoResize(IWebBrowser browserControl, IBrowser browser, Size newSize)
        {
            return false;
        }

        void IDisplayHandler.OnTitleChanged(IWebBrowser browserControl, TitleChangedEventArgs titleChangedArgs)
        {
            
        }

        void IDisplayHandler.OnFaviconUrlChange(IWebBrowser browserControl, IBrowser browser, IList<string> urls)
        {
            
        }

        void IDisplayHandler.OnFullscreenModeChange(IWebBrowser browserControl, IBrowser browser, bool fullscreen)
        {
            var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            chromiumWebBrowser.InvokeOnUiThreadIfRequired(() =>
            {
                if (fullscreen)
                {
                    parent = chromiumWebBrowser.Parent;

                    parent.Controls.Remove(chromiumWebBrowser);

                    fullScreenForm = new Form();
                    fullScreenForm.FormBorderStyle = FormBorderStyle.None;
                    fullScreenForm.WindowState = FormWindowState.Maximized;

                    fullScreenForm.Controls.Add(chromiumWebBrowser);

                    fullScreenForm.ShowDialog(parent.FindForm());
                }
                else
                {
                    fullScreenForm.Controls.Remove(chromiumWebBrowser);

                    parent.Controls.Add(chromiumWebBrowser);

                    fullScreenForm.Close();
                    fullScreenForm.Dispose();
                    fullScreenForm = null;
                }
            });
        }

        bool IDisplayHandler.OnTooltipChanged(IWebBrowser browserControl, ref string text)
        {
            //text = "Sample text";
            return false;
        }

        void IDisplayHandler.OnStatusMessage(IWebBrowser browserControl, StatusMessageEventArgs statusMessageArgs)
        {
            
        }

        bool IDisplayHandler.OnConsoleMessage(IWebBrowser browserControl, ConsoleMessageEventArgs consoleMessageArgs)
        {
            return false;
        }
    }
}
