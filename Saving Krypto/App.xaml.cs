using KryptoInterface;
using KryptoInterface.Interface;
using KryptoModel;
using Ninject;
using Saving_Krypto.Inteface;
using Saving_Krypto.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using KryptoRepositoryLayer.Context;
using Microsoft.EntityFrameworkCore;
using KryptoInterface.MyModel;

namespace Saving_Krypto
{
    /// <summary>
    /// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
    /// </summary>
    sealed partial class App : Application
    {
        IKernel kernel;
        /// <summary>
        /// Инициализирует одноэлементный объект приложения.  Это первая выполняемая строка разрабатываемого
        /// кода; поэтому она является логическим эквивалентом main() или WinMain().
        /// </summary>
        public App()
        {

             kernel = new StandardKernel(new ModulInjectMain());

            



            this.InitializeComponent();
            this.Suspending += OnSuspending;


           /* using (MainContext var = new MainContext("Krypto"))
            {
                var.Database.Migrate();
                List<User> enetable = var.UserDates.ToList();
            }*/
        }

        /// <summary>
        /// Вызывается при обычном запуске приложения пользователем.  Будут использоваться другие точки входа,
        /// например, если приложение запускается для открытия конкретного файла.
        /// </summary>
        /// <param name="e">Сведения о запросе и обработке запуска.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Не повторяйте инициализацию приложения, если в окне уже имеется содержимое,
            // только обеспечьте активность окна
            if (rootFrame == null)
            {
                // Создание фрейма, который станет контекстом навигации, и переход к первой странице
                rootFrame = new Frame() {  };

                rootFrame.NavigationFailed += OnNavigationFailed;
                rootFrame.Navigating += RootFrame_Navigating;
                rootFrame.Navigated += RootFrame_Navigated;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Загрузить состояние из ранее приостановленного приложения
                }

                // Размещение фрейма в текущем окне
                Window.Current.Content = rootFrame;

            }
           



            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage),new Parametor( kernel.Get<IViewModelLayer>()));
                }

               
                // Обеспечение активности текущего окна
                Window.Current.Activate();
               // SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =AppViewBackButtonVisibility.Visible;
                SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

                rootFrame.Navigated += (s, args) =>
                {
                    if (rootFrame.CanGoBack) // если можно перейти назад, показываем кнопку
                    {
                        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =AppViewBackButtonVisibility.Visible;
                    }
                    else
                    {
                        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =AppViewBackButtonVisibility.Collapsed;
                    }
                };
            }
        }

        private void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            Frame frame = Window.Current.Content as Frame;
            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }

        }

        private void RootFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.SourcePageType == typeof(MainPage) && e.Parameter == null)
            {
               if( ((Frame)Window.Current.Content).Content is MainPage newPage )
                {

                }


            }
        }

        private void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            


        }

        /// <summary>
        /// Вызывается в случае сбоя навигации на определенную страницу
        /// </summary>
        /// <param name="sender">Фрейм, для которого произошел сбой навигации</param>
        /// <param name="e">Сведения о сбое навигации</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
        /// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
        /// содержимым памяти.
        /// </summary>
        /// <param name="sender">Источник запроса приостановки.</param>
        /// <param name="e">Сведения о запросе приостановки.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Сохранить состояние приложения и остановить все фоновые операции
            deferral.Complete();
        }
    }
}
