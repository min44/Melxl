using System;

namespace Melxl.UI;

public partial class App
{
    public App() => Activated += StartElmish;

    private void StartElmish(object? sender, EventArgs e)
    {
        Activated -= StartElmish;
        Melxl.Startup.App.Run(MainWindow);
    }
}