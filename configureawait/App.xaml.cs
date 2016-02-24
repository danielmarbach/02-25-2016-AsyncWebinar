using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace configureawait
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            MessageBox.Show("Attach Debugger", "Attach Debugger", MessageBoxButton.OK);
            
            Debugger.Break();

            Debug.WriteLine(SynchronizationContext.Current != null ? "not null" : "null");

            await AsyncMethod();

            Debug.WriteLine(SynchronizationContext.Current != null ? "not null" : "null");

            await AsyncMethod().ConfigureAwait(false);

            Debug.WriteLine(SynchronizationContext.Current != null ? "not null" : "null");
        }

        static async Task AsyncMethod()
        {
            Debug.WriteLine(SynchronizationContext.Current != null ? "not null" : "null");
            await Task.Delay(100).ConfigureAwait(false);
            Debug.WriteLine(SynchronizationContext.Current != null ? "not null" : "null");
            await Task.Delay(100);
        }
    }
}
