using System;
using Core2WebApi.Data;

namespace Core2WebApi.Services.InquiryProcessing
{
    public interface IPagedDataRequestFactory
    {
         PagedDataRequest Create(Uri requestUri);
    }
}