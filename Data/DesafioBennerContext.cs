using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBenner.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DesafioBenner.Data
{
    public class DesafioBennerContext : DbContext
    {
        public DesafioBennerContext(DbContextOptions<DesafioBennerContext> options)
            : base(options)
        {
        }

        public DbSet<ControleEstacionamento> ControleEstacionamento { get; set; } = default!;

        public DesafioBennerContext()
        {
        }

        public DbSet<DesafioBenner.Models.Precos> Precos { get; set; } = default!;
    }
}
