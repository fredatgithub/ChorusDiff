namespace DiffVal.Model
{
    public class ChorusServicesTable
    {
        //[idService]	Identifiant	RaisonSociale	Code	Nom	GestionEGMT	ServiceActif	Adresse	ComplementAdresse1	ComplementAdresse2	CodePostal	Ville	NumTelephone	Courriel	CodePays	LibellePays
        public string idService { get; set; }
        public string Identifiant { get; set; }
        public string RaisonSociale { get; set; }
        public string Code { get; set; }
        public string Nom { get; set; }
        public bool GestionEGMT { get; set; }
        public bool ServiceActif { get; set; }
        public string Adresse { get; set; }
        public string ComplementAdresse1 { get; set; }
        public string ComplementAdresse2 { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string NumTelephone { get; set; }
        public string Courriel { get; set; }
        public string CodePays { get; set; }
        public string LibellePays { get; set; }

        public ChorusServicesTable(string idService,
         string Identifiant,
         string RaisonSociale,
         string Code,
         string Nom,
         bool GestionEGMT,
         bool ServiceActif,
         string Adresse,
         string ComplementAdresse1,
         string ComplementAdresse2,
         string CodePostal,
         string Ville,
         string NumTelephone,
         string Courriel,
         string CodePays,
         string LibellePays)
        {
            this.idService = idService;
            this.Identifiant = Identifiant;
            this.RaisonSociale = RaisonSociale;
            this.Code = Code;
            this.Nom = Nom;
            this.GestionEGMT = GestionEGMT;
            this.ServiceActif = ServiceActif;
            this.Adresse = Adresse;
            this.ComplementAdresse1 = ComplementAdresse1;
            this.ComplementAdresse2 = ComplementAdresse2;
            this.CodePostal = CodePostal;
            this.Ville = Ville;
            this.NumTelephone = NumTelephone;
            this.Courriel = Courriel;
            this.CodePays = CodePays;
            this.LibellePays = LibellePays;
        }

        public string ToTableCSVString(string separator)
        {
            return $"{idService}{separator}{Identifiant}{separator}{RaisonSociale}{separator}{Code}{separator}{Nom}{separator}{GestionEGMT}{separator}{ServiceActif}{separator}{Adresse}{separator}{ComplementAdresse1}{separator}{ComplementAdresse2}{separator}{CodePostal}{separator}{Ville}{separator}{NumTelephone}{separator}{Courriel}{separator}{CodePays}{separator}{LibellePays}";
        }

    }
}
