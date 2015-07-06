using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RedEmpeloOffLine.Model
{
    public class Person : INotifyPropertyChanged, IDataErrorInfo
    {
        string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Name exceeded 50 letters")]
        string _PrimerNombre;
        public string PrimerNombre
        {
            get
            {
                return _PrimerNombre;
            }
            set
            {
                if (_PrimerNombre != value)
                {
                    _PrimerNombre = value;
                    RaisePropertyChanged("SegundoNombre");
                }
            }
        }
        string _SegundoNombre;
        public string SegundoNombre
        {
            get
            {
                return _SegundoNombre;
            }
            set
            {
                if (_SegundoNombre != value)
                {
                    _SegundoNombre = value;
                    RaisePropertyChanged("SegundoNombre");
                }
            }
        }
        string _PrimerApellido;
        public string PrimerApellido
        {
            get
            {
                return _PrimerApellido;
            }
            set
            {
                if (_PrimerApellido != value)
                {
                    _PrimerApellido = value;
                    RaisePropertyChanged("PrimerApellido");
                }
            }
        }
        string _SegundoApellido;
        public string SegundoApellido
        {
            get
            {
                return _SegundoApellido;
            }
            set
            {
                if (_SegundoApellido != value)
                {
                    _SegundoApellido = value;
                    RaisePropertyChanged("SegundoApellido");
                }
            }
        }
        string _Sexo;
        public string Sexo
        {
            get
            {
                return _Sexo;
            }
            set
            {
                if (_Sexo != value)
                {
                    _Sexo = value;
                    RaisePropertyChanged("Sexo");
                }
            }
        }
        string _TipoDocumento;
        public string TipoDocumento
        {
            get
            {
                return _TipoDocumento;
            }
            set
            {
                if (_TipoDocumento != value)
                {
                    _TipoDocumento = value;
                    RaisePropertyChanged("TipoDocumento");
                }
            }
        }
        string _NoDocumento;
        public string NoDocumento
        {
            get
            {
                return _NoDocumento;
            }
            set
            {
                if (_NoDocumento != value)
                {
                    _NoDocumento = value;
                    RaisePropertyChanged("NoDocumento");
                }
            }
        }
        string _RepetirNoDocumento;
        public string RepetirNoDocumento
        {
            get
            {
                return _RepetirNoDocumento;
            }
            set
            {
                if (_RepetirNoDocumento != value)
                {
                    _RepetirNoDocumento = value;
                    RaisePropertyChanged("RepetirNoDocumento");
                }
            }
        }
        string _FechaNacimiento;
        public string FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }
            set
            {
                if (_FechaNacimiento != value)
                {
                    _FechaNacimiento = value;
                    RaisePropertyChanged("FechaNacimiento");
                }
            }
        }
        string _Usuario;
        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                if (_Usuario != value)
                {
                    _Usuario = value;
                    RaisePropertyChanged("Usuario");
                }
            }
        }
        string _Contrasena;
        public string Contrasena
        {
            get
            {
                return _Contrasena;
            }
            set
            {
                if (_Contrasena != value)
                {
                    _Contrasena = value;
                    RaisePropertyChanged("Contrasena");
                }
            }
        }
        string _ContrasenaRepite;
        public string ContrasenaRepite
        {
            get
            {
                return _ContrasenaRepite;
            }
            set
            {
                if (_ContrasenaRepite != value)
                {
                    _ContrasenaRepite = value;
                    RaisePropertyChanged("ContrasenaRepite");
                }
            }
        }
        string _Departamento;
        public string Departamento
        {
            get
            {
                return _Departamento;
            }
            set
            {
                if (_Departamento != value)
                {
                    _Departamento = value;
                    RaisePropertyChanged("Departamento");
                }
            }
        }
        string _Ciudad;
        public string Ciudad
        {
            get
            {
                return _Ciudad;
            }
            set
            {
                if (_Ciudad != value)
                {
                    _Ciudad = value;
                    RaisePropertyChanged("Ciudad");
                }
            }
        }
        string _Direccion;
        public string Direccion
        {
            get
            {
                return _Direccion;
            }
            set
            {
                if (_Direccion != value)
                {
                    _Direccion = value;
                    RaisePropertyChanged("Direccion");
                }
            }
        }
        string _Barrio;
        public string Barrio
        {
            get
            {
                return _Barrio;
            }
            set
            {
                if (_Barrio != value)
                {
                    _Barrio = value;
                    RaisePropertyChanged("Barrio");
                }
            }
        }
        string _Telefono;
        public string Telefono
        {
            get
            {
                return _Telefono;
            }
            set
            {
                if (_Telefono != value)
                {
                    _Telefono = value;
                    RaisePropertyChanged("Telefono");
                }
            }
        }
        string _Celular;
        public string Celular
        {
            get
            {
                return _Celular;
            }
            set
            {
                if (_Celular != value)
                {
                    _Celular = value;
                    RaisePropertyChanged("Celular");
                }
            }
        }
        string _CorreoElectronico;
        public string CorreoElectronico
        {
            get
            {
                return _CorreoElectronico;
            }
            set
            {
                if (_CorreoElectronico != value)
                {
                    _CorreoElectronico = value;
                    RaisePropertyChanged("CorreoElectronico");
                }
            }
        }
        string _CorreoElectronicoRepeat;
        public string CorreoElectronicoRepeat
        {
            get
            {
                return _CorreoElectronicoRepeat;
            }
            set
            {
                if (_CorreoElectronicoRepeat != value)
                {
                    _CorreoElectronicoRepeat = value;
                    RaisePropertyChanged("CorreoElectronicoRepeat");
                }
            }
        }
        string _CentroEmpleo;
        public string CentroEmpleo
        {
            get
            {
                return _CentroEmpleo;
            }
            set
            {
                if (_CentroEmpleo != value)
                {
                    _CentroEmpleo = value;
                    RaisePropertyChanged("CentroEmpleo");
                }
            }
        }


        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;


        public string Error
        {
            get { return String.Empty; }
        }


       public string vaidaciones(string columnName)
        {
            string result = null;
            if (columnName == "PrimerNombre")
            {
                if (PrimerNombre != null)
                {
                    if (string.IsNullOrEmpty(PrimerNombre))
                    {
                        result = "Campo primer nombre es obligatorio";
                    }
                    else if (PrimerNombre.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(PrimerNombre))
                    {
                        result = "Solo letras y signos";
                    }
                }
            }
            if (columnName == "SegundoNombre")
            {
                if (SegundoNombre != null)
               {
                    if (SegundoNombre.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(SegundoNombre))
                    {
                        result = "Solo letras y signos";
                    }
                }
            }
            if (columnName == "PrimerApellido")
            {
                if (PrimerApellido != null)
                {
                    if (string.IsNullOrEmpty(PrimerApellido))
                        result = "Campo Primer Apellido es obligatorio";
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(PrimerApellido))
                    {
                        result = "Solo letras y signos";
                    }
                    if (PrimerApellido.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                }
            }

            if (columnName == "SegundoApellido")
            {
                if (SegundoApellido != null)
                {
                    if (SegundoApellido.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(SegundoApellido))
                    {
                        result = "Solo letras y signos";
                    }
                }
            }

            if (columnName == "NoDocumento")
                {
                    if (NoDocumento != null)
                    {
                        if (string.IsNullOrEmpty(NoDocumento))
                        {
                            result = "Campo número documento es obligatorio";
                        }
                        else
                        {
                            Regex regex = new Regex(@"^\d+$");
                            if (!regex.IsMatch(NoDocumento))
                            {
                                result = "Campo número documento debe ser un número";
                            }
                        }


                    }
                }
                if (columnName == "RepetirNoDocumento")
                {
                    if (NoDocumento != null)
                    {
                        if (string.IsNullOrEmpty(NoDocumento))
                        {
                            result = "Campo Repetir Número  es obligatorio";
                        }
                        else
                        {
                            if ((NoDocumento != RepetirNoDocumento))
                            {
                                result = "El campo Repetir Número y Número documento, no son iguales";
                            }
                        }
                    }
                }


            if (columnName == "Direccion")
            {
                if (Direccion != null)
                {
                    if (string.IsNullOrEmpty(Direccion))
                    {
                        result = "Campo direcciòn es obligatorio";
                    }
                    if (Direccion.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(Direccion))
                    {
                        result = "Solo letras y signos";
                    }
                }
            }
            if (columnName == "Barrio")
            {
                if (Telefono != null)
                {
                    if (Barrio.ToString().Length > 50)
                    {
                        result = "Maximo 50 caracteres";
                    }
                    Regex regex = new Regex(@"^[0-9a-zA-ZñÑáéíóúÁÉÍÓÚñÑ\(\)\,\.\-\\s]*");
                    if (!regex.IsMatch(Barrio))
                    {
                        result = "Solo letras y signos";
                    }
                }
            }
            if (columnName == "Telefono")
            {
                if (Telefono != null)
                {
                    if (string.IsNullOrEmpty(Telefono))
                    {
                        result = "Campo telefono es obligatorio";
                    }
                    else{
                        string pattern = @"^\D?(\d{2})\D?\D?(\d{3})\D?(\d{4})$";
                        RegexOptions regexOptions = RegexOptions.None;
                        Regex regex = new Regex(pattern, regexOptions);
                        if (!regex.IsMatch(Telefono))
                        {
                            result = "El telefono debe contener el formato (##) #######";
                        }
                    }
                }
            }

            if (columnName == "Celular")
            {
                if (Celular != null)
                {
                    if (string.IsNullOrEmpty(Celular))
                    {
                        result = "Campo celular es obligatorio";
                    }
                    else
                    {
                        Regex regex = new Regex(@"^\d+$");
                        if (!regex.IsMatch(Celular))
                        {
                            result = "Campo celular debe ser un número";
                        }
                        if (Celular.ToString().Length != 10)
                        {
                            result = "Campo celular debe contener 10 digitos";
                        }
                    }

                }
            }
            if (columnName == "CorreoElectronico")
            {
                if (CorreoElectronico != null)
                {
                    if (string.IsNullOrEmpty(CorreoElectronico))
                    {
                        result = "Campo Correo electrónico es obligatorio";
                    }
                    else
                    {
                        if (CorreoElectronico != null)
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            Match match = regex.Match(CorreoElectronico);
                            if (!match.Success)
                                result = "Correo electrónico no es valido";
                        }
                    }
                }
            }
            if (columnName == "CorreoElectronicoRepeat")
            {
                if (CorreoElectronicoRepeat != null)
                {
                    if (string.IsNullOrEmpty(CorreoElectronicoRepeat))
                    {
                        result = "Campo confimar correo electrónico es obligatorio";
                    }
                    else
                    {
                        if (CorreoElectronicoRepeat != null)
                        {
                            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                            Match match = regex.Match(CorreoElectronicoRepeat);
                            if (!match.Success)
                                result = "Correo electrónico no es valido";
                        }
                    }
                }
            }
            if (columnName == "Contrasena")
            {
                if (Contrasena != null)
                {
                    if (string.IsNullOrEmpty(Contrasena))
                    {
                        result = "Campo Contraseña es obligatorio";
                    }
                    if (Contrasena.Length < 6)
                    {
                        result = "La contraseña debe contener al menos 6 caracteres";
                    }
                }
            }
            if (columnName == "ContrasenaRepite")
            {
                if (ContrasenaRepite != null)
                {
                    if (string.IsNullOrEmpty(ContrasenaRepite))
                    {
                        result = "Campo repetir Contraseña es obligatorio";
                    }
                    if (ContrasenaRepite != Contrasena)
                    {
                        result = "El campo repetir contraseña y contraseña , no son iguales";
                    }
                }
            }
            
            return result;
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return OnValidate(propertyName);
            }
        }

        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Property may not be null or empty", propertyName);

            string error = string.Empty;

            var value = this.GetType().GetProperty(propertyName).GetValue(this, null);
            var results = new List<ValidationResult>();

            var context = new ValidationContext(this, null, null) { MemberName = propertyName };

            var result = Validator.TryValidateProperty(value, context, results);

            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
            }
            else {
                error= vaidaciones(propertyName);
            }
            return error;
        }
    }
}
