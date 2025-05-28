using svc.birdcage.hawk.Interfaces.Dapper;
using System.IO;

namespace svc.system.center.api.Helpers
{
    public class SeedHelper : IDisposable
    {
        #region Object Declarations And Constructor

        private IDapperService DapperService { get; set; }

        public SeedHelper(IDapperService DapperRepository)
        {
            this.DapperService = DapperRepository;
        }

        #endregion Object Declarations And Constructor

        #region Seed Data

        public async Task Seed()
        {
            var directoryPath = "./Migrations/SP_Migration";
            var newDirectoryPath = "./Migrations/SP_Migration_Completed";
            string[] sqlFilesPaths = Directory.GetFiles(directoryPath, "*.sql", SearchOption.TopDirectoryOnly);
            foreach (string sqlFilePath in sqlFilesPaths)
            {
                string sql = File.ReadAllText(sqlFilePath);

                await DapperService.AddOrUpdateAsync<dynamic>(sql, new { }, type: System.Data.CommandType.Text);

                var fileName=sqlFilePath.Split("\\")[1];

                if (!Directory.Exists(newDirectoryPath))
                    Directory.CreateDirectory(newDirectoryPath);

                File.Move($"{directoryPath}/{fileName}", $"{newDirectoryPath}/{fileName}" );
                
            }
        }

        #endregion Seed Data

        #region Dispose

        public void Dispose() => GC.SuppressFinalize(this);

        #endregion Dispose
    }
}
