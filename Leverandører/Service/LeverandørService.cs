using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leverandører.Db;
using Leverandører.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Leverandør = Leverandører.Models.Leverandør;

namespace Leverandører.Service
{
    public class LeverandørService : ILeverandørService
    {
        private readonly LeverandørDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IConfigurationProvider configurationProvider;
        public LeverandørService(LeverandørDbContext dbContext, IMapper mapper, IConfigurationProvider configurationProvider)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.configurationProvider = configurationProvider;
        }
        public async Task<(IEnumerable<Leverandør> Leverandører, string ErrorMessage)> GetLeverandørerAsync()
        {
            try
            {
                var leverandører = await dbContext.Leverandør.ToListAsync();
                if (leverandører != null && leverandører.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Leverandør>, IEnumerable<Models.Leverandør>>(leverandører);
                    return (result, null);
                }
                return (null, "Not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Leverandør Leverandør, string ErrorMessage)> GetLeverandørAsync(int id)
        {
            try
            {
                var leverandør = await dbContext.Leverandør.FirstOrDefaultAsync(c => c.ID == id);
                if (leverandør != null)
                {
                    var result = mapper.Map<Db.Leverandør, Models.Leverandør>(leverandør);
                    return (result, null);
                }
                return (null, "Not found");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Leverandør Leverandør, string ErrorMessage)> PostLeverandørAsync(Leverandør leverandør)
        {
            try
            {
                var mapper = configurationProvider.CreateMapper();
                var newleverandør = mapper.Map<Db.Leverandør>(leverandør);
                if (newleverandør != null)
                {
                    dbContext.Leverandør.Add(newleverandør);
                    await dbContext.SaveChangesAsync();
                    return (newleverandør, null);
                }
                return (null, "Not created");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Leverandør Leverandør, string ErrorMessage)> DeleteLeverandørAsync(int id)
        {
            try
            {
                var findleverandør = dbContext.Leverandør.SingleOrDefault(x => x.ID == id);
                if (findleverandør == null)
                {
                    return (null, "Not found");
                }
                dbContext.Leverandør.Remove(findleverandør);
                await dbContext.SaveChangesAsync();
                return (findleverandør, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
        public async Task<(Db.Leverandør Leverandør, string ErrorMessage)> PutLevendørAsync([FromBody] Leverandør leverandør, int id)
        {
            try
            {
                var updatedleverandør = await dbContext.Leverandør.FirstOrDefaultAsync(c => c.ID == id);
                updatedleverandør.Navn = leverandør.Navn;
                updatedleverandør.Adresse = leverandør.Adresse;
                updatedleverandør.Email = leverandør.Email;
                updatedleverandør.Kontaktperson = leverandør.Kontaktperson;
                updatedleverandør.Postnummer = leverandør.Postnummer;
                updatedleverandør.Telefon = leverandør.Telefon;
                if (updatedleverandør != null)
                {
                    dbContext.Leverandør.Update(updatedleverandør);
                    await dbContext.SaveChangesAsync();
                    return (updatedleverandør, null);
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