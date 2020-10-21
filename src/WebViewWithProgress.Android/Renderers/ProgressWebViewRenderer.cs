using System;
using Android.Content;
using WebViewWithProgress.Controls;
using WebViewWithProgress.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ProgressWebView), typeof(ProgressWebViewRenderer))]

namespace WebViewWithProgress.Droid.Renderers
{
    public class ProgressWebViewRenderer : WebViewRenderer
    {
        private readonly Context _context;

        private ProgressWebView _formsControl;

        public ProgressWebViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
                return;

            var cast = Element as ProgressWebView;

            if (cast == null)
                return;

            _formsControl = cast;

            var chromeClient = new WebViewChromeClient();

            chromeClient.ProgressChanged += OnProgressChanged;

            Control.SetWebChromeClient(chromeClient);
        }

        private void OnProgressChanged(object sender, Models.ProgressEventArgs e)
        {
            _formsControl.Progress = e.Progress;
        }
    }
}
