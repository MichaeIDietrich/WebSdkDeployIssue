using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;
using WebHost;

namespace ServerUI;

public partial class ServerWindow
{
    public ServerWindow()
    {
        InitializeComponent();
    }

    private void StartServer(object sender, RoutedEventArgs e)
    {
        ServerRuntime.StartAsync();
    }

    private void RequestNavigate(object sender, RequestNavigateEventArgs  e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
    }
}