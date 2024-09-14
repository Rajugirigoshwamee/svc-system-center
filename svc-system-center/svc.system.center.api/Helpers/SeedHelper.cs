using svc.birdcage.model.Interfaces.Dapper;

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
            string[] sqlFilesPaths = Directory.GetFiles("./Migrations/SP_Migration", "*.sql", SearchOption.TopDirectoryOnly);
            foreach (string sqlFilePath in sqlFilesPaths)
            {
                string text = File.ReadAllText(sqlFilePath);

                await DapperService.AddOrUpdateAsync<dynamic>("", new { });
            }
        }

        #endregion Seed Data

        #region Dispose

        public void Dispose() => GC.SuppressFinalize(this);

        #endregion Dispose
    }
}
