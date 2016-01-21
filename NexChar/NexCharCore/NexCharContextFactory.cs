using System.Data.Entity.SqlServer;

namespace NexCharCore
{
    public static class NexCharContextFactory
    {
        private static NexCharContextBase _nexCharContext;

        public static NexCharContextBase NexCharContext
        {
            get
            {
                return _nexCharContext ?? (new NexCharContext());
                
            }
            set { _nexCharContext = value; }
        }

        public static void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = SqlProviderServices.Instance;
        }
    }
}