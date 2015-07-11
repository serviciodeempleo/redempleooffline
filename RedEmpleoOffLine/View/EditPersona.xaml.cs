using System.Windows;
using System;
using System.Windows.Media.Imaging;
using RedEmpleoOffLine.ViewModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations;
using RedEmpleoOffLine.Model;
using System.Data.Entity.Validation;

namespace RedEmpleoOffLine.ViewModel
{
    public partial class EditPersona : Window
    {
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

        public object MessageBoxButtons { get; private set; }

        public EditPersona(string NoIdentificacion)
        {

            var departamentos = (from d in db.Departamento select d);
            // ListDepartamento.Items.Insert(0, "Seleccione Departamento");

            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/bg_banderin.jpg";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo_back.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/arrow_left.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Volver.Source = new BitmapImage(iconUri);

            var personasedit = (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) select p).First();
            Personas personas = new Personas();
            PrimerNombre.Text = personasedit.PrimerNombre;
            SegundoNombre.Text = personasedit.SegundoNombre;
            PrimerApellido.Text = personasedit.PrimerApellido;
            SegundoApellido.Text = personasedit.SegundoApellido;
            if (personasedit.Sexo == "F")
            {
                Femenino.IsChecked = true; 
            }
            else
            {
               Masculino.IsChecked = true; 
            }
            NoDocumento.Text = personasedit.NoDocumento;
            FechaNacimiento.Text = personasedit.FechaNacimiento.ToString();
            NoDocumento.Text = personasedit.NoDocumento;
            RepetirNoDocumento.Text = personasedit.NoDocumento;
            NoDocumentoPASS.Password = personasedit.NoDocumento;
           //Departamento
            foreach (var dr in departamentos)
            {
                ComboBoxItem var2 = new ComboBoxItem();
                var2.Tag = dr.IdCodigo;
                var2.Content = dr.nombre;
                ListDepartamento.Items.Add(var2);
                if(var2.Tag.Equals(personasedit.Departamento))
                {
                    ListDepartamento.SelectedItem = var2;
                }
           }
            //Municipio
            string departamenid = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
            var Municipios = (from m in db.Municipio where m.department_id.Contains(departamenid) select m);

            foreach (var dr in Municipios)
            {
                ComboBoxItem var2 = new ComboBoxItem();
                var2.Tag = dr.IdCodigo;
                var2.Content = dr.nombre;
                Ciudad.Items.Add(var2);
                if (var2.Tag.Equals(personasedit.Municipio))
                {
                    Ciudad.SelectedItem = var2;
                }
            }
            Direccion.Text = personasedit.Direccion;
            Barrio.Text = personasedit.Barrio;
            Telefono.Text = personasedit.Telefono;
            Celular.Text = personasedit.Celular;
            CorreoElectronico.Text = personasedit.CorreoElectronico;
            CorreoElectronicoRepeat.Text = personasedit.CorreoElectronico;

            foreach (ComboBoxItem item in TipoDocumento.Items)
              {
                  if(item.Tag.Equals(personasedit.TipoDocumento))
                  {
                      TipoDocumento.SelectedItem = item;
                  }
              }

