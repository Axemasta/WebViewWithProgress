using System;
using System.Diagnostics;
using Foundation;
using WebViewWithProgress.Controls;
using WebViewWithProgress.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProgressWebView), typeof(ProgressWebViewRenderer))]

namespace WebViewWithProgress.iOS.Renderers
{
    public class ProgressWebViewRenderer : WkWebViewRenderer
    {
        private IDisposable _progressObserver;
        private ProgressWebView _progressWebView;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var progressWebView = Element as ProgressWebView;

            if (progressWebView == null)
                return;

            _progressWebView = progressWebView;

            //Add Observer returns an IDisposable which you MUST dispose of otherwise you will get a SIGSEV crash
            _progressObserver = AddObserver("estimatedProgress", NSKeyValueObservingOptions.New, ProgressObserver);
        }

        public void ProgressObserver(NSObservedChange nsObservedChange)
        {
            Debug.WriteLine($"Progress {EstimatedProgress}");

            _progressWebView.Progress = EstimatedProgress;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _progressObserver.Dispose();
            }
        }
    }
}
