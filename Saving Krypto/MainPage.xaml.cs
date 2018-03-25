using KryptoInterface;
using KryptoInterface.Interface;
using KryptoModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Saving_Krypto.PageAll;
using KryptoInterface.Model;

namespace Saving_Krypto
{
    public sealed partial class MainPage : Page
    {
        
        public MainPage()
        {
            InitializeComponent();
                   
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = e.Parameter;          
        }
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             if (home.IsSelected)
             {
                Frame.Navigate(typeof(MainPage), DataContext);
                 TitleTextBlock.Text = "Главная";
             }
             else if (TableList.IsSelected)
             {
                Frame.Navigate(typeof(TableList), DataContext);                       
             }
            mySplitView.IsPaneOpen = false;

        }
    }
}
