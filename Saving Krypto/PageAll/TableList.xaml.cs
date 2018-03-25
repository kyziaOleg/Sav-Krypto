using KryptoInterface;
using KryptoInterface.Interface;
using Saving_Krypto.ViewModel;
using System;
using System.Collections.Generic;
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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Saving_Krypto.PageAll
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TableList : Page
    {

        public TableList()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Parametor view)
            {
                if (view.Paramet is IViewModelLayer Model)
                {
                    IEnumerable<ITable> tables=  Model.GetTable();
                    Parametor  нов=view.AddParametor(tables);
                    DataContext = нов;
                }              
            }
                 
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Object Выделен = ((ListBox)sender).SelectedItems.FirstOrDefault();
            if (DataContext is Parametor view)
            {
                Parametor нов = view.AddParametor(Выделен);
                Frame.Navigate(typeof(Table), нов);
            }

           


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
