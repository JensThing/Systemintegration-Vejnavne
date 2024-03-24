namespace Vejnavne.CprData.Models
{
    public abstract class RecordWithHouseNumber : Record
    {
        public string? HusnummerFra { get; set; }
        public string? HusnummerTil { get; set; }
        public string? LigeUlige { get; set; }

        protected RecordWithHouseNumber(string line) : base(line)
        {
            HusnummerFra = line.Substring(11, 4).Trim();
            HusnummerTil = line.Substring(15, 4).Trim();
            LigeUlige = line.Substring(19, 1).Trim();
        }
    }
}
