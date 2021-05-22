using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kategorier.Db;
using Kategorier.Models;
using Microsoft.EntityFrameworkCore;
using Produkter.Db;
using Produkter.Interfaces;
using Produkt = Produkter.Models.Produkt;

namespace Produkter.Service
{
    public class ProduktService : IProduktService
    {
        private readonly ProduktDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;
        public ProduktService(ProduktDbContext dbContext, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
        }
        public async Task<(IEnumerable<Produkt> Produkter, string ErrorMessage)> GetProdukterAsync()
        {
            try
            {
                var produkter = await dbContext.Produkt
                    .Include(k => k.Kategori)
                    .Include(l => l.Leverandør)
                    .ToListAsync();
                if (produkter != null && produkter.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Produkt>, IEnumerable<Models.Produkt>>(produkter);
                    return (result, null);
                }
                return (null, "not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Produkt Produkt, string ErrorMessage)> GetProduktAsync(int id)
        {
            try
            {
                var produkt = await dbContext.Produkt
                    .Include(k => k.Kategori)
                    .Include(l => l.Leverandør)
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (produkt != null)
                {
                    var result = mapper.Map<Db.Produkt, Models.Produkt>(produkt);
                    return (result, null);
                }
                return (null, "Not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Produkt Produkt, string ErrorMessage)> PostProduktAsync(Produkt produkt)
        {
            try
            {
                var mapper = configurationProvider.CreateMapper();
                var newprodukt = mapper.Map<Db.Produkt>(produkt);
                if (newprodukt != null)
                {
                    dbContext.Produkt.Add(newprodukt);
                    await dbContext.SaveChangesAsync();
                    return (newprodukt, null);
                }
                return (null, "Not created");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Produkt Produkt, string ErrorMessage)> DeleteProduktAsync(int id)
        {
            try
            {
                var findprodukt = await dbContext.Produkt
                    .Include(k => k.Kategori)
                    .Include(l => l.Leverandør)
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (findprodukt == null)
                {
                    return (null, "Not found");
                }
                dbContext.Produkt.Remove(findprodukt);
                dbContext.Remove(findprodukt.Kategori);
                dbContext.Remove(findprodukt.Leverandør);
                await dbContext.SaveChangesAsync();
                return (findprodukt, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Produkt Produkt, string ErrorMessage)> PutProduktAsync(Produkt produkt, int id)
        {
            try
            {
                var updatedprodukt = await dbContext.Produkt.Include(k => k.Kategori)
                    .Include(l => l.Leverandør).FirstOrDefaultAsync(c => c.ID == id);
                updatedprodukt.Navn = produkt.Navn;
                updatedprodukt.AntalPåLager = produkt.AntalPåLager;
                updatedprodukt.Beskrivelse = produkt.Beskrivelse;
                updatedprodukt.Enhed = produkt.Enhed;
                updatedprodukt.MængdeIPakningen = produkt.MængdeIPakningen;
                updatedprodukt.Pris = produkt.Pris;
                updatedprodukt.Kategori.Navn = produkt.Kategori.Navn;
                updatedprodukt.Kategori.Beskrivelse = produkt.Kategori.Beskrivelse;
                updatedprodukt.Leverandør.Adresse = produkt.Leverandør.Adresse;
                updatedprodukt.Leverandør.Email = produkt.Leverandør.Email;
                updatedprodukt.Leverandør.Kontaktperson = produkt.Leverandør.Kontaktperson;
                updatedprodukt.Leverandør.Postnummer = produkt.Leverandør.Postnummer;
                updatedprodukt.Leverandør.Telefon = produkt.Leverandør.Telefon;
                if (updatedprodukt != null)
                {
                    dbContext.Produkt.Update(updatedprodukt);
                    await dbContext.SaveChangesAsync();
                    return (updatedprodukt, null);
                }
                return (null, "Not created");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }
}