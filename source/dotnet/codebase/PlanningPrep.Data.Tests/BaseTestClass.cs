using System;
using System.Collections.Specialized;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlanningPrep.Data.Tests
{
    public abstract class BaseTestClass
    {
        protected static bool IsDatabaseLoaded;
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            if(!IsDatabaseLoaded)
            {
                RebuildTestDatabase();
            }
            DAOFactory.Initialize();
        }
        
        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
        }

        private const string SCRIPT_PATH = @"C:\Development\nqf-oplm\R&D\BuidDatabaseApp\Test Scripts\{0}\{1}";

        private static void RebuildTestDatabase()
        {
            Server dbServer = new Server("(local)");
            Database database = new Database(dbServer, "PlanningPrep-UnitTest");
            try
            {
                // Create the database if does not exist
                if (dbServer.Databases["PlanningPrep-UnitTest"] == null)
                {
                    database.Create();
                    dbServer.Refresh();
                }
                database.Refresh();

                database.ExecuteNonQuery(GetDbRebuildScripts(), ExecutionTypes.Default);
                database.Refresh();

                IsDatabaseLoaded = true;
            }
            catch (Exception exc)
            {
                IsDatabaseLoaded = false;
                Exception excToUse = exc.InnerException ?? exc;
                throw new InvalidOperationException("Unit Test databases could not be created.", excToUse);
            }
            //finally
            //{
            //    if (database != null)
            //        database = null;

            //    if (dbServer != null)
            //        dbServer = null;
            //}
        }

        public static StringCollection GetDbRebuildScripts()
        {
            StringCollection scripts = new StringCollection();
            // Step 1: Rebuild Table Schema, Indexs, Keys, Contraints in a master script
            scripts.Add(File.ReadAllText(string.Format(SCRIPT_PATH, "schema", "spRebuildTables.schema.sql")));
            // Step 2: Script all user defined functions
            // Step 3: Script all views
            // Step 4: Script all stored procedures
            scripts.Add(File.ReadAllText(string.Format(SCRIPT_PATH, "storedProcs", "spRebuild-All-StoredProcs.sql")));
            // Step 5 and/or 2: Script all test data into tables.

            return scripts;
        }
    }
}
