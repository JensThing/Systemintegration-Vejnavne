namespace Vejnavne.CprData.Models
{
    public class ByfornyDist : RecordWithDistrict
    {
        public string ByFornyKode { get; set; }

        public ByfornyDist(string line) : base(line)
        {
            ByFornyKode = line.Substring(32, 6).Trim();
            DistriktTekst = line.Substring(38, 30).Trim();
        }
    }
}
