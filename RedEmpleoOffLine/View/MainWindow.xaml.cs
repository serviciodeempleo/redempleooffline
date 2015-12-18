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
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Security;
using Newtonsoft.Json.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Windows.Threading;
using System.Windows.Input;
using System.Globalization;


namespace RedEmpleoOffLine.ViewModel
{
    public partial class MainWindow : Window
    {
        ListCollectionView CollectionViewList;
        DataTable DataTableFiltered;
        DispatcherTimer mIdle;
        private const long cIdleSeconds =3600;
        private readonly TimeSpan filterDelay = TimeSpan.FromMilliseconds(350);
        private DelayAction delayedAction;

        public MainWindow()
        {

            if (Thread.CurrentPrincipal.Identity.Name == "")
            {
                if (!LLamarPantallaIngreso())
                {
                    Application.Current.Shutdown(-1);
                    Thread thread = Thread.CurrentThread;
                    this.DataContext = new
                    {
                        ThreadId = thread.ManagedThreadId
                    };
                }
            }
            InitializeComponent();
            InputManager.Current.PreProcessInput += Idle_PreProcessInput;
            mIdle = new DispatcherTimer();
            mIdle.Interval = new TimeSpan(cIdleSeconds * 1000 * 10000);
            mIdle.IsEnabled = true;
            mIdle.Tick += Idle_Tick;
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
        void Idle_Tick(object sender, EventArgs e)
        {
            Application.Current.Shutdown(-1);
            Thread thread = Thread.CurrentThread;
            this.DataContext = new
            {
                ThreadId = thread.ManagedThreadId
            };
            thread.Interrupt();
            this.Close();
        }

        void Idle_PreProcessInput(object sender, PreProcessInputEventArgs e)
        {
            mIdle.IsEnabled = false;
            mIdle.IsEnabled = true;
        }


        public class MyDataObject
        {
            public Uri ImageFilePath { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Usuario = LebelUsuario.Content.ToString();
            
            Thread thread = new Thread(() =>
            {
                var win = new AgregarPersona(Usuario, mIdle) { DataContext = new ViewModelAgregarPersona() };
                
                win.Show();
                win.Closed += (sender1, e1) => win.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();
                RefrescarDatagrid();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RedEmpleoOffLineEntities db = new RedEmpleoOffLineEntities();
            var button = (FrameworkElement)sender;
            var row = (DataGridRow)button.Tag;
            var content = ((System.Data.DataRowView)(row.Item)).Row.ItemArray[4];
            string tipodoc = content.ToString().Substring(0, 2);
            string NoIdentificacion = content.ToString().Replace("CC", "").Replace("TI", "").Replace("CE", "").Replace("PA", "");
            var AllowEdit = (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) && p.TipoDocumento.Equals(tipodoc) select p.AllowEdit).FirstOrDefault();
            if (!AllowEdit == false)
            {
                var UsuarioExistente = (from p in db.Personas where p.NoDocumento.Equals(NoIdentificacion) select p.UsuarioValido).FirstOrDefault();

                string Usuario = LebelUsuario.Content.ToString();
                Thread thread = new Thread(() =>
                {
                    var win = new EditPersona(content.ToString(), Usuario) { DataContext = new ViewModelEditPersona(NoIdentificacion) };
                    win.Show();
                    win.Closed += (sender1, e1) => win.Dispatcher.InvokeShutdown();
                    System.Windows.Threading.Dispatcher.Run();
                    RefrescarDatagrid();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();

                this.Visibility = Visibility.Collapsed;
            }
            else {
              MessageBox.Show("Oferente Sincronizado");
             }
        }
        private void RefrescarDatagrid()
        {
            //my serries of operation will come here.
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                DataGridPersonas.ItemsSource = LoadDataGrid().DefaultView;
                this.Visibility = Visibility.Visible;
                DataGridPersonas.Columns[3].Visibility = System.Windows.Visibility.Hidden;
                DataGridPersonas.Columns[4].Visibility = System.Windows.Visibility.Hidden;
                DataGridPersonas.Columns[5].Visibility = System.Windows.Visibility.Hidden;
            }));
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            string Usuario = LebelUsuario.Content.ToString();
            var button = (FrameworkElement)sender;
            var row = (DataGridRow)button.Tag;
            var content = ((System.Data.DataRowView)(row.Item)).Row.ItemArray[4];
            string NoIdentificacion = content.ToString();
           
                Thread thread = new Thread(() =>
            {
                var win = new DetallePersona(NoIdentificacion, Usuario) { DataContext = new ViewModelDetallePersona(NoIdentificacion) };
                win.Show();
                win.Closed += (sender1, e1) => win.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();
                RefrescarDatagrid();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.IsBackground = true;
            thread.Start();
            this.Visibility = Visibility.Collapsed;
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
            dt.Columns.Add("Editar", typeof(string));
            dt.Columns.Add("Ver", typeof(string));
            dt.Columns.Add("Nombre Completo", typeof(string));
            dt.Columns.Add("Identificación", typeof(string));
            dt.Columns.Add("Departamento", typeof(string));
            dt.Columns.Add("Municipio", typeof(string));
            dt.Columns.Add("Vereda", typeof(string));
            dt.Columns.Add("Teléfono", typeof(string));
            dt.Columns.Add("Celular", typeof(string));


            var personas = from p in db.Personas.OrderByDescending(x=>x.Fecha_Modificacion )
                           select new { Estado= p.Estado , NombreCompleto = p.PrimerNombre + " " + p.SegundoNombre + " " + p.PrimerApellido + " " + p.SegundoApellido, Identificacion = p.TipoDocumento + p.NoDocumento, Dep = p.Municipio.Departamento.nombre , ciud = p.Municipio.nombre, vere = p.Vereda, Tel= p.Telefono, Cel= p.Celular, Edit= p.AllowEdit };
                           

            foreach (var p in personas)
            {
                string Vereda = (from v in db.Veredas where v.IdCodigo.Contains(p.vere) select v.nombre).FirstOrDefault();
                dt.Rows.Add(p.Estado.ToString(), p.Edit.ToString(), "true", p.NombreCompleto, p.Identificacion, p.Dep, p.ciud, Vereda, p.Tel, p.Cel);
            }
 
            DataTableFiltered.Columns.Add("Estado", typeof(string));
            DataTableFiltered.Columns.Add("Editar", typeof(string));
            DataTableFiltered.Columns.Add("Ver", typeof(string));
            DataTableFiltered.Columns.Add("Nombre Completo", typeof(string));
            DataTableFiltered.Columns.Add("Identificación", typeof(string));
            DataTableFiltered.Columns.Add("Departamento", typeof(string));
            DataTableFiltered.Columns.Add("Municipio", typeof(string));
            DataTableFiltered.Columns.Add("Vereda", typeof(string));
            DataTableFiltered.Columns.Add("Teléfono", typeof(string));
            DataTableFiltered.Columns.Add("Celular", typeof(string));

            
            List<List<string>> alist = new List<List<string>>();
            foreach (var p in personas)
            {
                string Vereda = (from v in db.Veredas where v.IdCodigo.Contains(p.vere) select v.nombre).FirstOrDefault();
                List<string> list1 = new List<string>() { p.Estado.ToString(), p.Edit.ToString(), "true", p.NombreCompleto, p.Identificacion, p.Dep, p.ciud, Vereda, p.Tel, p.Cel };
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
                DataTableFiltered.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7], row[8], row[8]);
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
            PanelColumn.Header = "Editar";
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
            string Usuario = LebelUsuario.Content.ToString();
            string UsurioUtente = (from u in db.UsuariosPuntos
                              where u.Usuario.ToString().ToLower().Equals(Usuario.ToLower(), StringComparison.OrdinalIgnoreCase)
                              select u.Redempleo_UTENTE).First().ToString();

            var Allpersonas = (from p in db.Personas where p.Estado.Equals(null)
                              select new { Id = p.Id, PrimerNombre = p.PrimerNombre, SegundoNombre = p.SegundoNombre, PrimerApellido = p.PrimerApellido, SegundoApellido = p.SegundoApellido, Sexo = p.Sexo, TipoDocumento = p.TipoDocumento, NoDocumento = p.NoDocumento, FechaNacimiento = p.FechaNacimiento, Usuario = p.Usuario, Contrasena = p.Contrasena, Departamento = p.Departamento, Ciudad = p.Ciudad, Direccion = p.Direccion, Barrio = p.Barrio, Telefono = p.Telefono, Celular = p.Celular, CorreoElectronico = p.CorreoElectronico, CentroEmpleo = p.CentroEmpleo,Fecha_Creacion = p.Fecha_Creacion, Redempleo_UTENTE = UsurioUtente }).ToList();
            List<Listado> Listlistado = new List<Listado>();
            foreach (var per in Allpersonas)
            {
                Listado listado = new Listado();
                listado.Id = Convert.ToInt64(per.Id);
                listado.PrimerNombre = per.PrimerNombre;
                listado.SegundoNombre = per.SegundoNombre;
                listado.PrimerApellido = per.PrimerApellido;
                listado.SegundoApellido = per.SegundoApellido;
                listado.Sexo = per.Sexo;
                listado.TipoDocumento = per.TipoDocumento;
                listado.NoDocumento = per.NoDocumento;
                listado.FechaNacimiento = per.FechaNacimiento.ToString("yyyy-MM-dd hh:mm:ss");
                listado.Usuario = per.Usuario;
                listado.Contrasena = per.Contrasena;
                listado.Departamento = per.Departamento;
                listado.Ciudad = per.Ciudad;
                listado.Direccion = per.Direccion;
                listado.Barrio = per.Barrio;
                listado.Telefono = per.Telefono;
                listado.Celular = per.Celular;
                listado.CorreoElectronico = per.CorreoElectronico;
                listado.CentroEmpleo = per.CentroEmpleo;
                listado.Fecha_Creacion = per.Fecha_Creacion.ToString("yyyy-MM-dd hh:mm:ss");
                listado.Redempleo_UTENTE = per.Redempleo_UTENTE;
                Listlistado.Add(listado);
            }

            UsuariosPuntos Auth = (from u in db.UsuariosPuntos
                                   where u.Usuario.ToString().ToLower().Equals(Usuario.ToLower(), StringComparison.OrdinalIgnoreCase)
                                   select u).FirstOrDefault();
            DataSync dataSync = new DataSync();
            dataSync.listado = Listlistado;
            dataSync.usuariosPuntos = Auth;

            string jsonContent = JsonConvert.SerializeObject(dataSync);

            jsonContent = Regex.Replace(jsonContent, "(\"(?:[^\"\\\\]|\\\\.)*\")|\\s+", "$1");
            //string url = "http://serviciodeempleo.gov.co:9095/api/redempleo/save/postPersonas";
            //string url = "http://ivandarioperill/RedEmpleoII/api/redempleo/save/postPersonas";
            string url = "http://localhost:50012/api/redempleo/save/postPersonas";
       
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
           // request.Timeout = -1;
            request.Method = "POST";

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);

            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";
            Mensage relustado = null;
            bool conexion= false;
            try
            {
                using (Stream dataStream = request.GetRequestStream()) {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                    //relustado = response.ToString();
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                       // var jobj = (JObject)JsonConvert.DeserializeObject(text);
                        relustado = JsonConvert.DeserializeObject<Mensage>(text);
                        conexion = true;
                    }
                }
            }
            catch (WebException ex) {
                MessageBox.Show("No hay conexion con el servidor: " + ex.Status +" ");
            }
            if (conexion)
            {
                if (relustado != null)
                {
                    foreach (ResultadoCollection resultadoCollection in relustado.resultadoCollection)
                    {
                        Personas persona = db.Personas.Find(resultadoCollection.PersonasOffline_Id);
                        persona.Fecha_Sincronizacion = DateTime.ParseExact(resultadoCollection.FechaSincronizacion, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture);
                        //sincronisacion exitosa
                        if (resultadoCollection.SyncOK)
                        {
                            persona.AllowEdit = false;
                            persona.Estado = true;
                        }
                        // Error Al  guardar
                        if (resultadoCollection.ErrorGuardar)
                        {
                            persona.Estado = false;
                            persona.AllowEdit = true;
                        }
                        //Persona Existe
                        if (resultadoCollection.personaexiste)
                        {
                            persona.Estado = false;
                            persona.AllowEdit = true;
                        }
                        //Conbinacion TipoDoc NoDocumento Existe
                        if (resultadoCollection.TipoDocDocumentoexiste)
                        {
                            persona.Estado = false;
                            persona.AllowEdit = true;
                        }
                        //Usuario Existe
                        if (resultadoCollection.usuarioexiste)
                        {
                            persona.Estado = false;
                            persona.AllowEdit = true;
                            persona.UsuarioValido = true;
                        }
                        persona.Respuesta = resultadoCollection.Respuesta;
                        persona.RedEmpleoID = resultadoCollection.Redempleo_Id;
                        try
                        {
                            db.Entry(persona).State = EntityState.Modified;
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
                    int oferentesSincronizados = (from o in relustado.resultadoCollection where o.SyncOK.Equals(true) select o.PersonasOffline_Id).ToList().Count();
                    int oferentesEsistentes = (from o in relustado.resultadoCollection where o.personaexiste.Equals(true) || o.TipoDocDocumentoexiste.Equals(true) select o.PersonasOffline_Id).ToList().Count();
                    int oferentesUsuarioExistente = (from o in relustado.resultadoCollection where o.usuarioexiste.Equals(true) select o.PersonasOffline_Id).ToList().Count();
                    MessageBox.Show("Sincronizacíon completa:\nTotal oferentes enviados => " + Listlistado.Count().ToString()
                        + "\nTotal oferentes procesados => " + relustado.resultadoCollection.Count().ToString()
                        + "\nTotal oferentes sincronizados => " + oferentesSincronizados.ToString()
                        + "\nTotal oferentes ya registrados => " + oferentesEsistentes.ToString()
                        + "\nTotal oferentes con usuario  existente => " + oferentesUsuarioExistente.ToString());
                    RefrescarDatagrid();
                }
                else
                {
                    MessageBox.Show("El no hay registros para sincronizar");
                }
            }
            else
            {
              //  MessageBox.Show("El no hay  registros para sincronizar");
            }
        }

        public class DataSync
        {
            public List<Listado> listado { get; set; }
            public UsuariosPuntos usuariosPuntos { get; set; }
        }
        public class Listado {
            public long Id { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string Sexo { get; set; }
            public string TipoDocumento { get; set; }
            public string NoDocumento { get; set; }
            public string FechaNacimiento { get; set; }
            public string Usuario { get; set; }
            public string Contrasena { get; set; }
            public string Departamento { get; set; }
            public string Ciudad { get; set; }
            public string Direccion { get; set; }
            public string Barrio { get; set; }
            public string Telefono { get; set; }
            public string Celular { get; set; }
            public string CorreoElectronico { get; set; }
            public string CentroEmpleo { get; set; }
            public string Redempleo_UTENTE { get; set; }
            public string Fecha_Creacion { get; set; }
        }
        public partial class ResultadoCollection
        {
            public long Redempleo_Id { get; set; }
            public long PersonasOffline_Id { get; set; }
            public bool SyncOK { get; set; }
            public bool ErrorGuardar { get; set; }
            public string Respuesta { get; set; }
            public string FechaSincronizacion { get; set; }
            public bool TipoDocDocumentoexiste { get; set; }
            public bool usuarioexiste { get; set; }
            public bool personaexiste { get; set; }
        }
        public partial class AuthCollection
        {
            public bool Autenticado { get; set; }
            public bool Activo { get; set; }
            public bool ExisteUsurioCentro { get; set; }
        }
        public class Mensage
        {
            public List<ResultadoCollection> resultadoCollection { get; set; }
            public AuthCollection authCollection { get; set; }
        }
    }
}

