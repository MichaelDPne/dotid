﻿using dotidapi.Entity;
using Microsoft.EntityFrameworkCore;

namespace dotidapi.Context
{
    public class DotIdContext : DbContext
    {
        public DotIdContext()
        {

        }

        public DotIdContext(DbContextOptions<DotIdContext> options) : base(options) {

        }

        public virtual DbSet<PopulationEntity> FactPopulations {  get; set; }    

        public virtual DbSet<RegionEntity> Regions { get; set; }
    }
}
