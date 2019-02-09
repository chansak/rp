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
        public static string GetDefaultWarehouseId
        {
            get
            {
                return "46EE6B5A-5E68-4CF8-844B-F3095878C8B2";
            }
        }
        public static int DefaultPriceValidityDays
        {
            get
            {
                int number = 0;
                if (ConfigurationManager.AppSettings["DefaultPriceValidityDays"] != null)
                    number = int.Parse(ConfigurationManager.AppSettings["DefaultPriceValidityDays"]);

                return number;
            }
        }
        public static int DefaultDeliveryDays
        {
            get
            {
                int number = 0;
                if (ConfigurationManager.AppSettings["DefaultDeliveryDays"] != null)
                    number = int.Parse(ConfigurationManager.AppSettings["DefaultDeliveryDays"]);

                return number;
            }
        }
        public static string CacheExpirationMinute
        {
            get
            {
                string cacheExpirationMinute = "60";
                if (ConfigurationManager.AppSettings["CacheExpirationMinute"] != null)
                    cacheExpirationMinute = ConfigurationManager.AppSettings["CacheExpirationMinute"];

                return cacheExpirationMinute;
            }
        }
    }
}
