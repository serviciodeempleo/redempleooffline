using System.Windows;
using RedEmpeloOffLine.ViewModel;
using System;
using System.Windows.Media.Imaging;
using System.Security.Principal;
using System.Threading;
namespace RedEmpeloOffLine.ViewModel
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            //if (!LLamarPantallaIngreso()) {
            //    Application.Current.Shutdown(-1);
            //}

            InitializeComponent();
            //LebelUsuario.Content = Thread.CurrentPrincipal.Identity.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new AgregarPersona { DataContext = new ViewModelAgregarPersona(tb1.Text) };
            win.Show();
            this.Close();
        }
        private bool LLamarPantallaIngreso() {
            View.Login Login = new View.Login();
            Login.ShowDialog();
            if (Login.Aceptado) {
                //  indicar  un usario Generico
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
                // Crear  una  identidad  con el nombre de  usuario
                IIdentity usuario = new GenericIdentity(Login.Usuario.Text, "Database");
                //Crear  lista  roles
                String[] roles = { "Usuario", "Administrador"};
                // Crear  La   credencial
                GenericPrincipal credencial = new GenericPrincipal(usuario , roles);
                // Asignar e sta  credencial  a la  aplicacion
                System.Threading.Thread.CurrentPrincipal = credencial;
                

            }

            return Login.Aceptado;
        }
    }
}
