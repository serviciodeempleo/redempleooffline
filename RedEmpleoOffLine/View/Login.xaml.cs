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
using System.Windows.Automation.Peers;
using System.Windows.Automation.Providers;
using System.Globalization;
using System.Data.Entity;

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
            Usuario.Focus();
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
        }

        private void IniciarSession_Click(object sender, RoutedEventArgs e)
        {
            Aceptado = false;
            if(!string.IsNullOrEmpty(Usuario.Text)){
                var ExisteUsuario = (from u in db.UsuariosPuntos where u.Usuario.ToLower().Equals(Usuario.Text.ToLower()) select u.Id).ToList();
                
                //if (!string.IsNullOrEmpty(FechaInicio.Text))
                //{
                    if (ExisteUsuario.Count == 1)
                    {
                        UsuariosPuntos UsuarioSesion = db.UsuariosPuntos.Find(ExisteUsuario[0]);
                        string password = (from u in db.UsuariosPuntos where u.Usuario.ToLower().Equals(Usuario.Text.ToLower()) select u.Password).FirstOrDefault();
                        if (Contrasena.Password.Equals(password))
                        {
                            //if (UsuarioSesion.FechaIngreso <= DateTime.Parse(FechaInicio.Text))
                            //{
                                UsuarioSesion.FechaIngreso = DateTime.Now.Date;
                                db.Entry(UsuarioSesion).State = EntityState.Modified;
                                db.SaveChanges();
                                Aceptado = true;
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Fecha ingresada debe ser al del día  de hoy");
                            //}
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
                //}
                //else
                //{
                //    MessageBox.Show("Fecha inicio sesión no ingresada");
                //}
            }
            else
            {
                MessageBox.Show("Campo usuario es obligatorio");
            }    
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class SubmitTextBox : TextBox
        {
            public SubmitTextBox()
                : base()
            {
                PreviewKeyDown += new KeyEventHandler(SubmitTextBox_PreviewKeyDown);
            }

            void SubmitTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    BindingExpression be = GetBindingExpression(TextBox.TextProperty);
                    if (be != null)
                    {
                        be.UpdateSource();
                    }
                }
            }
        }

        private void Contrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                   IniciarSession.Focus();
                   //ButtonAutomationPeer peer = new ButtonAutomationPeer(IniciarSession);

                   //IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;

                   //invokeProv.Invoke();
            }
        }

        private void Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Contrasena.Focus();
            }
        }

        //private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    FechaInicioError.Visibility = Visibility.Hidden;
        //    // ... Get DatePicker reference.
        //    var picker = sender as DatePicker;

        //    // ... Get nullable DateTime from SelectedDate.
        //    DateTime? date = picker.SelectedDate;
        //    if (date == null)
        //    {
        //        FechaInicioError.Text = "Fecha no es valida";
        //        FechaInicioError.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        DateTime dob;
        //        DateTimeFormatInfo info = new DateTimeFormatInfo();
        //        info.ShortDatePattern = "dd/MM/yy";
        //        bool valid = DateTime.TryParse(date.ToString(), info, DateTimeStyles.None, out dob);
        //        if (valid)
        //        {
                    
        //            DateTime now = DateTime.Today;
        //            if (!(now == dob)) {
        //                FechaInicioError.Text = "La fecha del sistema coincide con la ingresada";
        //                FechaInicioError.Visibility = Visibility.Visible;
        //            }
                   
        //        }
        //        else
        //        {
        //            FechaInicioError.Text = "Fecha no es valida";
        //            FechaInicioError.Visibility = Visibility.Visible;
        //        }
        //    }
        //}

    }
}
