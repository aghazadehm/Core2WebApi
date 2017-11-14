using System.Collections.Generic;

namespace Core2WebApi.Models
{
    public interface ILinkContaining
    {
        List<Link> Links { get; set; }
        void AddLink(Link link);
    }
}