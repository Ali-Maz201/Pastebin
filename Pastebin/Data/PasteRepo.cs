using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pastebin.Models;
using Pastebin.Models.ViewModels;
using Pastebin.Services;

namespace Pastebin.Data
{
    public class PasteRepo : IPasteRepo
    {
       
        private readonly ApplicationContext context;
        
        public PasteRepo(ApplicationContext context)
        {
            
            this.context = context;
            
        }

        public async Task<Paste> GetPasteByCodeAsync(string? pasteCode)
        {
            var foundedPaste = await context.Pastes.FirstOrDefaultAsync(search => search.PasteCode == pasteCode);
            if (foundedPaste == null)
            {
                var notFound = new Paste();
                notFound.Exists = "false";
                return notFound;
            }
            return foundedPaste;
        }

        public async Task CreatePaste(Paste currentPaste)
        {
            
            currentPaste.PasteCode = CreatePasteCode();
            if (currentPaste.OptionExpirationPaste != "Never" && currentPaste.OptionExpirationPaste != "Burn after read")
            {
                currentPaste.ExpirationTime = OptionTimer(currentPaste.OptionExpirationPaste, currentPaste.CreationTimeOfPaste);
            }
            await context.Pastes.AddAsync(currentPaste);
            await context.SaveChangesAsync();
        }

        public string CreatePasteCode()
        {
            string pasteCode = KeyGenerator.GetUniqueKey(10);

            while (context.Pastes.Where(a => a.PasteCode.Equals(pasteCode)).FirstOrDefault() != null)
            {
                pasteCode = KeyGenerator.GetUniqueKey(10);
            }

            return pasteCode; 
        }

        public DateTime OptionTimer(string OptionExpirationPaste, DateTime CreationTimeOfPaste)
        {
            switch (OptionExpirationPaste)
            {
                case "10 Minutes": 
                    return CreationTimeOfPaste.AddMinutes(10);
                case "1 Hour":     
                    return CreationTimeOfPaste.AddMinutes(60);
                case "1 Day":   
                    return CreationTimeOfPaste.AddDays(1);
                case "1 Week":
                    return CreationTimeOfPaste.AddDays(7);
                case "2 Weeks":
                    return CreationTimeOfPaste.AddDays(14);
                case "1 Month":
                    return CreationTimeOfPaste.AddMonths(1);
                case "6 Months":
                    return CreationTimeOfPaste.AddMonths(6);
                default:
                    return CreationTimeOfPaste.AddMonths(12);
            }
            
        }

        public void DeleteConfirmed(Paste currentPaste)
        { 
            context.Pastes.Remove(currentPaste);
            context.SaveChanges();
        }

        public async Task<List<Paste>> GetAllPublicPastes()
        {
            return await context.Pastes.Where(opt => opt.Exists == "true" &&  opt.OptionExposurePaste == "Public").ToListAsync();
        }

        public void Update(Paste currentPaste)
        {
            context.Update(currentPaste);
            context.SaveChanges();
        }
    }
}
