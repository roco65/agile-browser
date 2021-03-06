﻿using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public abstract class BaseRequestEventArgs : System.EventArgs
    {
        protected BaseRequestEventArgs(IWebBrowser browserControl, IBrowser browser)
        {
            BrowserControl = browserControl;
            Browser = browser;
        }

        public IWebBrowser BrowserControl { get; private set; }
        public IBrowser Browser { get; private set; }
    }
}
