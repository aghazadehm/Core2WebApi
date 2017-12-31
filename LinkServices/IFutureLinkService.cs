using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace Core2WebApi.LinkServices
{
    public interface IFutureContractLinkService
    {
         void AddLinks(FutureContract contract);
         Link GetAllFutureContractsLink();
         void AddSelfLink(FutureContract contract);
         //void AddLinksToChildObjects(FutureContract contract);
         Link GetSelfLink(long contractId);
    }
}