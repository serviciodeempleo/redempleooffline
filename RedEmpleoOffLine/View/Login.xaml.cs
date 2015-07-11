using System;
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
using RedEmpleoOffLine.Model;

namespace RedEmpleoOffLine.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();
        public bool Aceptado;
        public Login()
        {

            string myPathico = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPathico.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            InitializeComponent();
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
        }

        private void IniciarSession_Click(object sender, RoutedEventArgs e)
        {
            Aceptado = false;
            var ExisteUsuario = (from u in db.UsuariosPuntos where u.Usuario.ToLower().Contains(Usuario.Text.ToLower()) select u.Id).ToList();
            if (ExisteUsuario.Count == 1)
            {
                string password = (from u in db.UsuariosPuntos where u.Usuario.ToLower().Contains(Usuario.Text.ToLower()) select u.Password).FirstOrDefault();
                if (Contrasena.Password.Equals(password))
                {
                    Aceptado = true;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }

                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Usuario no existe");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
