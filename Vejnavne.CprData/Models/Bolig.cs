namespace Vejnavne.CprData.Models
{
    public class Bolig : Record
    {
        public string Filler1A { get; set; }
        public string Filler12N { get; set; }
        public string Lokalitet { get; set; }
        public string? Etage { get; set; }
        public string? Sidedoer { get; set; }
        public string? Startdato { get; set; }
        public string? Husnummer { get; set; }

        public Bolig(string line) : base(line)
        {
            Husnummer = line.Substring(11, 4).Trim();
            Etage = line.Substring(15, 2).Trim();
            Sidedoer = line.Substring(17, 4).Trim();
            Timestamp = line.Substring(21, 12).Trim();
            Filler1A = line.Substring(33, 1).Trim();
            Filler12N = line.Substring(46, 12).Trim();
            Startdato = line.Substring(34, 12).Trim();
            Lokalitet = line.Substring(58, 34).Trim();
        }
    }
}
