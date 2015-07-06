using System.Windows;
using RedEmpeloOffLine.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace RedEmpeloOffLine.View
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            DataContext = new ViewModelWindow2();
        }
    }
}
