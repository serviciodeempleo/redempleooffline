﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RedEmpleoOffLine.Helpers;

namespace RedEmpleoOffLine.View
{
    public partial class Window4 : Window
    {
        public Window4()
        {
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            DataContextChanged += new DependencyPropertyChangedEventHandler(Window4_DataContextChanged);
        }

        void Window4_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var dc = DataContext as IClosableViewModel;
            dc.CloseWindowEvent += new EventHandler(dc_CloseWindowEvent);
        }

        void dc_CloseWindowEvent(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
