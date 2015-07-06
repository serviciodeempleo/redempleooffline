using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using RedEmpeloOffLine.Helpers;
using RedEmpeloOffLine.Model;
using RedEmpeloOffLine.View;

namespace RedEmpeloOffLine.ViewModel
{
    class ViewModelWindow4 : ViewModelBase, IClosableViewModel
    {
        public event EventHandler CloseWindowEvent;

        public List<PocoPerson> People { get; set; }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1"); //The fix
                }
            }
        }

        public object SelectedPerson { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand NextExampleCommand { get; set; }

        DispatcherTimer timer;

        public ViewModelWindow4()
        {
            People = new List<PocoPerson>
            {
                new PocoPerson { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new PocoPerson {Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new PocoPerson {Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
            };
            TextProperty1 = "This will now update";
            NextExampleCommand = new RelayCommand(NextExample);
            AddUserCommand = new RelayCommand(AddUser);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new PocoPerson { Id = "ff", PrimerNombre = "ff", SegundoNombre = "ff", PrimerApellido = "ff", SegundoApellido = "ff", Sexo = "ff", TipoDocumento = "ff", NoDocumento = "ff", RepetirNoDocumento = "ff", FechaNacimiento = "ff", Usuario = "ff", Contrasena = "ff", Departamento = "ff", Ciudad = "ff", Direccion = "ff", Barrio = "ff", Telefono = "ff", Celular = "ff", CorreoElectronico = "ff", CorreoElectronicoRepeat = "ff", CentroEmpleo = "ff" });
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //This simulates something happening in the background
            //These changes are NOT reflected in the UI
            //For these changes to show, you need INotifyPropertyChanged or DependencyProperty
            TextProperty1 = DateTime.Now.ToString();
        }

        void NextExample(object parameter)
        {
            var win = new Window5 { DataContext = new ViewModelWindow5() };
            win.Show();

            if (CloseWindowEvent != null)
                CloseWindowEvent(this, null);
        }
    }
}
