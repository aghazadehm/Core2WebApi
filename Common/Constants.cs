namespace Core2WebApi.Common
{
    public class Constants
    {
        public static class MediaTypeNames
        {
            public const string ApplicationXml = "application/xml";
            public const string TextXml = "text/xml";
            public const string ApplicationJson = "application/json";
            public const string TextJson = "text/json";
        }

        public static class Paging
        {
            public const int MinPageSize = 1;
            public const int MinPageNumber = 1;
            public const int DefaultPageNumber = 1;
        }

        public static class CommonParameterNames
        {
            public const string PageNumber = "pageNumber";
            public const string PageSize = "pageSize";
        }

        public static class CommonLinkRelValues
        {
            public const string Self = "self";
            public const string All = "all";
            public const string CurrentPage = "currentPage";
            public const string PreviousPage = "previousPage";
            public const string NextPage = "nextPage";
        }

        public static class CommonRoutingDefinitions
        {
            public const string ApiSegmentName = "api";
            public const string ApiVersionSegmentName = "apiVersion";
            public const string CurrentApiVersion = "v1";
        }

        public static class SchemeTypes
        {
            public const string Basic = "basic";
        }

        public static class RoleNames
        {
            public const string Manager = "Manager";
            public const string SeniorWorker = "SeniorWorker";
            public const string JuniorWorker = "JuniorWorker";
        }

        public const string DefaultLegacyNamespace = "http://tempuri.org/";
        public class LoggingEvents
        {
            public const int GeneralITems = 1000;
            public const int ListItems = 1001;
            public const int GetItem = 1002;
            public const int InsertItem = 1003;
            public const int UpdateItem = 1004;
            public const int DeleteItem = 1005;

            public const int GetItemNotFound = 4000;
            public const int UpdateItemNotFound = 4001;
        }
    }
}