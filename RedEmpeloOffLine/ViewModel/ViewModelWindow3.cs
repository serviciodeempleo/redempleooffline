using System;
using System.Windows.Threading;
using System.Collections.Generic;
using RedEmpeloOffLine.Model;
using RedEmpeloOffLine.Helpers;
using RedEmpeloOffLine.View;

namespace RedEmpeloOffLine.ViewModel
{
    class ViewModelWindow3
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
                }
            }
        }

        public object SelectedPerson { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand NextExampleCommand { get; set; }

        DispatcherTimer timer;

        public ViewModelWindow3(Person person)
        {
            People = new List<PocoPerson>
            {
                new PocoPerson{  Id=person.Id,  PrimerNombre=person.PrimerNombre,  SegundoNombre=person.SegundoNombre,  PrimerApellido=person.PrimerApellido,  SegundoApellido=person.SegundoApellido,  Sexo=person.Sexo,  TipoDocumento=person.TipoDocumento,  NoDocumento=person.NoDocumento,  RepetirNoDocumento=person.RepetirNoDocumento,  FechaNacimiento=person.FechaNacimiento,  Usuario=person.Usuario,  Contrasena=person.Contrasena,  Departamento=person.Departamento,  Ciudad=person.Ciudad,  Direccion=person.Direccion,  Barrio=person.Barrio,  Telefono=person.Telefono,  Celular=person.Celular,  CorreoElectronico=person.CorreoElectronico,  CorreoElectronicoRepeat=person.CorreoElectronicoRepeat,  CentroEmpleo=person.CentroEmpleo },
                new PocoPerson{ Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
            };
            TextProperty1 = "Only this TextBox's changes are reflected in bindings";
            NextExampleCommand = new RelayCommand(NextExample);
            AddUserCommand = new RelayCommand(AddUser);

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //This simulates something happening in the background
            //These changes are NOT reflected in the UI
            //For these changes to show, you need INotifyPropertyChanged or DependencyProperty
            TextProperty1 = DateTime.Now.ToString();
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new PocoPerson { Id = parameter.ToString(), PrimerNombre = parameter.ToString(), SegundoNombre = parameter.ToString(), PrimerApellido = parameter.ToString(), SegundoApellido = parameter.ToString(), Sexo = parameter.ToString(), TipoDocumento = parameter.ToString(), NoDocumento = parameter.ToString(), RepetirNoDocumento = parameter.ToString(), FechaNacimiento = parameter.ToString(), Usuario = parameter.ToString(), Contrasena = parameter.ToString(), Departamento = parameter.ToString(), Ciudad = parameter.ToString(), Direccion = parameter.ToString(), Barrio = parameter.ToString(), Telefono = parameter.ToString(), Celular = parameter.ToString(), CorreoElectronico = parameter.ToString(), CorreoElectronicoRepeat = parameter.ToString(), CentroEmpleo = parameter.ToString() });
        }

        void NextExample(object parameter)
        {
            var win = new Window4 { DataContext = new ViewModelWindow4() };
            win.Show();

            if (CloseWindowEvent != null)
                CloseWindowEvent(this, null);
        }

    }
}
