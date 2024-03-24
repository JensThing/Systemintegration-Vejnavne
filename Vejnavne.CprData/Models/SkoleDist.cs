namespace Vejnavne.CprData.Models
{
    public class SkoleDist : RecordWithDistrict
    {
        public string SkoleKode { get; set; }

        public SkoleDist(string line) : base(line)
        {
            SkoleKode = line.Substring(32, 4).Trim();
            DistriktTekst = line.Substring(34, 30).Trim();
        }
    }
}
