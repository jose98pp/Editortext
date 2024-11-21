using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Editortext.Models;

namespace Editortext.Data
{
    public class EditortextContext : DbContext
    {
        public EditortextContext (DbContextOptions<EditortextContext> options)
            : base(options)
        {
        }

        public DbSet<Editortext.Models.ArchivoEditor> ArchivoEditor { get; set; } = default!;
    }
}
