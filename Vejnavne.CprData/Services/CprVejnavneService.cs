using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Vejnavne.CprData.Models;

namespace Vejnavne.CprData.Services
{
    /// <summary>
    /// Service for handling CPR Vejnavne data.
    /// </summary>
    public class CprVejnavneService : ICprVejnavneService
    {
        private readonly IMemoryCache _cache;
        private readonly IOptions<CprVejnavneServiceOptions> _options;

        /// <summary>
        /// Initializes a new instance of the <see cref="CprVejnavneService"/> class.
        /// </summary>
        /// <param name="cache">The memory cache.</param>
        /// <param name="options">The options for the service.</param>
        public CprVejnavneService(IMemoryCache cache, IOptions<CprVejnavneServiceOptions> options)
        {
            _cache = cache;
            _options = options;
        }

        /// <summary>
        /// Gets the records from the data file.
        /// </summary>
        /// <returns>A list of records.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the data file path is not set in options.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the data file is not found.</exception>
        /// <exception cref="IOException">Thrown when there is an error reading the data file.</exception>
        public List<Record> GetRecords()
        {
            // Check if the records are already cached
            if (_cache.TryGetValue("records", out List<Record>? cachedRecords))
            {
                return cachedRecords!;
            }

            // Check if options are set
            if (string.IsNullOrEmpty(_options.Value.DataFilePath))
            {
                throw new InvalidOperationException("Data file path not set in options");
            }

            List<Record> records = new();

            try
            {
                var lines = File.ReadAllLines(_options.Value.DataFilePath!, encoding: System.Text.Encoding.Latin1);
                records = CombinedRecords(lines);

                // Cache the records for 1 day
                _cache.Set("records", records, TimeSpan.FromDays(1));
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Data file not found", _options.Value.DataFilePath);
            }
            catch (IOException ex)
            {
                throw new IOException("Error reading data file", ex);
            }
            catch (Exception ex)
            {
                Exception exception = new("Unexpected exception!", ex);
                throw exception;
            }
            return records;
        }

        /// <summary>
        /// Combines the records from the given lines of data.
        /// </summary>
        /// <param name="lines">The lines of data.</param>
        /// <returns>The combined list of records.</returns>
        private List<Record> CombinedRecords(string[] lines)
        {
            List<Record> records = new();
            AktVej? current = null;

            foreach (var line in lines)
            {
                var record = ParseRecord(line);
                if (record is null)
                {
                    continue;
                }

                switch (record.RecordType)
                {
                    case "001":
                        if (current != null)
                        {
                            records.Add(current);
                        }
                        current = (AktVej)record;
                        break;
                    case "002":
                        current?.Boliger.Add((Bolig)record);
                        break;
                    case "003":
                        current?.Bynavne.Add((Bynavn)record);
                        break;
                    case "004":
                        current?.PostDistrikter.Add((PostDist)record);
                        break;
                    case "005":
                        current?.NotatVeje.Add((NotatVej)record);
                        break;
                    case "006":
                        current?.ByfornyelsesDistrikt.Add((ByfornyDist)record);
                        break;
                    case "007":
                        current?.DiverseDistrikter.Add((DivDist)record);
                        break;
                    case "008":
                        current?.EvakueringsDistrikter.Add((EvakuerDist)record);
                        break;
                    case "009":
                        current?.KirkeDistrikter.Add((KirkeDist)record);
                        break;
                    case "010":
                        current?.SkoleDistrikter.Add((SkoleDist)record);
                        break;
                    case "011":
                        current?.BefolkningsDistrikter.Add((BefolkDist)record);
                        break;
                    case "012":
                        current?.SocialDistrikter.Add((SocialDist)record);
                        break;
                    case "013":
                        current?.SogneDistrikter.Add((SogneDist)record);
                        break;
                    case "014":
                        current?.ValgDistrikter.Add((ValgDist)record);
                        break;
                    case "015":
                        current?.VarmeDistrikter.Add((VarmeDist)record);
                        break;
                    default:
                        break;
                }
            }

            return records;
        }

        /// <summary>
        /// Parses a record from a line of data.
        /// </summary>
        /// <param name="line">The line of data.</param>
        /// <returns>The parsed record, or null if the record type is not recognized.</returns>
        private Record? ParseRecord(string line)
        {
            var recordType = line.Substring(0, 3);
            return recordType switch
            {
                "001" => new AktVej(line),
                "002" => new Bolig(line),
                "003" => new Bynavn(line),
                "004" => new PostDist(line),
                "005" => new NotatVej(line),
                "006" => new ByfornyDist(line),
                "007" => new DivDist(line),
                "008" => new EvakuerDist(line),
                "009" => new KirkeDist(line),
                "010" => new SkoleDist(line),
                "011" => new BefolkDist(line),
                "012" => new SocialDist(line),
                "013" => new SogneDist(line),
                "014" => new ValgDist(line),
                "015" => new VarmeDist(line),
                _ => null,
            };
        }
    }
}
