namespace Vejnavne.CprData.Models
{
    public abstract class RecordWithDistrict : RecordWithHouseNumber
    {
        public string? DistriktTekst { get; set; }

        protected RecordWithDistrict(string line) : base(line)
        {
            DistriktTekst = line.Substring(34, 30).Trim();
        }
    }
}
