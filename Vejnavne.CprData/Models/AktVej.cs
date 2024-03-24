namespace Vejnavne.CprData.Models
{
    public class AktVej : Record
    {
        public string Vejadresseringsnavn { get; set; }
        public string Vejnavn { get; set; }
        public string TilKommunekode { get; set; }
        public string FraKommunekode { get; set; }
        public string TilVejkode { get; set; }
        public string FraVejkode { get; set; }
        public string Startdato { get; set; }

        // Relationship properties
        public List<Bolig> Boliger { get; set; } = new();
        public List<Bynavn> Bynavne { get; set; } = new();
        public List<PostDist> PostDistrikter { get; set; } = new();
        public List<NotatVej> NotatVeje { get; set; } = new();
        public List<ByfornyDist> ByfornyelsesDistrikt { get; set; } = new();
        public List<DivDist> DiverseDistrikter { get; set; } = new();
        public List<EvakuerDist> EvakueringsDistrikter { get; set; } = new();
        public List<KirkeDist> KirkeDistrikter { get; set; } = new();
        public List<SkoleDist> SkoleDistrikter { get; set; } = new();
        public List<BefolkDist> BefolkningsDistrikter { get; set; } = new();
        public List<SocialDist> SocialDistrikter { get; set; } = new();
        public List<SogneDist> SogneDistrikter { get; set; } = new();
        public List<ValgDist> ValgDistrikter { get; set; } = new();
        public List<VarmeDist> VarmeDistrikter { get; set; } = new();

        public AktVej(string line) : base(line)
        {
            Timestamp = line.Substring(11, 12).Trim();
            TilKommunekode = line.Substring(23, 4).Trim();
            FraKommunekode = line.Substring(31, 4).Trim();
            TilVejkode = line.Substring(27, 4).Trim();
            FraVejkode = line.Substring(35, 4).Trim();
            Startdato = line.Substring(39, 12).Trim();
            Vejadresseringsnavn = line.Substring(51, 20).Trim();
            Vejnavn = line.Substring(71, 40).Trim();
        }
    }
}
