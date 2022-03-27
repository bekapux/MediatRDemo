using DemoLibrary.DataAccess;
using DemoLibrary.Models;
using DemoLibrary.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoLibrary.Handlers
{
    public class GetPersonByIDHandler : IRequestHandler<GetPersonByIDQuery, PersonModel>
    {
        private readonly IMediator mediator;

        public GetPersonByIDHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<PersonModel> Handle(GetPersonByIDQuery request, CancellationToken cancellationToken)
        {
            var listOfPeople = await mediator.Send(new GetPersonListQuery());
            var person = listOfPeople.FirstOrDefault(p => p.Id == request.ID);
            return person;
        }
    }
}
