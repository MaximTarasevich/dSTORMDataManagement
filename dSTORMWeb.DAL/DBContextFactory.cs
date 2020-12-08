using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace dSTORMWeb.DAL
{
    public class DBContextFactory
    {
        const string ConnectionString = "MySQLConnectionString";


        public static DataManager BuildDataManager(IConfiguration _configuration)
        {
            DataManager _dm = new DataManager(true);

            DbContextOptionsBuilder bld = new DbContextOptionsBuilder(new Microsoft.EntityFrameworkCore.DbContextOptions<dSTORMWeb.DAL.RepositoryContext>());
            bld = bld.UseMySql(_configuration.GetValue<string>(ConnectionString), // replace with your Connection String
                   mysqlOptions =>
                   {
                       mysqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                   });



            dSTORMWeb.DAL.RepositoryContext _context = new dSTORMWeb.DAL.RepositoryContext(bld.Options as Microsoft.EntityFrameworkCore.DbContextOptions<dSTORMWeb.DAL.RepositoryContext>);

            _dm.AOTFilterAccessor = new Accessors.AOTFilterAccessor(_context);
            _dm.AuthorAccessor = new Accessors.AuthorAccessor(_context);
            _dm.CameraAccessor = new Accessors.CameraAccessor(_context);
            _dm.dSTORMInfoAccessor = new Accessors.dSTORMInfoAccessor(_context);
            _dm.ExperimentAccessor = new Accessors.ExperimentAccessor(_context);
            _dm.FinalImageAccessor = new Accessors.FinalImageAccessor(_context);
            _dm.FluorophoreAccessor = new Accessors.FluorophoreAccessor(_context);
            _dm.FluorophoreResearchObjectAccessor = new Accessors.FluorophoreResearchObjectAccessor(_context);
            _dm.InitialVideoAccessor = new Accessors.InitialVideoAccessor(_context);
            _dm.LaserAccessor = new Accessors.LaserAccessor(_context);
            _dm.MicroscopeAccessor = new Accessors.MicroscopeAccessor(_context);
            _dm.ObjectiveAccessor = new Accessors.ObjectiveAccessor(_context);
            _dm.PhysicalPropertiesAccessor = new Accessors.PhysicalPropertiesAccessor(_context);
            _dm.ResearchObjectAccessor = new Accessors.ResearchObjectAccessor(_context);
            _dm.SetupAccessor = new Accessors.SetupAccessor(_context);
            _dm.VideoFragmentAccessor = new Accessors.VideoFragmentAccessor(_context);

            return _dm;
        }



    }
}
