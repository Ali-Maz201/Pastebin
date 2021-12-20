using Pastebin.Models;
using Pastebin.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastebin.Data
{
    public interface IPasteRepo
    {
        public Task<List<Paste>> GetAllPastes();
        public Task<Paste> GetPasteByCodeAsync(string? urlRoute);
        public Task CreatePaste(Paste currentPaste);
        public string CreatePasteCode();
        public DateTime OptionTimer(string OptionExpirationPaste, DateTime CreationTimeOfPaste);
        public void DeleteConfirmed(Paste currentPaste);
        public void Update(Paste currentPaste);
    }
}
