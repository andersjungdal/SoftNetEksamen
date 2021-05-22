using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kategorier.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kategorier.Interfaces
{
    public interface IKategoriService
    {
        Task<(IEnumerable<Kategori> Kategorier, string ErrorMessage)> GetKategorierAsync();
        Task<(Kategori Kategori, string ErrorMessage)> GetKategoriAsync(int id);
        Task<(Db.Kategori Kategori, string ErrorMessage)> PostKategoriAsync([FromBody] Kategori kategori);
        Task<(Db.Kategori Kategori, string ErrorMessage)> PutKategoriAsync([FromBody] Kategori kategori, int id);
        Task<(Db.Kategori Kategori, string ErrorMessage)> DeleteKategoriAsync(int id);
    }
}
