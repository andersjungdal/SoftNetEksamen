using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kategorier.Db;
using Kategorier.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kategori = Kategorier.Models.Kategori;

namespace Kategorier.Service
{
    public class KategoriService : IKategoriService
    {
        private readonly KategoriDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;
        public KategoriService(KategoriDbContext dbContext, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
        }
        public async Task<(IEnumerable<Kategori> Kategorier, string ErrorMessage)> GetKategorierAsync()
        {
            try
            {
                var kategorier = await dbContext.Kategori.ToListAsync();
                if (kategorier != null && kategorier.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Kategori>, IEnumerable<Models.Kategori>>(kategorier);
                    return (result, null);
                }
                return (null, "Not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Kategori Kategori, string ErrorMessage)> GetKategoriAsync(int id)
        {
            try
            {
                var kategori = await dbContext.Kategori.FirstOrDefaultAsync(c => c.ID == id);
                if (kategori != null)
                {
                    var result = mapper.Map<Db.Kategori, Models.Kategori>(kategori);
                    return (result, null);
                }
                return (null, "Not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Kategori Kategori, string ErrorMessage)> PostKategoriAsync(Kategori kategori)
        {
            try
            {
                var mapper = configurationProvider.CreateMapper();
                var newkategori = mapper.Map<Db.Kategori>(kategori);
                if (newkategori != null)
                {
                    dbContext.Kategori.Add(newkategori);
                    await dbContext.SaveChangesAsync();
                    return (newkategori, null);
                }
                return (null, "Not created");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Kategori Kategori, string ErrorMessage)> DeleteKategoriAsync(int id)
        {
            try
            {
                var findkategori = dbContext.Kategori.SingleOrDefault(x => x.ID == id);
                if (findkategori == null)
                {
                    return (null, "Not found");
                }
                dbContext.Kategori.Remove(findkategori);
                await dbContext.SaveChangesAsync();
                return (findkategori, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Kategori Kategori, string ErrorMessage)> PutKategoriAsync([FromBody] Kategori kategori, int id)
        {
            try
            {
                var updatedkategori = await dbContext.Kategori.FirstOrDefaultAsync(c => c.ID == id);
                updatedkategori.Beskrivelse = kategori.Beskrivelse;
                updatedkategori.Navn = kategori.Navn;
                if (updatedkategori != null)
                {
                    dbContext.Kategori.Update(updatedkategori);
                    await dbContext.SaveChangesAsync();
                    return (updatedkategori, null);
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