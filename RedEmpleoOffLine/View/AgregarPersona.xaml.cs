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
using System.Threading;
using System.Security.Principal;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Interactivity;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace RedEmpleoOffLine.ViewModel
{
    public partial class AgregarPersona : Window 
    {
        DispatcherTimer mIdle;
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();
        private const long cIdleSeconds = 15;
        public object MessageBoxButtons { get; private set; }

        public AgregarPersona(string Usuario, DispatcherTimer mIdlemain)
        {
            mIdle = mIdlemain;
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
            // Crear  una  identidad  con el nombre de  usuario
            IIdentity usuario = new GenericIdentity(Usuario, "Database");
            //Crear  lista  roles
            String[] roles = { "Usuario", "Administrador" };
            // Crear  La   credencial
            GenericPrincipal credencial = new GenericPrincipal(usuario, roles);
            // Asignar e sta  credencial  a la  aplicacion
            System.Threading.Thread.CurrentPrincipal = credencial;

            var departamentos = (from d in db.Departamento select d);
            // ListDepartamento.Items.Insert(0, "Seleccione Departamento");

            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            LebelUsuario.Content = Usuario;
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/bg_banderin.jpg";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo_back.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/arrow_left.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Volver.Source = new BitmapImage(iconUri);
            TipoDocumento.Items.Insert(0, "Seleccione tipo documento");
            TipoDocumento.SelectedItem = TipoDocumento.Items.GetItemAt(0);
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
        public bool Error { get; set; }


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
                cargarveredas();
            }
        }
        public void cargarveredas()
        {
            if (ListDepartamento.SelectedValue.ToString() != "Seleccione Departamento")
            {
                Vereda.Items.Clear();
                Vereda.Items.Add("");
                string departamenid = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
                string Ciudadid = departamenid + "001";
                var Veredas = (from m in db.Veredas where m.municipality_id.Contains(Ciudadid) select m);

                foreach (var dr in Veredas)
                {
                    ComboBoxItem var2 = new ComboBoxItem();
                    var2.Tag = dr.IdCodigo;
                    var2.Content = dr.nombre;
                    Vereda.Items.Add(var2);
                }
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

            }
            else
            {
                FechaNacimiento.Text = FechaNacimientodata.Text;
                DateTime dob;
                DateTimeFormatInfo info = new DateTimeFormatInfo();
                info.ShortDatePattern = "dd/MM/yy";
                bool valid = DateTime.TryParse(FechaNacimiento.Text, info, DateTimeStyles.None, out dob);
                if (valid)
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - dob.Year;
                    if (now < dob.AddYears(age)) age--;
                    if (now <= dob)
                    {
                        FechaNacimientoError.Text = "Fecha nacimiento no superar la actual.";
                        FechaNacimientoError.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        if (age < 15)
                        {
                            FechaNacimientoError.Text = "No se acepta el registro de menores de 15 años.";
                            FechaNacimientoError.Visibility = Visibility.Visible;
                             }
                        else
                        {
                            if (age > 99)
                            {
                                FechaNacimientoError.Text = "Fecha nacimiento no valida";
                                FechaNacimientoError.Visibility = Visibility.Visible;
                            }
                            else
                            {
                                FechaNacimientoError.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
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
            ((System.Windows.Controls.Control)sender).GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Usuario = Thread.CurrentPrincipal.Identity.Name;
            var win = new MainWindow() { DataContext = new ViewModelMain() };
            win.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;




            if (string.IsNullOrEmpty(PrimerNombre.Text)) { PrimerNombre.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(PrimerApellido.Text)) { PrimerApellido.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(NoDocumento.Text)) { NoDocumento.Text = ""; flag = true; }
            FechaNacimiento.Text = FechaNacimientodata.Text;
            if (string.IsNullOrEmpty(FechaNacimiento.Text)) { FechaNacimiento.Text = ""; flag = true; }
                DateTime dob;
                DateTimeFormatInfo info = new DateTimeFormatInfo();
                info.ShortDatePattern = "dd/MM/yy";
                bool valid = DateTime.TryParse(FechaNacimiento.Text, info, DateTimeStyles.None, out dob);
                if (valid)
                {
                    DateTime now = DateTime.Today;
                    int age = now.Year - dob.Year;
                    if (now <= dob)
                    {
                        FechaNacimientoError.Text = "Fecha nacimiento no superar la actual.";
                        FechaNacimientoError.Visibility = Visibility.Visible;
                        flag = true;
                    }
                    else
                    {
                        if (age < 15)
                        {
                            FechaNacimientoError.Text = "No se acepta el registro de menores de 15 años.";
                            FechaNacimientoError.Visibility = Visibility.Visible;
                            flag = true;
                        }
                        else
                        {
                            if (age > 99)
                            {
                                FechaNacimientoError.Text = "Fecha nacimiento no valida.";
                                FechaNacimientoError.Visibility = Visibility.Visible;
                                flag = true;
                            }
                            else
                            {
                                FechaNacimientoError.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                }
            if (string.IsNullOrEmpty(RepetirNoDocumento.Text))
            {
                RepetirNoDocumento.Text = ""; flag = true;
            }
            if (string.IsNullOrEmpty(Direccion.Text)) { Direccion.Text = ""; flag = true; }
            if (string.IsNullOrEmpty(Telefono.Text))
            {
                Telefono.Text = ""; flag = true;
            }
            if (string.IsNullOrEmpty(Celular.Text)) { Celular.Text = ""; flag = true; }
            //if (string.IsNullOrEmpty(CorreoElectronico.Text)) { CorreoElectronico.Text = ""; flag = true; }
            if (!string.IsNullOrEmpty(CorreoElectronico.Text))
            {
                if (string.IsNullOrEmpty(CorreoElectronicoRepeat.Text)) { CorreoElectronicoRepeat.Text = ""; flag = true; }
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(CorreoElectronico.Text);
                if (!match.Success)
                {
                    flag = true;
                }
                match = regex.Match(CorreoElectronicoRepeat.Text);
                if (!match.Success)
                {
                    flag = true;
                }

            }
            if (CorreoElectronicoRepeat.Text != CorreoElectronico.Text)
            {
                flag = true;

                CorreoElectronicoRepeat.Text = "";
            }
            if (!string.IsNullOrEmpty(CorreoElectronicoRepeat.Text) && string.IsNullOrEmpty(CorreoElectronico.Text)) { flag = true; }
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
            if ((TipoDocumento.SelectedItem).ToString() == "Seleccione tipo documento")
            {
                TipoDocumentoError.Visibility = Visibility.Visible; flag = true;
            }

            //if ( Person.ReferenceEquals(Error).Equals(true))
            if (PrimerNombre.Text.Length > 50) { flag = true; }
            if (SegundoNombre.Text.Length > 50) { flag = true; }
            if (PrimerApellido.Text.Length > 50) { flag = true; }
            if (SegundoApellido.Text.Length > 50) { flag = true; }
            if (NoDocumento.Text.Length > 50) { flag = true; }
            if (NoDocumento.Text.Length > 50) { flag = true; }
            if (NoDocumento.Text.Length > 50) { flag = true; }
            if (Direccion.Text.Length > 50) { flag = true; }
            if (Barrio.Text.Length > 50) { flag = true; }
            if (Telefono.Text.Length > 50) { flag = true; }
            if (Celular.Text.Length > 50) { flag = true; }
            if (CorreoElectronico.Text.Length > 50) { flag = true; }
            if (string.IsNullOrEmpty(Telefono.Text))
            {
                flag = true;
            }
            else
            {
                Regex regex = new Regex(@"^\d+$");
                if (!regex.IsMatch(Telefono.Text))
                {
                    flag = true;
                }
                if (Telefono.Text.ToString().Length != 7)
                {
                    flag = true;
                }
            }

            if (string.IsNullOrEmpty(Celular.Text))
            {
                flag = true;
            }
            else
            {
                Regex regex = new Regex(@"^\d+$");
                if (!regex.IsMatch(Celular.Text))
                {
                    flag = true;
                }
                if (Celular.Text.ToString().Length != 10)
                {
                    flag = true;
                }
            }

            if (flag)
            {
                NoDocumento.GetBindingExpression(System.Windows.Controls.TextBox.TextProperty).UpdateSource();
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
                personas.FechaNacimiento = DateTime.Parse(FechaNacimiento.Text); 
                personas.Usuario = NoDocumento.Text;
                personas.Contrasena = NoDocumento.Text;
                personas.Departamento = ((ComboBoxItem)ListDepartamento.SelectedItem).Tag.ToString();
                personas.Ciudad = ((ComboBoxItem)Ciudad.SelectedItem).Tag.ToString();
                if (Vereda.SelectedItem != null && Vereda.SelectedValue.ToString() != "")
                {
                    personas.Vereda = ((ComboBoxItem)Vereda.SelectedItem).Tag.ToString();
                }
                else {
                    personas.Vereda = "";
                }
                personas.Direccion = Direccion.Text;
                personas.Barrio = Barrio.Text;
                personas.Telefono = Telefono.Text;
                personas.Celular = Celular.Text;
                personas.CorreoElectronico = CorreoElectronico.Text;
                string Usuario = LebelUsuario.Content.ToString();
                string id_sede = (from u in db.UsuariosPuntos
                                  where u.Usuario.ToString().ToLower().Equals(Usuario.ToLower(), StringComparison.OrdinalIgnoreCase)
                                  select u.Id_sedeRedempleo).First().ToString();
                personas.CentroEmpleo = id_sede;
                personas.Estado = null ;
                personas.AllowEdit = true;
                personas.Fecha_Creacion = DateTime.Now;
                personas.Fecha_Modificacion = DateTime.Now;
                personas.Fecha_Sincronizacion = null;


                db.Personas.Add(personas);

                try
                {
                    db.SaveChanges();
                    var win = new MainWindow() { DataContext = new ViewModelMain() };
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
                    System.Windows.MessageBox.Show(exceptionMessage);
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
        }

        private void TipoDocumento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TipoDocumentoError.Visibility = Visibility.Hidden;
        }

        private void Femenino_Checked(object sender, RoutedEventArgs e)
        {
            Sexo.Visibility = Visibility.Hidden;
        }

        private void Masculino_Checked(object sender, RoutedEventArgs e)
        {
            Sexo.Visibility = Visibility.Hidden;
        }

        private void Documento_LostFocus(object sender, RoutedEventArgs e)
        {
            NoDocumentoPASS.Visibility = Visibility.Visible;
            NoDocumentoPASS.Password = NoDocumento.Text;
            NoDocumento.Visibility = Visibility.Hidden;
        }

        private void NoDocumentoPASS_GotFocus(object sender, RoutedEventArgs e)
        {
            NoDocumentoError.Visibility = Visibility.Hidden;
            NoDocumentoPASS.Visibility = Visibility.Hidden;
            NoDocumento.Visibility = Visibility.Visible;
            NoDocumentoPASS.Password = "";
            NoDocumento.Text = "";
            RepetirNoDocumento.Text = "";
            NoDocumento.Focus();
        }

        private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
                NoDocumentoError.Visibility = Visibility.Visible;
                NoDocumentoError.Text = "No  se permite copiar pegar o cortar";
            }
            else {
                NoDocumentoError.Visibility = Visibility.Hidden;
            }
        }

        private void RepetirNoDocumento_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NoDocumento.Text != RepetirNoDocumento.Text)
            {
                NoDocumento.Text = "";
                RepetirNoDocumento.Text = "";
                RepetirNoDocumentoError.Visibility = Visibility.Visible;
                RepetirNoDocumentoError.Text = "Numeros de documento no coinciden";
            }
        }

        private void CorreoElectronico_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
                CorreoElectronicoError.Visibility = Visibility.Visible;
                CorreoElectronicoError.Text = "No  se permite copiar pegar o cortar";
            }
            else {
               CorreoElectronicoError.Visibility = Visibility.Hidden;
            }
        }

        private void CorreoElectronico_LostFocus(object sender, RoutedEventArgs e)
        {
            CorreoElectronicoPASS.Visibility = Visibility.Visible;
            CorreoElectronicoPASS.Password = CorreoElectronico.Text;
            CorreoElectronico.Visibility = Visibility.Hidden;
            CorreoElectronicoError.Visibility = Visibility.Hidden;
        }

        private void CorreoElectronicoRepeat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CorreoElectronico.Text != CorreoElectronicoRepeat.Text)
            {
                System.Windows.MessageBox.Show("Los correos electrónico no coinciden");
                CorreoElectronico.Text = null;
                CorreoElectronicoPASS.Password = null;
            }
        }

        private void RepetirNoDocumento_GotFocus(object sender, RoutedEventArgs e)
        {
            CorreoElectronicoRepeatError.Visibility = Visibility.Hidden;
            CorreoElectronicoError.Visibility = Visibility.Hidden;
        }

        private void CorreoElectronicoPASS_GotFocus(object sender, RoutedEventArgs e)
        {
            CorreoElectronicoError.Visibility = Visibility.Hidden;
            CorreoElectronicoPASS.Visibility = Visibility.Hidden;
            CorreoElectronico.Visibility = Visibility.Visible;
            CorreoElectronicoRepeat.IsReadOnly = true;
            CorreoElectronico.Focus();
        }

        private void CorreoElectronico_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(CorreoElectronico.Text))
            {
                CorreoElectronico.Text = null;
            }

            CorreoElectronicoError.Visibility = Visibility.Hidden;
            CorreoElectronicoRepeat.Text = null;
        }

        private void NoDocumento_TextChanged(object sender, TextChangedEventArgs e)
        {
            NoDocumentoError.Visibility = Visibility.Hidden;
            RepetirNoDocumentoError.Visibility = Visibility.Hidden;
        }

        private void ListCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListDepartamento.SelectedValue.ToString() != "Seleccione Departamento")
            {
                Vereda.Items.Clear();
                Vereda.Items.Add("");
                if (Ciudad.SelectedItem != null)
                {
                    string Ciudadid = ((ComboBoxItem)Ciudad.SelectedItem).Tag.ToString();
                    var Veredas = (from m in db.Veredas where m.municipality_id.Contains(Ciudadid) select m);

                    foreach (var dr in Veredas)
                    {
                        ComboBoxItem var2 = new ComboBoxItem();
                        var2.Tag = dr.IdCodigo;
                        var2.Content = dr.nombre;
                        Vereda.Items.Add(var2);
                    }
                }

            }
        }

        private void CorreoElectronico_GotFocus(object sender, RoutedEventArgs e)
        {
            CorreoElectronicoRepeat.IsReadOnly = false;
            CorreoElectronicoRepeat.Text = null;
        }        
      
    }
}
