namespace Vejnavne.CprData.Models
{
    public class SocialDist : RecordWithDistrict
    {
        public string SocialKode { get; set; }

        public SocialDist(string line) : base(line)
        {
            SocialKode = line.Substring(20, 12).Trim();
            DistriktTekst = line.Substring(34, 30).Trim();
        }
    }
}
