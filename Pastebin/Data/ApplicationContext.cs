using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pastebin.Models;

namespace Pastebin.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Paste> Pastes { get; set; }
       
    }
}
