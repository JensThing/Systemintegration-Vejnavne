namespace Vejnavne.CprData.Models
{
    public class SogneDist : RecordWithHouseNumber
    {
        public string MyndighedsKode { get; set; }
        public string Myndighedsnavn { get; set; }

        public SogneDist(string line) : base(line)
        {
            MyndighedsKode = line.Substring(32, 4).Trim();
            Myndighedsnavn = line.Substring(36, 20).Trim();
        }
    }
}
