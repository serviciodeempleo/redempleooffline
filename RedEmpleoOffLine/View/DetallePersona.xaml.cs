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
using System.Windows.Threading;

namespace RedEmpleoOffLine.ViewModel
{
    public partial class DetallePersona : Window
    {
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

        public object MessageBoxButtons { get; private set; }
 
        public DetallePersona(string NoIdentificacion, string Usuario)
        {
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
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/bg_banderin.jpg";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo_back.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/arrow_left.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Volver.Source = new BitmapImage(iconUri);
            LebelUsuario.Content = Thread.CurrentPrincipal.Identity.Name;
            string tipodoc = NoIdentificacion.ToString().Substring(0, 2);
            NoIdentificacion = NoIdentificacion.ToString().Replace("CC", "").Replace("TI", "").Replace("CE", "").Replace("PA", "");
            var personasedit = (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) && p.TipoDocumento.Equals(tipodoc) select p).First();
            var UsuarioSync=  (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) select p.Estado).FirstOrDefault() ;
            if (UsuarioSync != null)
            {
                Editar.Visibility = Visibility.Hidden;
            }
            Personas personas = new Personas();
            PrimerNombre.Text = personasedit.PrimerNombre;
            SegundoNombre.Text = personasedit.SegundoNombre;
            PrimerApellido.Text = personasedit.PrimerApellido;
            SegundoApellido.Text = personasedit.SegundoApellido;
            if  (personasedit.Sexo == "M")
            {
                Sexo.Text = "Masculino";
            }
            else {
                Sexo.Text = "Femenino";
            }
            TipoDocumento.Text = personasedit.TipoDocumento;
            NoDocumento.Text = personasedit.NoDocumento;
            FechaNacimiento.Text = personasedit.FechaNacimiento.ToString("dd/MM/yyyy");
            NoDocumento.Text = personasedit.NoDocumento;
            Departamento.Text = personasedit.Municipio.Departamento.nombre;
            Ciudad.Text = personasedit.Municipio.nombre;
            Direccion.Text = personasedit.Direccion;
            Barrio.Text = personasedit.Barrio;
            Telefono.Text = personasedit.Telefono;
            Celular.Text = personasedit.Celular;
            CorreoElectronico.Text = personasedit.CorreoElectronico;
            Fecha_Creacion.Text = "    " + personasedit.Fecha_Creacion.ToString();
            Fecha_Modificacion.Text = "    " + personasedit.Fecha_Modificacion.ToString();
            Fecha_Sincronizacion.Text = "    " + personasedit.Fecha_Sincronizacion.ToString();
            if(personasedit.Estado==true){
                Estado.Text = "    Sincronizado con Exito";
                Detalle.Text = "Oferente registrado en el Servicio Público de Empleo";
            }else{
                if (personasedit.Estado == null)
                {
                    Estado.Text = "    Sin sincronizar";
                    Detalle.Text = "Ofrente pendiente por sincronizar";
                }
                else {
                    if (personasedit.UsuarioValido == false)
                    {
                        Estado.Text = "    Usuario ya existe";
                        Detalle.Text = personasedit.Respuesta;
                    }
                    else {
                        Estado.Text = "    Oferente ya registrado";
                        Detalle.Text = personasedit.Respuesta;
                    }

                }
            }
            Detalle.TextWrapping = TextWrapping.Wrap;
            Model.Person person = new Model.Person();
            DataContext = person;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Usuario = Thread.CurrentPrincipal.Identity.Name;
            string NoDocument = NoDocumento.Text;
            Thread thread = new Thread(() =>
            {
                var win = new EditPersona(NoDocument, Usuario) { DataContext = new ViewModelEditPersona(NoDocument) };
                win.Show();
                win.Closed += (sender1, e1) => win.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();
                CloseWindow();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }
        private void CloseWindow()
        {
            //my serries of operation will come here.
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {

            }), DispatcherPriority.Normal,null);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Usuario = Thread.CurrentPrincipal.Identity.Name;
            var win = new MainWindow() { DataContext = new ViewModelMain() };
            win.Show();
            this.Close();
        }

    }
}
