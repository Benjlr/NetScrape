using System.Threading.Tasks;

namespace NetScrape.Core.Request
{
    public interface ICustomRequest
    {
        public Task<string> LoadPage();
    }

}