using System.Windows;
using System;
using System.Windows.Media.Imaging;
using RedEmpeloOffLine.ViewModel;
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
using RedEmpeloOffLine.Model;
using System.Data.Entity.Validation;

namespace RedEmpeloOffLine.ViewModel
{
    public partial class AgregarPersona : Window
    { 
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

        public object MessageBoxButtons { get; private set; }

        public AgregarPersona()
        {

            var departamentos = (from d in db.Departamento select d);
           // ListDepartamento.Items.Insert(0, "Seleccione Departamento");

            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
           
            InitializeComponent();
            ListDepartamento.Items.Insert(0, "Seleccione Departamento");
            foreach (var dr in departamentos)
            {
                ComboBoxItem var2 = new ComboBoxItem();
                var2.Tag = dr.IdCodigo;
                var2.Content = dr.nombre;
                ListDepartamento.Items.Add(var2);
            }
            ListDepartamento.SelectedItem = ListDepartamento.Items.GetItemAt(0);
            cargarmun();
        
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(PrimerNombre.Text)) { PrimerNombre.Text = ""; flag = true;  }
            if (string.IsNullOrEmpty(PrimerApellido.Text)) { PrimerApellido.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(NoDocumento.Text)) { NoDocumento.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(RepetirNoDocumento.Text)) {
                RepetirNoDocumento.Text = ""; flag = true;
                Thickness margin = RepetirNoDocumentoError.Margin;
                margin.Left = 228;
                RepetirNoDocumentoError.Margin = margin;
            }
            if (string.IsNullOrEmpty(Direccion.Text)) { Direccion.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(Telefono.Text)) { Telefono.Text = ""; flag = true;
                Thickness margin = TelefonoError.Margin;
                margin.Left = 778;
                TelefonoError.Margin = margin;
            }
            if (string.IsNullOrEmpty(Celular.Text)) { Celular.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(CorreoElectronico.Text)) { CorreoElectronico.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(CorreoElectronicoRepeat.Text)) { CorreoElectronicoRepeat.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(ContrasenaRepite.Text)) { ContrasenaRepite.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(Contrasena.Text)) { Contrasena.Text = ""; flag = true; }
            string sexo = "";
            if (!(Femenino.IsChecked.Value) && !Masculino.IsChecked.Value)    {
                Sexo.Visibility= Visibility.Visible;  flag = true;
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
            if (Ciudad.SelectedValue==null)
            {
                CiudadError.Visibility = Visibility.Visible; flag = true;
            }
            if (TipoDocumento.SelectedValue == null)
            {
                TipoDocumentoError.Visibility = Visibility.Visible; flag = true;
            }
            if (Contrasena.Text == null)
            {
                ContrasenaError.Visibility = Visibility.Visible; flag = true;
            }
            if (ContrasenaRepite.Text == null)
            {
                PasswordrepeatError.Visibility = Visibility.Visible; flag = true;
            }
            if (flag){
                NoDocumento.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
            else
            {
                var NextID = (from i in db.Personas.OrderByDescending(u => u.Id) select i.Id).FirstOrDefault();
                Personas personas = new Personas();
                personas.Id = NextID + 1;
                personas.PrimerNombre = PrimerNombre.Text;
                personas.SegundoNombre = SegundoNombre.Text;
                personas.PrimerApellido = PrimerApellido.Text;
                personas.SegundoApellido = SegundoApellido.Text;
                personas.Sexo = sexo;
                personas.TipoDocumento = ((ComboBoxItem)TipoDocumento.SelectedItem).Tag.ToString();
                personas.NoDocumento = NoDocumento.Text;
                personas.FechaNacimiento = FechaNacimiento.Text;
                personas.Usuario = NoDocumento.Text;
                personas.Contrasena = Contrasena.Text;
                personas.Departamento = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
                personas.Ciudad = ((ComboBoxItem)Ciudad.SelectedItem).Tag.ToString();
                personas.Direccion = Direccion.Text;
                personas.Barrio = Barrio.Text;
                personas.Telefono = Telefono.Text;
                personas.Celular = Celular.Text;
                personas.CorreoElectronico = CorreoElectronico.Text;
                personas.CentroEmpleo = "Cofrem";
                db.Personas.Add(personas);

                try
                {
                    db.SaveChanges();
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
        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            ContrasenaRepite.Text = ContrasenaRepiteCaja.Password;
            ContrasenaRepite.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
        void PasswordValidator(Object sender, RoutedEventArgs args)
        {
            Contrasena.Text = ContrasenaCaja.Password;
            Contrasena.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        private void TipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipoDocumentoError.Visibility = Visibility.Hidden;
        }
    }
}
