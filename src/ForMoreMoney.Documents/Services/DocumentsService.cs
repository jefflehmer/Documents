using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForMoreMoney.Documents.Services
{
    public class DocumentsService : IDocumentsService
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

        public async Task<Stream> Get(Guid documentId)
        {
            return null;
        }

        public async Task<Stream> Get(string name)
        {
            return null;
        }

        public async Task<bool> Save(Stream document)
        {
            return true;
        }

        public async Task<bool> Delete(Guid documentId)
        {
            return false;
        }

        public async Task<bool> Delete(string filename)
        {
            return false;
        }
    }
}
