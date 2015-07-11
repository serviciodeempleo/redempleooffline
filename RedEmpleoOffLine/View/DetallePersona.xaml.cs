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

namespace RedEmpleoOffLine.ViewModel
{
    public partial class DetallePersona : Window
    {
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

        public object MessageBoxButtons { get; private set; }

        public DetallePersona(string  NoIdentificacion)
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
            LebelUsuario.Content = Thread.CurrentPrincipal.Identity.Name;
            var personasedit = (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) select p).First();
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
            FechaNacimiento.Text = personasedit.FechaNacimiento.ToString();
            NoDocumento.Text = personasedit.NoDocumento;
            Departamento.Text = personasedit.Municipio.Departamento.nombre;
            Ciudad.Text = personasedit.Municipio.nombre;
            Direccion.Text = personasedit.Direccion;
            Barrio.Text = personasedit.Barrio;
            Telefono.Text = personasedit.Telefono;
            Celular.Text = personasedit.Celular;
            CorreoElectronico.Text = personasedit.CorreoElectronico;

            Model.Person person = new Model.Person();
            DataContext = person;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var win = new EditPersona(NoDocumento.Text) { DataContext = new ViewModelEditPersona(NoDocumento.Text) };
            win.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new MainWindow { DataContext = new ViewModelMain() };
            win.Show();
            this.Close();
        }

    }
}
