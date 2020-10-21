using System;
using Xamarin.Forms;

namespace WebViewWithProgress.Controls
{
    public class ProgressWebBrowser : ContentView
    {
        public ProgressWebBrowser()
        {
            Content = BuildView();
        }

        private void OnValuePropertyChanged()
        {

        }

        public View BuildView()
        {
            //<Grid>
            //    <Grid.RowDefinitions>
            //        <RowDefinition Height="Auto"/>
            //        <RowDefinition Height="*"/>
            //    </Grid.RowDefinitions>
            //    <Frame BackgroundColor="#2196F3" Padding="24" CornerRadius="0" Grid.Row="0">
            //        <Label Text="WebView Progress Test" HorizontalTextAlignment="Center" TextColor="White" FontSize="36" />
            //    </Frame>

            //    <WebView Source="https://www.google.co.uk" Grid.Row="1"/>
            //</Grid>

            var stack = new StackLayout();
            stack.Children.Add(new Label()
            {
                Text = "Web View Progress Test",
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.White,
                FontSize = 36
            });

            stack.Children.Add(ProgressBar);
            HeaderFrame.Content = stack;

            Grid.SetRow(HeaderFrame, 0);
            Grid.SetRow(WebView, 1);

            ContentGrid.Children.Add(HeaderFrame);
            ContentGrid.Children.Add(WebView);

            WebView.ProgressChanged += OnProgressChanged;

            return ContentGrid;
        }

        private async void OnProgressChanged(object sender, Models.ProgressEventArgs e)
        {
            //Progress bar progress is between 0/1
            await ProgressBar.ProgressTo(e.Progress, 250, Easing.SinIn);
        }

        private Grid ContentGrid { get; } = new Grid()
        {
            RowDefinitions = new RowDefinitionCollection()
            {
                { new RowDefinition() { Height = GridLength.Auto } },
                { new RowDefinition() { Height = GridLength.Star } }
            }
        };

        private Frame HeaderFrame { get; } = new Frame()
        {
            BackgroundColor = Color.FromHex("#2196F3"),
            Padding = 24,
            CornerRadius = 0
        };

        private ProgressBar ProgressBar { get; } = new ProgressBar()
        {
            ProgressColor = Color.Orange,
            
            BackgroundColor = Color.Blue
        };

        private ProgressWebView WebView { get; } = new ProgressWebView()
        {
            //Source = "https://www.google.co.uk"
        };
    }
}
