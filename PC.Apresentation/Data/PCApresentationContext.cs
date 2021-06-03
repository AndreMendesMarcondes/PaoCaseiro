using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PC.Apresentation.Models;

namespace PC.Apresentation.Data
{
    public class PCApresentationContext : DbContext
    {
        public PCApresentationContext (DbContextOptions<PCApresentationContext> options)
            : base(options)
        {
        }

        public DbSet<PC.Apresentation.Models.Pao> Pao { get; set; }
    }
}
