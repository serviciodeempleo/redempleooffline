using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace RedEmpleoOffLine.Helpers
{
    public class DataTemplateSelectorBase : DataTemplateSelector 
    {
        protected ViewModel.MainWindow GetMainWindow(DependencyObject inContainer)
        {
            DependencyObject c = inContainer;
            while (true)
            {
                DependencyObject p = VisualTreeHelper.GetParent(c);

                if (c is ViewModel.MainWindow)
                {
                    return c as ViewModel.MainWindow;
                }
                else
                {
                    c = p;
                }
            }
        }
         
        public override DataTemplate SelectTemplate(object inItem, DependencyObject inContainer)
        {
            DataRowView row = inItem as DataRowView;

            if (row != null)
            {
                if (row.DataView.Table.Columns.Contains("Estado"))
                {
                    ViewModel.MainWindow w = GetMainWindow(inContainer);
                    return (DataTemplate)w.FindResource("StatusImage");
                }
            }
            return null;
        }

    }


    public class DataTemplateSelectorPanel : DataTemplateSelector
    {
        protected ViewModel.MainWindow GetMainWindows(DependencyObject inContainer)
        {
            DependencyObject c = inContainer;
            while (true)
            {
                DependencyObject p = VisualTreeHelper.GetParent(c);

                if (c is ViewModel.MainWindow)
                {
                    return c as ViewModel.MainWindow;
                }
                else
                {
                    c = p;
                }
            }
        }

        public override DataTemplate SelectTemplate(object inItem, DependencyObject inContainer)
        {
            DataRowView row = inItem as DataRowView;

            if (row != null)
            {
                if (row.DataView.Table.Columns.Contains("Panel"))
                {
                    ViewModel.MainWindow w = GetMainWindows(inContainer);
                    return (DataTemplate)w.FindResource("PanelImage");
                }
            }
            return null;
        }

    }
    public class DataTemplateSelectorView : DataTemplateSelector
    {
        protected ViewModel.MainWindow GetMainWindows(DependencyObject inContainer)
        {
            DependencyObject c = inContainer;
            while (true)
            {
                DependencyObject p = VisualTreeHelper.GetParent(c);

                if (c is ViewModel.MainWindow)
                {
                    return c as ViewModel.MainWindow;
                }
                else
                {
                    c = p;
                }
            }
        }

        public override DataTemplate SelectTemplate(object inItem, DependencyObject inContainer)
        {
            DataRowView row = inItem as DataRowView;

            if (row != null)
            {
                if (row.DataView.Table.Columns.Contains("Ver"))
                {
                    ViewModel.MainWindow w = GetMainWindows(inContainer);
                    return (DataTemplate)w.FindResource("ViewImage");
                }
            }
            return null;
        }

    }
}
