using System;
using System.Diagnostics;
using WebViewWithProgress.Models;
using Xamarin.Forms;

namespace WebViewWithProgress.Controls
{
    public class ProgressWebView : WebView
    {
        public static readonly BindableProperty ProgressProperty = BindableProperty.Create(nameof(Progress), typeof(double), typeof(ProgressWebView), propertyChanged: OnValuePropertyChanged);

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
            => ((ProgressWebView)bindable).OnProgressPropertyChanged();

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public ProgressWebView()
        {
            Source = "https://www.google.co.uk";
        }

        private void OnProgressPropertyChanged()
        {
            Debug.WriteLine($"Progress changed in xamarin forms!!! - {Progress} ");

            ProgressChanged?.Invoke(this, new ProgressEventArgs(Progress));
        }
    }
}
