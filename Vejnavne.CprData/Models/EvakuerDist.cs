namespace Vejnavne.CprData.Models
{
    public class EvakuerDist : RecordWithDistrict
    {
        public string EvakuerKode { get; set; }

        public EvakuerDist(string line) : base(line)
        {
            EvakuerKode = line.Substring(32, 1).Trim();
            DistriktTekst = line.Substring(33, 30).Trim();
        }
    }
}
