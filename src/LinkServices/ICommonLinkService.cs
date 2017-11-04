using System.Net.Http;
using Core2WebApi.Models;

namespace Core2WebApi.LinkServices
{
    public interface ICommonLinkService
    {
        void AddPageLinks(IPageLinkContaining linkContainer,
            string currentPageQueryString,
            string prevoiusPageQueryString,
            string nextPageQueryString);

        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }
}