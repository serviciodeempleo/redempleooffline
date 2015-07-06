namespace RedEmpeloOffLine.Model
{
    /// <summary>
    /// A POCO class is one that does not need any special interfaces or inheritance
    /// In WPF MVVM terms, a POCO class is one that does not Fire PropertyChanged events
    /// </summary>

    class PocoPerson
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Sexo { get; set; }
        public string TipoDocumento { get; set; }
        public string NoDocumento { get; set; }
        public string RepetirNoDocumento { get; set; }
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
        public string CorreoElectronicoRepeat { get; set; }
        public string CentroEmpleo { get; set; }
    }
}
