using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsaGram.Presentiation.Controllers
{
    [ApiController]
    [Route("api/bankaccount")]
    public class BankAccountController : ControllerBase
    {
        private readonly ISender _sender;
        public BankAccountController(ISender sender)
        {
           _sender = sender; 
        }

        [HttpGet]
        public async Task<IActionResult> GetBankAccounts([FromQuery] BankAccountParameters bankAccount)
        {
            var result = await _sender.Send(new GetBankAccountsQuery(bankAccount));
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetBankAccount(Guid id)
        {
            var result = await _sender.Send(new GetBankAccountQuery(id));
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBankAccount(BankAccountForCreateDTO bankAccount)
        {
            var bank = await _sender.Send(new CreateBankAccountCommand(bankAccount));
            return NoContent();
        }

        [HttpPost("{id:guid}/update")]

        public async Task<IActionResult> UpdateBankAccount(Guid id, BankAccountForCreateDTO bankAccount)
        {
            var bank = await _sender.Send(new UpdateBankAccountCommand(id, bankAccount));
            return NoContent();
        }

        [HttpPost("{id:guid}/delete")]
        public async Task<IActionResult> DeleteBankAccount(Guid id)
        {
            var bank = await _sender.Send(new DeleteBankAccountCommand(id));
            return NoContent();
        }
    }
}
