namespace Vejnavne.CprData.Models
{
    public abstract class Record
    {
        public string RecordType { get; set; }
        public string Kommunekode { get; set; }
        public string Vejkode { get; set; }
        public string Timestamp { get; set; }

        protected Record(string line)
        {
            RecordType = line.Substring(0, 3).Trim();
            Kommunekode = line.Substring(3, 4).Trim();
            Vejkode = line.Substring(7, 4).Trim();
            Timestamp = line.Substring(20, 12).Trim();
        }
    }
}
