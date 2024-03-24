namespace Vejnavne.CprData.Models
{
    public class ValgDist : RecordWithDistrict
    {
        public string Valgkode { get; set; }

        public ValgDist(string line) : base(line)
        {
            Valgkode = line.Substring(32, 2).Trim();
            DistriktTekst = line.Substring(34, 30).Trim();
        }
    }
}
