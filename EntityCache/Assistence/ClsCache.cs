using System;
using System.Data.Entity.Migrations;
using AutoMapper;
using Nito.AsyncEx;
using PacketParser.Services;

namespace EntityCache.Assistence
{
    public class ClsCache
    {
        public static void Init()
        {
            var config = new MapperConfiguration(c => { c.AddProfile(new SqlProfile()); });
            Mappings.Default = new Mapper(config);
            UpdateMigration();
            AsyncContext.Run(AddDefaults.InsertDefaultDataAsync);
        }
        private static void UpdateMigration()
        {
            try
            {
                var migratorConfig = new SqlServerPersistence.Migrations.Configuration();
                var dbMigrator = new DbMigrator(migratorConfig);
                dbMigrator.Update();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
