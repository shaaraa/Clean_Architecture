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
    public class getPersonByIdHandler : IRequestHandler<getPersonByIdQuery, PersonModel>
    {
        private readonly IMediator _mediator;

        public getPersonByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }   
        public async Task<PersonModel> Handle(getPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetPersonListQuery());
            return result.FirstOrDefault(x => x.Id == request.Id);
        }
    }
}
