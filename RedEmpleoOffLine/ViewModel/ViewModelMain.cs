using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using RedEmpleoOffLine.Model;
using RedEmpleoOffLine.Helpers;

namespace RedEmpleoOffLine.ViewModel
{
    class ViewModelMain : ViewModelBase
    {
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

        public ObservableCollection<ListPerson> People { get; set; }

        /// <summary>
        /// SelectedItem is an object instead of a Person, only because we are allowing "CanUserAddRows=true" 
        /// NewItemPlaceHolder represents a new row, and this is not the same as Person class
        /// 
        /// Change 'object' to 'Person', and you will see the following:
        /// 
        /// System.Windows.Data Error: 23 : Cannot convert '{NewItemPlaceholder}' from type 'NamedObject' to type 'RedEmpleoOffLine.Model.Person' for 'en-US' culture with default conversions; consider using Converter property of Binding. NotSupportedException:'System.NotSupportedException: TypeConverter cannot convert from MS.Internal.NamedObject.
        ///   at System.ComponentModel.TypeConverter.GetConvertFromException(Object value)
        ///   at System.ComponentModel.TypeConverter.ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
        ///   at MS.Internal.Data.DefaultValueConverter.ConvertHelper(Object o, Type destinationType, DependencyObject targetElement, CultureInfo culture, Boolean isForward)'
        ///System.Windows.Data Error: 7 : ConvertBack cannot convert value '{NewItemPlaceholder}' (type 'NamedObject'). BindingExpression:Path=SelectedPerson; DataItem='ViewModelMain' (HashCode=47403907); target element is 'DataGrid' (Name=''); target property is 'SelectedItem' (type 'Object') NotSupportedException:'System.NotSupportedException: TypeConverter cannot convert from MS.Internal.NamedObject.
        ///   at MS.Internal.Data.DefaultValueConverter.ConvertHelper(Object o, Type destinationType, DependencyObject targetElement, CultureInfo culture, Boolean isForward)
        ///   at MS.Internal.Data.ObjectTargetConverter.ConvertBack(Object o, Type type, Object parameter, CultureInfo culture)
        ///   at System.Windows.Data.BindingExpression.ConvertBackHelper(IValueConverter converter, Object value, Type sourceType, Object parameter, CultureInfo culture)'
        /// </summary>

        object _SelectedPerson;
        public object SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != value)
                {
                    _SelectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        public RelayCommand AddUserCommand { get; set; }

        public ViewModelMain()
        {
            var personas = db.Personas.Take(10).ToList();
            People = new ObservableCollection<ListPerson> { };

            foreach (var p in personas)
            {
                ListPerson listPerson = new ListPerson { Nombre = p.PrimerNombre, TipoDocumento = p.TipoDocumento, Documento = p.NoDocumento, Departamento = p.Departamento, Ciudad = p.Ciudad, Telefono = p.Telefono, Celular = p.Celular };
                People.Add(listPerson);
            }
            TextProperty1 = "Type here";

            AddUserCommand = new RelayCommand(AddUser);
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new ListPerson { Nombre = parameter.ToString(), TipoDocumento = parameter.ToString(), Documento = parameter.ToString(), Departamento = parameter.ToString(), Ciudad = parameter.ToString(), Telefono = parameter.ToString(), Celular = parameter.ToString() });
        }

        public class ListPerson
        {
            public string Nombre { get; set; }
            public string TipoDocumento { get; set; }
            public string Documento { get; set; }
            public string Departamento { get; set; }
            public string Ciudad { get; set; }
            public string Telefono { get; set; }
            public string Celular { get; set; }
        }
    }
}
