using Application.Commands;
using Application.Queries;
using Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/invoice-state")]
    public class InvoiceStateController : ControllerBase
    {
        private readonly ISender _sender;
        public InvoiceStateController(ISender sender)
        {
         _sender = sender;   
        }


        [HttpGet]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _sender.Send(new GetInvoicesQuery());
            return Ok(invoices);
        }



        [HttpPost("create")]
        public async Task<IActionResult> CreateInvoice([FromForm] UploadFileDTO uploadFileDTO)
        {
            if (uploadFileDTO.File == null)
                return BadRequest("File is required.");

            using var ms = new MemoryStream();
            await uploadFileDTO.File.CopyToAsync(ms);

            var invoice = await _sender.Send(new UploadFileInvoiceCommand(
                uploadFileDTO.File.FileName, uploadFileDTO.File.ContentType, ms.ToArray(), FileType.Invoice));

            return Ok(invoice);
        }

        // download  update get(id)

        [HttpPost("{id:guid}/delete")]

        public async Task<IActionResult> DeleteInvoice(Guid id)
        {
            var invoice = await _sender.Send(new DeleteInvoiceCommand(id));
            return NoContent();
        }

        [HttpGet("{id:guid}/download")]
        public async Task<IActionResult> Download(Guid id)
        {
            var file = await _sender.Send(new DownloadFileQuery(id));
            if (file == null)
                return NotFound("notfound file.");
            return File(file.Data, file.ContentType, file.Name);
        }
        

    }
}
 