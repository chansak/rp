using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RP.Utilities
{
    public static class AppSettingHelper
    {
        public static int PageSize
        {
            get
            {
                int pageSize = 10;
                if (!int.TryParse(ConfigurationManager.AppSettings["PagingPagesize"], out pageSize))
                    pageSize = 10;

                return pageSize;
            }
        }

        public static int PageTotalCount
        {
            get
            {
                int pageTotalCount = 0;
                if (!int.TryParse(ConfigurationManager.AppSettings["PagingTotalcount"], out pageTotalCount))
                    pageTotalCount = 0;

                return pageTotalCount;
            }
        }

        public static string PageDirection
        {
            get
            {
                string pageDirection = "ASC";
                if (ConfigurationManager.AppSettings["PagingDirection"] != null)
                    pageDirection = ConfigurationManager.AppSettings["PagingDirection"];

                return pageDirection;
            }
        }
    }
}
