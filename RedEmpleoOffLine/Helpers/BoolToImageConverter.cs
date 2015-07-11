using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Data;
using System.Windows.Media.Imaging;
 
namespace RedEmpleoOffLine.Helpers
{
    public class BoolToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataRowView)
            {
                DataRowView row = value as DataRowView;

                if (row != null)
                {
                    
                    if (row.DataView.Table.Columns.Contains("Estado"))
                    {
                        Type type = row["Estado"].GetType();
                        string Estado = (string)row["Estado"];
                        if (Estado == "")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/flag_yellow.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                            
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (Estado == "True")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/flag_green.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (Estado == "False")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/flag_red.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataRowView)
            {
                DataRowView row = value as DataRowView;

                if (row != null)
                {
                    if (row.DataView.Table.Columns.Contains("Panel"))
                    {
                        Type type = row["Panel"].GetType();
                        string Panel = (string)row["Panel"];
                        if (Panel == "")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/user_edit.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));

                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (Panel == "True")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/user_edit.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        if (Panel == "False")
                        {
                            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/sync.png";
                            Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                    }
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
    public class ViewToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DataRowView)
            {
                DataRowView row = value as DataRowView;

                if (row != null)
                {
                    if (row.DataView.Table.Columns.Contains("Ver"))
                    {
                        Type type = row["Ver"].GetType();
                        string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/view.png";
                        Uri uri = new Uri(myPath.Replace(@"\", @"/"));
                        BitmapImage source = new BitmapImage(uri);
                        return source;
                    }
                }
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}
