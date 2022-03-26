using System;
using Melxl.Startup;

namespace Melxl.UI
{
    public partial class App
    {
        public App() => Activated += StartElmish;

        private void StartElmish(object? sender, EventArgs e)
        {
            Activated -= StartElmish;
            Program.main(MainWindow);
        }
    }
}