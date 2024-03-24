using Vejnavne.CprData.Models;

namespace Vejnavne.CprData.Services
{
    public interface ICprVejnavneService
    {
        List<Record> GetRecords();
    }
}