namespace Vejnavne.CprData.Models
{
    public class DivDist : RecordWithDistrict
    {
        public string DistType { get; set; }
        public string DivDistKode { get; set; }

        public DivDist(string line) : base(line)
        {
            DistType = line.Substring(32, 2).Trim();
            DivDistKode = line.Substring(34, 4).Trim();
            DistriktTekst = line.Substring(38, 30).Trim();
        }
    }
}