            Model.Person person = new Model.Person();
            DataContext = person;
        }
        public void cargarmun()
        {
            Ciudad.Items.Clear();
            if (ListDepartamento.SelectedValue.ToString() != "Seleccione Departamento")
            {
                DepartamentoError.Visibility = Visibility.Hidden;
                CiudadError.Visibility = Visibility.Hidden;
                string departamenid = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
                var Municipios = (from m in db.Municipio where m.department_id.Contains(departamenid) select m);

                foreach (var dr in Municipios)
                {
                    ComboBoxItem var2 = new ComboBoxItem();
                    var2.Tag = dr.IdCodigo;
                    var2.Content = dr.nombre;
                    Ciudad.Items.Add(var2);

                }
                Ciudad.SelectedItem = Ciudad.Items.GetItemAt(0);
            }
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                //this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                //this.Title = date.Value.ToShortDateString();
            }
        }

        public void DocumentoTextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            NoDocumento.Visibility = Visibility.Hidden;
        }

        private void ListDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBoxResult result = MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            //if (result == MessageBoxResult.Yes)
            //{
            //    Application.Current.Shutdown();
            //}
            cargarmun();
        }
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((Control)sender).GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow { DataContext = new ViewModelMain() };
            win.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(PrimerNombre.Text)) { PrimerNombre.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(PrimerApellido.Text)) { PrimerApellido.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(NoDocumento.Text)) { NoDocumento.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(RepetirNoDocumento.Text))
            {
                RepetirNoDocumento.Text = ""; flag = true;
                Thickness margin = RepetirNoDocumentoError.Margin;
                margin.Left = 228;
                RepetirNoDocumentoError.Margin = margin;
            }
            if (string.IsNullOrEmpty(Direccion.Text)) { Direccion.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(Telefono.Text))
            {
                Telefono.Text = ""; flag = true;
                Thickness margin = TelefonoError.Margin;
                margin.Left = 778;
                TelefonoError.Margin = margin;
            }
            if (string.IsNullOrEmpty(Celular.Text)) { Celular.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(CorreoElectronico.Text)) { CorreoElectronico.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(CorreoElectronicoRepeat.Text)) { CorreoElectronicoRepeat.Text = ""; flag = true; }
            string sexo = "";
            if (!(Femenino.IsChecked.Value) && !Masculino.IsChecked.Value)
            {
                Sexo.Visibility = Visibility.Visible; flag = true;
            }
            else
            {
                if (Femenino.IsChecked.Value)
                    sexo = "F";
                if (Masculino.IsChecked.Value)
                    sexo = "M";
            }
            if (ListDepartamento.SelectedValue.ToString() == "Seleccione Departamento")
            {
                DepartamentoError.Visibility = Visibility.Visible; flag = true;
            }
            if (Ciudad.SelectedValue == null)
            {
                CiudadError.Visibility = Visibility.Visible; flag = true;
            }
            if (TipoDocumento.SelectedValue == null)
            {
                TipoDocumentoError.Visibility = Visibility.Visible; flag = true;
            }
            if (flag)
            {
                NoDocumento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            else
            {
                Int64 personaID = (from p in db.Personas where p.NoDocumento.Contains(NoDocumento.Text) select p.Id).First();
                Personas personas = db.Personas.Find(1);
                personas.PrimerNombre = PrimerNombre.Text;
                personas.SegundoNombre = SegundoNombre.Text;
                personas.PrimerApellido = PrimerApellido.Text;
                personas.SegundoApellido = SegundoApellido.Text;
                personas.Sexo = sexo;
                personas.TipoDocumento = ((ComboBoxItem)TipoDocumento.SelectedItem).Tag.ToString();
                personas.NoDocumento = NoDocumento.Text;
                personas.FechaNacimiento = DateTime.Parse(FechaNacimiento.Text);
                personas.Usuario = NoDocumento.Text;
                personas.Contrasena = NoDocumento.Text;
                personas.Departamento = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
                personas.Ciudad = ((ComboBoxItem)Ciudad.SelectedItem).Tag.ToString();
                personas.Direccion = Direccion.Text;
                personas.Barrio = Barrio.Text;
                personas.Telefono = Telefono.Text;
                personas.Celular = Celular.Text;
                personas.CorreoElectronico = CorreoElectronico.Text;
                personas.CentroEmpleo = "Cofrem";
                personas.Estado = null;
                personas.AllowEdit = true;
                personas.Fecha_Creacion = DateTime.Now;
                personas.Fecha_Modificacion = DateTime.Now;
                personas.Fecha_Sincronizacion = null;

                try
                {
                    db.Entry(personas).State = EntityState.Modified;
                    db.SaveChanges();
                    var win = new MainWindow { DataContext = new ViewModelMain() };
                    win.Show();
                    this.Close();
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                    MessageBox.Show(exceptionMessage);
                }
            }
        }

        void DocumentoHandler(Object sender, RoutedEventArgs args)
        {
            if (NoDocumentoPASS.Password != NoDocumento.Text)
            {
                NoDocumentoPASS.Visibility = Visibility.Hidden;
                NoDocumento.Visibility = Visibility.Visible;
            }

        }
        private void RepetirNoDocumento_TextChanged(object sender, TextChangedEventArgs e)
        {
            NoDocumentoPASS.Visibility = Visibility.Visible;
            NoDocumentoPASS.Password = NoDocumento.Text;
            NoDocumento.Visibility = Visibility.Hidden;
            Thickness margin = RepetirNoDocumentoError.Margin;
            margin.Left = 127;
            RepetirNoDocumentoError.Margin = margin;
        }

        private void TipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipoDocumentoError.Visibility = Visibility.Hidden;
        }
    }
}
