using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace WebViewTutorial
{
  public partial class MainView : View
  {
    public MainView() : base()
    {
      InitializeComponent();
    }

    public void OnWebViewAddedToWindow(object sender, EventArgs e)
    {
      if (sender is WebView webView)
      {
        webView.KeyInputFocus = true;
      }
    }

    public void OnPageLoadStarted(object sender, WebViewPageLoadEventArgs e)
    {
      if (sender is WebView webView)
      {
        StatusText.Text = $"[Loading...] {e.PageUrl}";
        StatusText.Show();
      }
    }

    public void OnPageLoadFinished(object sender, WebViewPageLoadEventArgs e)
    {
      if (sender is WebView webView)
      {
        StatusText.Text = $"[Done] {e.PageUrl}";
        PrevButton.IsEnabled = webView.CanGoBack();
        NextButton.IsEnabled = webView.CanGoForward();
      }
    }

    public void OnBackClicked(object sender, EventArgs e)
    {
      TargetWebView.GoBack();
    }

    public void OnNextClicked(object sender, EventArgs e)
    {
      TargetWebView.GoForward();
    }
  }
}
