using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForMoreMoney.Documents.Services
{
    public class DocumentsTestService : IDocumentsService
    {
        public async Task<int> Count()
        {
            return 47;
        }

        public async Task<List<string>> ListAll()
        {
            return new List<string>
            {
                "Fred.txt",
                "Wilma.pdc",
                "Barney.tsv",
                "Betty.pdf",
            };
        }

        public async Task<MoneyDocument> Get(Guid id)
        {
            return new MoneyDocument
            {
                Id = id,
                Name = $"Dino-{id}",
            };
        }

        public async Task<MoneyDocument> Get(string name)
        {
            var documentId = Guid.NewGuid();
            return new MoneyDocument
            {
                Id = documentId,
                Name = $"Juliet-{documentId}",
            };
        }

        public async Task<bool> Save(MoneyDocument document)
        {
            return true;
        }

        public async Task<bool> Delete(Guid documentId)
        {
            return false;
        }
    }
}
