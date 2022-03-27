using DemoLibrary.Commands;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<PersonModel>> GetPeople()
        {
            var result = await mediator.Send(new GetPersonListQuery());
            return result;
        }

        [HttpGet("{id}")]
        public async Task<PersonModel> get(int id)
        {
            var result = await mediator.Send(new GetPersonByIDQuery(id));
            return result;
        }

        [HttpPost]
        public async Task<PersonModel> Post(PersonModel model)
        {
            var result = await mediator.Send(new InsertPersonCommand(model.FirstName, model.LastName));
            return result;
        }
    }
}
