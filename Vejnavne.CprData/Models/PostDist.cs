namespace Vejnavne.CprData.Models
{
    public class PostDist : RecordWithHouseNumber
    {
        public string Postnummer { get; set; }
        public string PostDistrikTekst { get; set; }

        public PostDist(string line) : base(line)
        {
            Postnummer = line.Substring(32, 4).Trim();
            PostDistrikTekst = line.Substring(36, 20).Trim();
        }
    }
}
