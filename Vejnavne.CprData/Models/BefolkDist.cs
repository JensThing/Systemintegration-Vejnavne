namespace Vejnavne.CprData.Models
{
    public class BefolkDist : RecordWithDistrict
    {
        public string BefolkKode { get; set; }

        public BefolkDist(string line) : base(line)
        {
            BefolkKode = line.Substring(32, 4).Trim();
            DistriktTekst = line.Substring(36, 30).Trim();
        }
    }
}
