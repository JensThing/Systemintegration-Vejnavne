namespace Vejnavne.CprData.Models
{
    public class VarmeDist : RecordWithDistrict
    {
        public string Varmekode { get; set; }

        public VarmeDist(string line) : base(line)
        {
            Varmekode = line.Substring(32, 4).Trim();
            DistriktTekst = line.Substring(36, 30).Trim();
        }
    }
}
