using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ForMoreMoney.Documents.Services
{
    public class DocumentsServiceDisk : IDocumentsService
    {
        //  public DocumentsServiceDisk(IWebHostEnvironment env)
        //  {
        //      this.Environment = env;
        //  }

        // TODO: inject IWebHostingEnvironment to get ContentRootPath instead of hard-coding the path
        private readonly string DataDirectory = @"C:\github\kendodragon\Documents\src\ForMoreMoney.Documents\Data";
        // public IWebHostEnvironment Environment { get; private set; }

        public async Task<int> Count()
        {
            try
            {
                var provider = new PhysicalFileProvider(this.DataDirectory);
                var contents = provider.GetDirectoryContents(string.Empty);
                return contents.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<string>> ListAll()
        {
            try
            {
                var provider = new PhysicalFileProvider(this.DataDirectory);
                var contents = provider.GetDirectoryContents(string.Empty);
                var toad =  contents.Select(i => i.Name).ToList();
                return toad;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Stream> Get(Guid documentId)
        {
            return null;
        }

        public async Task<Stream> Get(string filename)
        {
            try
            {
                return new FileStream(Path.Combine(this.DataDirectory, filename), FileMode.Open);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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
            File.Delete(Path.Combine(this.DataDirectory, filename));

            return true;
        }
    }
}
