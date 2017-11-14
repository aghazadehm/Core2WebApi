using System;
using System.Net;
using System.Net.Http;
using Core2WebApi.Common;
using Core2WebApi.Common.Extensions;
using Core2WebApi.Data;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Core2WebApi.Services.InquiryProcessing
{
    public class PagedDataRequestFactory : IPagedDataRequestFactory
    {
        public const int DefaultPageSize = 25;

        public const int MaxPageSize = 50;

        private readonly ILogger<PagedDataRequestFactory> _log;

        public PagedDataRequestFactory(ILogger<PagedDataRequestFactory> logger)
        {
            _log = logger;
        }

        public PagedDataRequest Create(Uri requestUri)
        {
            int? pageNumber = null;
            int? pageSize = null;

            try
            {
                var valueCollection = QueryHelpers.ParseQuery(requestUri.Query); // requestUri.ParseQueryString();
                if (valueCollection.Count != 0)
                {
                    pageNumber = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageNumber]);
                    pageSize = PrimitiveTypeParser.Parse<int?>(valueCollection[Constants.CommonParameterNames.PageSize]);
                }
            }
            catch (Exception e)
            {
                _log.LogError(null, e, "Error parsing input", null); // Error("Error parsing input", e);

                throw new HttpRequestException(HttpStatusCode.BadRequest.ToString(), e);
            }

            pageNumber = pageNumber.GetBoundedValue(Constants.Paging.DefaultPageNumber, Constants.Paging.MinPageNumber);
            pageSize = pageSize.GetBoundedValue(DefaultPageSize, Constants.Paging.MinPageSize, MaxPageSize);

            return new PagedDataRequest(pageNumber.Value, pageSize.Value);
        }
    }
}