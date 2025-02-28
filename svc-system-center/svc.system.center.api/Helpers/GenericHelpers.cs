namespace svc.system.center.api.Helpers
{
    public static class GenericHelpers
    {
        #region 1. Object Declarations and Constructor


        #endregion 1. Object Declarations and Constructor

        #region 2. Calculate Total Pages For Grid

        public static int CalculateTotalPages(dynamic total, int? pageSize)
        {
            var pages = Convert.ToDecimal(total) / pageSize;
            var response = pages < 1 ? 1 : Convert.ToInt32(Math.Ceiling(pages));
            return response;
        }

        #endregion 2. Calculate Total Pages For Grid
    }
}
