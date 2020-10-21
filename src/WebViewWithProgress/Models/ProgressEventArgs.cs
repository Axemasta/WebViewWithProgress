using System;
namespace WebViewWithProgress.Models
{
    public class ProgressEventArgs : EventArgs
    {
        public double Progress { get; }

        public ProgressEventArgs(double progress)
        {
            Progress = progress;
        }
    }
}
