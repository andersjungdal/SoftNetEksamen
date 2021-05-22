using System.Collections.Generic;
using System.Threading.Tasks;
using Leverandører.Models;
using Microsoft.AspNetCore.Mvc;

namespace Leverandører.Interfaces
{
    public interface ILeverandørService
    {
        Task<(IEnumerable<Leverandør> Leverandører, string ErrorMessage)> GetLeverandørerAsync();
        Task<(Leverandør Leverandør, string ErrorMessage)> GetLeverandørAsync(int id);
        Task<(Db.Leverandør Leverandør, string ErrorMessage)> PostLeverandørAsync([FromBody] Leverandør leverandør);
        Task<(Db.Leverandør Leverandør, string ErrorMessage)> DeleteLeverandørAsync(int id);
        Task<(Db.Leverandør Leverandør, string ErrorMessage)> PutLevendørAsync([FromBody] Leverandør leverandør, int id);
    }
}