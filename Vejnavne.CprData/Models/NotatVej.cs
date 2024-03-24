namespace Vejnavne.CprData.Models
{
    public class NotatVej : Record
    {
        public string? NotatNummer { get; set; }
        public string? NotatLinje { get; set; }
        public string? Startdato { get; set; }

        public NotatVej(string line) : base(line)
        {
            NotatNummer = line.Substring(11, 2).Trim();
            NotatLinje = line.Substring(13, 40).Trim();
            Timestamp = line.Substring(53, 12).Trim();
            Startdato = line.Substring(65, 12).Trim();
        }
    }
}
