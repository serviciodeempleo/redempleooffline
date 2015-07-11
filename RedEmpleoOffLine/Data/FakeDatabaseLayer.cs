using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using RedEmpleoOffLine.Model;

namespace RedEmpleoOffLine.Data
{
    class FakeDatabaseLayer
    {
        public static ObservableCollection<Person> GetPeopleFromDatabase()
        {
            //Simulate database extaction
            //For example from ADO DataSets or EF
            return new ObservableCollection<Person>
            {
                new Person { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new Person { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new Person { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
            };
        }

        public static List<PocoPerson> GetPocoPeopleFromDatabase()
        {
            //Simulate legacy database extaction of POCO classes
            //For example from ADO DataSets or EF
            return new List<PocoPerson>
            {
                new PocoPerson { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new PocoPerson { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
                new PocoPerson { Id="ff", PrimerNombre="ff", SegundoNombre="ff", PrimerApellido="ff", SegundoApellido="ff", Sexo="ff", TipoDocumento="ff", NoDocumento="ff", RepetirNoDocumento="ff", FechaNacimiento="ff", Usuario="ff", Contrasena="ff", Departamento="ff", Ciudad="ff", Direccion="ff", Barrio="ff", Telefono="ff", Celular="ff", CorreoElectronico="ff", CorreoElectronicoRepeat="ff", CentroEmpleo="ff" },
            };
        }
    }
}
