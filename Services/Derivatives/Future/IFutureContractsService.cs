using System.Net.Http;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.Services.Derivatives.Future
{
    public interface IFutureContractsService
    {
         PagedDataInquiryResponse<FutureContract> GetContracts(HttpRequestMessage requestMessage);

         FutureContract GetById(int id);
    }
}