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
using System.Reflection;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Saving_Krypto.PageAll
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class ViewMyEntity : Page
    {
        public ViewMyEntity()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Parametor view)
            {
                DataContext = view;
                if (view.Paramet is IMyEntity entity)
                {
                    Buillding(entity);
                }            
            }

        }
        void Buillding(IMyEntity myEntity)
        {
            
            Type Entity = myEntity.GetType();
            Title.Text = $"CLASS Name: {Entity.Name}. INTERFACE Name:";

            Type[] Interfaca = Entity.GetInterfaces();
            foreach(Type inter in  Interfaca)
            {
                Title.Text += inter.Name + ", ";
            }


            PropertyInfo[] properties = Entity.GetProperties();

            StackPanel LineTitle = new StackPanel() { Orientation = Orientation.Horizontal };
            LineTitle.Margin = new Thickness(2);
            LineTitle.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            LineTitle.BorderThickness = new Thickness(2);
            LineTitle.Children.Add(new TextBlock() { Margin = new Thickness(3, 0, 3, 0), Text = "Type", MinWidth = 100 });
            LineTitle.Children.Add(new TextBlock() { Margin = new Thickness(3, 0, 3, 0), Text = "Name", MinWidth = 100 });
            LineTitle.Children.Add(new TextBlock() { Margin = new Thickness(3, 0, 3, 0), Text = "Value", MinWidth = 100});
            MainPanel.Children.Add(LineTitle);

            foreach (PropertyInfo property in properties)
            {
              
                
              
                if (!property.CanRead)
                {
                    continue;
                }
                StackPanel LineProperty = new StackPanel() { Orientation = Orientation.Horizontal };


                LineProperty.Margin = new Thickness(2);
                LineProperty.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                LineProperty.BorderThickness = new Thickness(1);
                LineProperty.Children.Add(new TextBlock() { Margin = new Thickness(3, 0, 3, 0), Text = property.PropertyType.Name, MinWidth = 100 });
                LineProperty.Children.Add(new TextBlock() { Margin = new Thickness(3, 0, 3, 0), Text = property.Name, MinWidth = 100 });
                TextBox textBox = new TextBox() { Name = property.Name, Margin = new Thickness(3, 0, 3, 0), MinWidth = 100, IsEnabled = false };
 
                LineProperty.Children.Add(textBox);

               /* TextBox textBox2 = new TextBox() { Name = property.Name, Margin = new Thickness(3, 0, 3, 0), Text = property.GetValue(myEntity)?.ToString() ?? "", MinWidth = 100, IsEnabled = false };
                LineProperty.Children.Add(textBox2);*/

                if (property.CanWrite)
                {
                    Button buttonEdit = new Button() { Name = "Edit", Margin = new Thickness(3, 0, 3, 0), Content = "Edit", MinWidth = 100 };
                    buttonEdit.Click += ButtonEdit_Click;
                    LineProperty.Children.Add(buttonEdit);

                    Button buttonSave = new Button() { Name = "Save", Margin = new Thickness(3, 0, 3, 0), Content = "Save", MinWidth = 100, Visibility = Visibility.Collapsed };
                    buttonSave.Click += ButtonSave_Click;
                    LineProperty.Children.Add(buttonSave);

                    Button buttonСancel = new Button() { Name = "Сancel", Margin = new Thickness(3, 0, 3, 0), Content = "Сancel", MinWidth = 100, Visibility = Visibility.Collapsed };
                    buttonСancel.Click += buttonСancel_Click;
                    LineProperty.Children.Add(buttonСancel);
                }
                if (property.PropertyType == typeof(IMyEntity))
                {
                    if (property.GetValue(myEntity) != null)
                    {
                        Button buttonEditEntity = new Button() { Name = $"{property.Name}", Margin = new Thickness(3, 0, 3, 0), Content = "Edit Entity", MinWidth = 100 };
                        buttonEditEntity.Click += ButtonEditEntity_Click;
                        LineProperty.Children.Add(buttonEditEntity);
                    }

                }

                MainPanel.Children.Add(LineProperty);


                Binding binding = new Binding();

               // binding.ElementName = "ParametMy"; // элемент-источник
                binding.Path = new PropertyPath("Paramet." + property.Name); // свойство элемента-источника
                textBox.SetBinding(TextBox.TextProperty, binding); // установка привязки для элемента-приемника
               /* if (property.CanWrite)
                {
                    binding.Mode = BindingMode.TwoWay;
                }*/

              /*  Binding binding2 = new Binding();

               // binding2.ElementName = property.Name; // элемент-источник
                binding2.Path = new PropertyPath("ParametMy." + property.Name); // свойство элемента-источника
                textBox2.SetBinding(TextBox.TextProperty, binding2); // установка привязки для элемента-приемника*/
              /*  if (property.CanWrite)
                {
                    binding2.Mode = BindingMode.TwoWay;
                }*/

            }


        }

        private void ButtonEditEntity_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is Parametor view && sender is Button button)
            {
                IMyEntity myEntity = view.GetObject<IMyEntity>();
                Type Entity = myEntity.GetType();
                PropertyInfo propertyInfo = Entity.GetProperty(button.Name);
                IMyEntity newEntity = (IMyEntity)propertyInfo.GetValue(myEntity);

                Parametor parametor = view.AddParametor(newEntity);
                Frame.Navigate(typeof(ViewMyEntity), parametor);
            }

        }

        private void buttonСancel_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Parent != null && button.Parent is StackPanel panel)
                {
                    TextBox textBoxes = panel.Children.OfType<TextBox>().FirstOrDefault();
                    textBoxes.IsEnabled = false;               
                    if (DataContext is Parametor view && view.Paramet is IMyEntity MyEntity)
                    {
                        Type Entity = MyEntity.GetType();

                        PropertyInfo property = Entity.GetProperty(textBoxes.Name);
                        if (property != null)
                        {
                            textBoxes.Text = property.GetValue(MyEntity).ToString();
                        }

                        IEnumerable<Button> Allbutton = panel.Children.OfType<Button>();
                        foreach (Button box in Allbutton)
                        {
                            if (box.Name == "Save" || box.Name == "Сancel")
                            {
                                box.Visibility = Visibility.Collapsed;
                            }
                            else if (box.Name == "Edit")
                            {
                                box.Visibility = Visibility.Visible;
                            }
                        }
                    }

                }
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Parent != null && button.Parent is StackPanel panel)
                {
                    TextBox textBoxes = panel.Children.OfType<TextBox>().FirstOrDefault();
                    textBoxes.IsEnabled = false;                    
                    if (DataContext is Parametor view && view.Paramet is IMyEntity MyEntity)
                    {
                        Type Entity = MyEntity.GetType();
                        PropertyInfo property = Entity.GetProperty(textBoxes.Name);

                        if (property != null)
                        {
                            property.SetValue(MyEntity, textBoxes.Text);
                        }
                        /////
                        IEnumerable<Button> Allbutton = panel.Children.OfType<Button>();
                        foreach (Button box in Allbutton)
                        {
                            if (box.Name == "Save" || box.Name == "Сancel")
                            {
                                box.Visibility = Visibility.Collapsed;
                            }
                            else if (box.Name == "Edit")
                            {
                                box.Visibility = Visibility.Visible;
                            }
                        }
                    }
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                if (button.Parent != null && button.Parent is StackPanel panel)
                {
                    TextBox textBoxes = panel.Children.OfType<TextBox>().FirstOrDefault();

                    textBoxes.IsEnabled = true;

                    IEnumerable<Button>  Allbutton  = panel.Children.OfType<Button>();
                    foreach (Button box in Allbutton)
                    {
                        if (box.Name == "Save" || box.Name == "Сancel")
                        {
                            box.Visibility = Visibility.Visible;
                        }
                        else if(box.Name == "Edit")
                        {
                            box.Visibility = Visibility.Collapsed;
                        }
                    }
                }

            }
           
        }
    }
}
