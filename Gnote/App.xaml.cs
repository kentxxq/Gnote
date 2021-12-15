using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using CommunityToolkit.Mvvm.DependencyInjection;
using Gnote.Interfaces;
using Gnote.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Gnote
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            //IOC
            Ioc.Default.ConfigureServices(new ServiceCollection()
                                                            .AddSingleton<IStore,StoreService>()
                                                            .BuildServiceProvider());
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            InitCheck();
            
            m_window = new MainWindow();
            m_window.Activate();
        }

        /// <summary>
        /// 应用初始化检查
        /// </summary>
        protected void InitCheck()
        {
            var store = Ioc.Default.GetRequiredService<IStore>();
            // 创建目录
            if (!Directory.Exists(store.GetDataPath())) { 
                Directory.CreateDirectory(store.GetNotePath());
                ApplicationData.Current.LocalSettings.Values["DataPath"] = store.GetDataPath();
            }
        }

        private Window m_window;
    }
}
