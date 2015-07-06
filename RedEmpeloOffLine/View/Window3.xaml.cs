using System.Windows;
using RedEmpeloOffLine.Model;
using RedEmpeloOffLine.ViewModel;
using System;
using System.Windows.Media.Imaging;

namespace RedEmpeloOffLine.View
{
    public partial class Window3 : Window
    {
        public Window3(Person person)
        {
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            var vm = new ViewModelWindow3(person);
            DataContext = vm;
            vm.CloseWindowEvent += new System.EventHandler(vm_CloseWindowEvent);
        }

        void vm_CloseWindowEvent(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
