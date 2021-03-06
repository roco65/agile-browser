﻿using CefSharp;

namespace AgileBrowser.RequestEventHandler
{
    public class OnPluginCrashedEventArgs : BaseRequestEventArgs
    {
        public OnPluginCrashedEventArgs(IWebBrowser browserControl, IBrowser browser, string pluginPath) : base(browserControl, browser)
        {
            PluginPath = pluginPath;
        }

        public string PluginPath { get; private set; }
    }
}
