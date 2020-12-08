using System;
using dSTORMWeb.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace dSTORMWeb.DAL
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base(options)
        {

        }

        public DbSet<AOTFilter> AOTFilters { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<dSTORMInfo> dSTORMInfos { get; set; }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<FinalImage> FinalImages { get; set; }
        public DbSet<Fluorophore> Fluorophores { get; set; }
        public DbSet<FluorophoreResearchObject> FluorophoreResearchObjects { get; set; }
        public DbSet<InitialVideo> InitialVideos { get; set; }
        public DbSet<Laser> Lasers { get; set; }
        public DbSet<Microscope> Microscopes { get; set; }
        public DbSet<PhysicalProperty> PhysicalProperties { get; set; }
        public DbSet<ResearchObject> ResearchObjects { get; set; }
        public DbSet<Setup> Setups { get; set; }
        public DbSet<VideoFragment> VideoFragments { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public void Close()
        {
            try
            {
                this.Database.CloseConnection();
                this.Dispose();
            }catch(Exception ex)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}
