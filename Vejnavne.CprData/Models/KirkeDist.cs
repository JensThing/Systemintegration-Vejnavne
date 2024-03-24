namespace Vejnavne.CprData.Models
{
    public class KirkeDist : RecordWithDistrict
    {
        public string KirkeKode { get; set; }

        public KirkeDist(string line) : base(line)
        {
            KirkeKode = line.Substring(32, 2).Trim();
            DistriktTekst = line.Substring(34, 30).Trim();
        }
    }
}
