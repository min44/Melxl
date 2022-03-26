using System.Windows;

namespace Melxl.UI;
public partial class MainWindow: Window
{
    public MainWindow()
    {
        var cb = new Microsoft.Xaml.Behaviors.EventTrigger();
        InitializeComponent();   
    }
}