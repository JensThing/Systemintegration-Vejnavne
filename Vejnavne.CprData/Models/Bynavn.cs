namespace Vejnavne.CprData.Models
{
    public class Bynavn : RecordWithHouseNumber
    {
        public string Navn { get; set; }

        public Bynavn(string line) : base(line)
        {
            Navn = line.Substring(32, 34).Trim();
        }
    }
}
