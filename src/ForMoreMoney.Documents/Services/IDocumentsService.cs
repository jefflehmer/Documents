using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;

namespace ForMoreMoney.Documents.Services
{
    public interface IDocumentsService
    {
        Task<int> Count();

        Task<List<string>> ListAll();

        // Task<Stream> Get(Guid documentId);

        Task<Stream> Get(string filename);

        Task<bool> Save(Stream stream);

        // Task<bool> Delete(Guid documentId);

        Task<bool> Delete(string filename);
    }
}
