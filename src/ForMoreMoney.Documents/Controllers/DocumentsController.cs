using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ForMoreMoney.Documents.Models;
using ForMoreMoney.Documents.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ForMoreMoney.Documents.Controllers
{
    [Route("")]
    [Produces("application/json")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentsService service;

        public DocumentsController(IDocumentsService service)
        {
            this.service = service;
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            try
            {
                // TODO: convert all endpoints to invoke commands rather than execute services directly
                return await this.service.Count();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<string>>> GetListAll()
        {
            try
            {
                return await this.service.ListAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /*
        [HttpGet("file/{documentId:Guid}")]
        public async Task<ActionResult<FileStreamResult>> GetById([FromRoute] Guid documentId)
        {
            try
            {
                return await this.service.Get(documentId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        */

        [HttpGet("file/{filename}")]
        public async Task<ActionResult<FileStreamResult>> GetByName([FromRoute] string filename)
        {
            try
            {
                var stream = await this.service.Get(filename);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut("save")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save([FromBody] string document, CancellationToken cancellationToken)
        {
            try
            {
                await this.service.Save(null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return this.Accepted();
        }

        // TODO: use documentId instead of name when go to real db
        [HttpPost("delete/{filename}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteDocument([FromRoute] string filename, CancellationToken cancellationToken)
        {
            try
            {
                var temp = new MoneyDocument();
                await this.service.Delete(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return this.Ok();
        }
    }
}
