﻿using MicroservicesTemplate.Common.Controller;
using ITManagementAPI.Application.Contact.Commands;
using ITManagementAPI.Application.Contact.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITManagementAPI.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        public async Task<List<ContactVm>> Get()
        {
            return await Mediator.Send(new GetContactsQuery());
        }

        [HttpGet("{email}")]
        public async Task<ContactVm> Get(string email)
        {
            return await Mediator.Send(new GetContactByEmailQuery { Email = email });
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] CreateContactCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<bool> Update(UpdateContactCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
