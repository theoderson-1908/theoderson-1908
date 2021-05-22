using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AssesmentFourFIrstQuestion.Models
{
    public class ProfileContext:DbContext
    {
        public ProfileContext(DbContextOptions options):base(options)
        { }
        public DbSet<Profile> Profiles { get; set; }
            

    }
}
