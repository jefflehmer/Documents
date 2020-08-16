using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;

namespace ForMoreMoney.Documents.Services
{
    public interface IDocumentsService
    {
        Task<int> Count();

        Task<List<string>> ListAll();

        Task<MoneyDocument> Get(Guid id);

        Task<MoneyDocument> Get(string name);

        Task<bool> Save(MoneyDocument document);

        Task<bool> Delete(Guid documentId);
    }
}
