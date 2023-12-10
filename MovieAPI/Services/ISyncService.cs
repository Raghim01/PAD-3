using Common.Models;
using MongoDB.Driver.Core.Operations;
using System.Net.Http;

namespace MovieAPI.Services
{
    public interface ISyncService<T> where T : MongoDocument
    {
        HttpResponseMessage Upsert(T record);
        HttpResponseMessage Delete(T record);
    }
}
