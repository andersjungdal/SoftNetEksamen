using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produkter.Models;

namespace Produkter.Interfaces
{
    public interface IProduktService
    {
        Task<(IEnumerable<Produkt> Produkter, string ErrorMessage)> GetProdukterAsync();
        Task<(Produkt Produkt, string ErrorMessage)> GetProduktAsync(int id);
        Task<(Db.Produkt Produkt, string ErrorMessage)> PostProduktAsync([FromBody] Produkt produkt);
        Task<(Db.Produkt Produkt, string ErrorMessage)> DeleteProduktAsync(int id);
        Task<(Db.Produkt Produkt, string ErrorMessage)> PutProduktAsync([FromBody] Produkt produkt, int id);
    }
}