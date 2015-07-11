using System.Windows;
using RedEmpleoOffLine.ViewModel;
using System;
using System.Windows.Media.Imaging;
using System.Security.Principal;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Collections.Generic;
using RedEmpleoOffLine.Helpers;
using System.Data;
using System.Collections;
using RedEmpleoOffLine.Model;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Net;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace RedEmpleoOffLine.ViewModel
{
    public partial class MainWindow : Window
    {
        ListCollectionView CollectionViewList;
        DataTable DataTableFiltered;

        private readonly TimeSpan filterDelay = TimeSpan.FromMilliseconds(350);
        private DelayAction delayedAction;

        public MainWindow()
        {
            if (Thread.CurrentPrincipal.Identity.Name != "")
            {
                //if (!LLamarPantallaIngreso())
                //{
                //    Application.Current.Shutdown(-1);
                //}
            }
            InitializeComponent();
            string myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo.png";
            Uri iconUri = new Uri(myPath.Replace(@"\", @"/"));
            this.Icon = BitmapFrame.Create(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/logo_central.fw.png";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo.Source = new BitmapImage(iconUri);
            myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "img/bg_banderin.jpg";
            iconUri = new Uri(myPath.Replace(@"\", @"/"));
            Logo_back.Source = new BitmapImage(iconUri);
            LebelUsuario.Content = Thread.CurrentPrincipal.Identity.Name;
            //myPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "icons/user_edit.png";
            //iconUri = new Uri(myPath.Replace(@"\", @"/"));
            //var img = new Image { Width = 25, Height = 25 };
            //var bitmapImage = new BitmapImage(iconUri);
            //img.Source = bitmapImage;
            //img.SetValue(Grid.RowProperty, 1);
            //img.SetValue(Grid.ColumnProperty, 1);
            //GridPersonas.Children.Add(img);
            //List<MyDataObject> list = new List<MyDataObject>();
            //list.Add(new MyDataObject() { ImageFilePath = iconUri });
            //list.Add(new MyDataObject() { ImageFilePath = iconUri });
           // dataGrid1.ItemsSource = list;
            
        }

        public class MyDataObject
        {
            public Uri ImageFilePath { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new AgregarPersona { DataContext = new ViewModelAgregarPersona() };
            win.Show();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            var button = (FrameworkElement)sender;
            var row = (DataGridRow)button.Tag;
            var content = ((System.Data.DataRowView)(row.Item)).Row.ItemArray[4];
            string NoIdentificacion = content.ToString().Replace("CC", "");
            var win = new EditPersona(NoIdentificacion) { DataContext = new ViewModelEditPersona(NoIdentificacion) };
            win.Show();
            this.Close();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {

            var button = (FrameworkElement)sender;
            var row = (DataGridRow)button.Tag;
            var content = ((System.Data.DataRowView)(row.Item)).Row.ItemArray[4];
            string NoIdentificacion = content.ToString().Replace("CC", "");
            var win = new DetallePersona(NoIdentificacion) { DataContext = new ViewModelDetallePersona(NoIdentificacion) };
            win.Show();
            this.Close();
        }
        private bool LLamarPantallaIngreso()
        {

            View.Login Login = new View.Login();
            Login.ShowDialog();
            if (Login.Aceptado)
            {
                //  indicar  un usario Generico
                AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.UnauthenticatedPrincipal);
                // Crear  una  identidad  con el nombre de  usuario
                IIdentity usuario = new GenericIdentity(Login.Usuario.Text, "Database");
                //Crear  lista  roles
                String[] roles = { "Usuario", "Administrador" };
                // Crear  La   credencial
                GenericPrincipal credencial = new GenericPrincipal(usuario, roles);
                // Asignar e sta  credencial  a la  aplicacion
                System.Threading.Thread.CurrentPrincipal = credencial;


            }

            return Login.Aceptado;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridPersonas.ItemsSource = LoadDataGrid().DefaultView;
            DataGridPersonas.Columns[0].Visibility = System.Windows.Visibility.Hidden;
            DataGridPersonas.Columns[1].Visibility = System.Windows.Visibility.Hidden;
            DataGridPersonas.Columns[2].Visibility = System.Windows.Visibility.Hidden;
            SetEstadoColumn();
        }

        private DataTable LoadDataGrid()
        {
            DataTable dt = new DataTable();
            DataTableFiltered = new DataTable();
            RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();

            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Panel", typeof(string));
            dt.Columns.Add("Ver", typeof(string));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Identificación", typeof(string));
            dt.Columns.Add("Departamento", typeof(string));
            dt.Columns.Add("Municipio", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Celular", typeof(string));


            var personas = from p in db.Personas
                           select new { Estado= p.Estado , NombreCompleto = p.PrimerNombre + " " + p.SegundoNombre + " " + p.PrimerApellido + " " + p.SegundoApellido, Identificacion = p.TipoDocumento + p.NoDocumento, Dep = p.Municipio.Departamento.nombre , ciud = p.Municipio.nombre, Tel= p.Telefono, Cel= p.Celular, Edit= p.AllowEdit };
                           

            foreach (var p in personas)
            {
                dt.Rows.Add(p.Estado.ToString(), p.Edit.ToString(), "true", p.NombreCompleto, p.Identificacion, p.Dep, p.ciud, p.Tel, p.Cel);
            }
 
            DataTableFiltered.Columns.Add("Estado", typeof(string));
            DataTableFiltered.Columns.Add("Panel", typeof(string));
            DataTableFiltered.Columns.Add("Ver", typeof(string));
            DataTableFiltered.Columns.Add("Nombre Completo", typeof(string));
            DataTableFiltered.Columns.Add("Identificación", typeof(string));
            DataTableFiltered.Columns.Add("Departamento", typeof(string));
            DataTableFiltered.Columns.Add("Municipio", typeof(string));
            DataTableFiltered.Columns.Add("Telefono", typeof(string));
            DataTableFiltered.Columns.Add("Celular", typeof(string));

            
            List<List<string>> alist = new List<List<string>>();
            foreach (var p in personas)
            {
                List<string> list1 = new List<string>() { p.Estado.ToString(), p.Edit.ToString(), "true", p.NombreCompleto, p.Identificacion, p.Dep, p.ciud, p.Tel, p.Cel };
                alist.Add(list1);
            }

            IList results = (IList)alist;

            CollectionViewList = new ListCollectionView(results);

            return dt;
        }

        public bool ContainsIt(object value)
        {
            if (DataTableFiltered.Columns.Count > 1)
            {
                //There is more than 1 column in DataGrid
                List<string> DataGridRowList = (List<string>)value;
                foreach (object item in DataGridRowList)
                {
                    if (item != null)
                    {
                        if (item.ToString().ToLower().Contains(textBox1.Text.ToLower())) return true;
                    }
                }
            }
            else
            {
                //There is a single column in the DataGrid
                if (value.ToString().ToLower().Contains(textBox1.Text.ToLower())) return true;
            }
            return false;
        }

        public void FilterIt()
        {
            int count = 0;
            DataTableFiltered.Clear();
            DataGridPersonas.ItemsSource = null;

            foreach (List<string> row in CollectionViewList)
            {
                DataTableFiltered.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8]);
                count++;
            }

            DataGridPersonas.ItemsSource = DataTableFiltered.DefaultView;
            DataGridPersonas.Columns[3].Visibility = System.Windows.Visibility.Hidden;
            DataGridPersonas.Columns[4].Visibility = System.Windows.Visibility.Hidden;
            DataGridPersonas.Columns[5].Visibility = System.Windows.Visibility.Hidden;
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (CollectionViewList.CanFilter)
                {
                    CollectionViewList.Filter = new Predicate<object>(ContainsIt);

                    if (delayedAction == null)
                    {
                        delayedAction = DelayAction.Initialize(() => FilterIt());
                    }
                    delayedAction.Wait(filterDelay);
                }
                else
                {
                    CollectionViewList.Filter = null;
                }
            }
            else
            {
                CollectionViewList.Filter = null;
                FilterIt();
            }
        }

        public void SetEstadoColumn()
        {
            DataGridTemplateColumn EstadoColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = false }; ;
            EstadoColumn.Header = "Estado";
            EstadoColumn.CellTemplateSelector = new DataTemplateSelectorBase();
            DataGridPersonas.Columns.Insert(0, EstadoColumn);
            DataGridTemplateColumn PanelColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = false }; ;
            PanelColumn.Header = "Panel";
            PanelColumn.CellTemplateSelector = new DataTemplateSelectorPanel();
            DataGridPersonas.Columns.Insert(1, PanelColumn);
            DataGridTemplateColumn ViewColumn = new DataGridTemplateColumn { CanUserReorder = false, Width = 85, CanUserSort = false }; ;
            ViewColumn.Header = "Ver";
            ViewColumn.CellTemplateSelector = new DataTemplateSelectorView();
            DataGridPersonas.Columns.Insert(2, ViewColumn);
        }

        private void Sincronizar(object sender, RoutedEventArgs e)
        {
            RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();
            var Allpersonas = from p in db.Personas where p.Estado.Equals(null)
                              select new { Id = p.Id, PrimerNombre = p.PrimerNombre, SegundoNombre = p.SegundoNombre, PrimerApellido = p.PrimerApellido, SegundoApellido = p.SegundoApellido, Sexo = p.Sexo, TipoDocumento = p.TipoDocumento, NoDocumento = p.NoDocumento, FechaNacimiento = p.FechaNacimiento, Usuario = p.Usuario, Contrasena = p.Contrasena, Departamento = p.Departamento, Ciudad = p.Ciudad, Direccion = p.Direccion, Barrio = p.Barrio, Telefono = p.Telefono, Celular = p.Celular, CorreoElectronico = p.CorreoElectronico, CentroEmpleo = p.CentroEmpleo };


            string jsonContent = JsonConvert.SerializeObject(Allpersonas);

            jsonContent = Regex.Replace(jsonContent, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
            string url = "http://localhost:50012/api/redempleo/save/postPersonas";
            string respuesta = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream()) {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            string relustado = "";
            try {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                    relustado = response.ToString();
                }
            }
            catch (WebException ex) {
                MessageBox.Show("No hay conexion con el servidor: " + ex.ToString());
            }


        }
    }
}

