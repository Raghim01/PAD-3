using Common.Models;
using System;
using System.Collections.Generic;

namespace MovieAPI.Repositories
{
    public interface IMongoRepository<T> where T : MongoDocument
    {
        List<T> GetAllRecords();
        T InsertRecord(T record);
        T GetRecordByID(Guid id);
        void UpsertRecord(T record);
        void DeleteRecord(Guid id);
    }
}
