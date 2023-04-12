using _3T.Gestproj.Domain.StaffSphere;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3T.Gestproj.Persistence;
using _3T.Framework.Persistence.Repository;
using _3T.Gestproj.Persistence.PersistedObject;

namespace _3T.Gestproj.Application.StaffSphere
{
    public class GetPeopleQuery: IRequest<IQueryable<StoredPerson>>
    {
    }

    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, IQueryable<StoredPerson>>
    {
        private readonly IBaseRepository<StoredPerson> _personRepository;
        public GetPeopleQueryHandler(IBaseRepository<StoredPerson> personRepository)
        {
            this._personRepository = personRepository;
        }
        public Task<IQueryable<StoredPerson>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            using (var connection = _personRepository.GetConnection())
            {
                return Task.FromResult(_personRepository.GetAll(connection));
            }
        }
    }
}
