using System;
using System.Diagnostics;
using Android.Widget;
using WebViewWithProgress.Models;
using Xamarin.Forms.Platform.Android;

namespace WebViewWithProgress.Droid.Renderers
{
    public class WebViewChromeClient : FormsWebChromeClient
    {
        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public WebViewChromeClient()
        {
        }

        public override void OnProgressChanged(Android.Webkit.WebView view, int newProgress)
        {
            //new progress is between 0-100 need to convert to 0-1

            double progress = newProgress / 100;

            Debug.WriteLine($"WebViewChromeClient - Progress Changed! - New Progress: {newProgress}");
            ProgressChanged?.Invoke(this, new ProgressEventArgs(progress));
        }
    }
}
