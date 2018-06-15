using System;
using System.Threading.Tasks;

namespace HtmlSquirrel
{
    public interface IRequester
    {
        string GetContent(string uriStr);
        string GetContent(Uri uri);
        Task<string> GetContentAsync(Uri uri);
    }
}