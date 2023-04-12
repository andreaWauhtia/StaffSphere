using _3T.Framework.Persistence.Repository;
using _3T.Gestproj.Persistence.PersistedObject;
using Dapper.Contrib.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3T.Gestproj.Application.StaffSphere
{
    public class InsertPersonCommand: IRequest<Unit>
    {
        public readonly StoredPerson storedPerson;
        public InsertPersonCommand(StoredPerson storedPerson)
        {
            this.storedPerson = storedPerson;
        }
    }
    public class InsertPersonCommandHandler : IRequestHandler<InsertPersonCommand, Unit>
    {
        private readonly IBaseRepository<StoredPerson> _personRepository;

        public InsertPersonCommandHandler(IBaseRepository<StoredPerson> personRepository)
        {
            _personRepository = personRepository;
        }

        public Task<Unit> Handle(InsertPersonCommand request, CancellationToken cancellationToken)
        {
            using (var connection = _personRepository.GetConnection())
            {
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        if (request.storedPerson != null)
                        {
                            _personRepository.CreateAsync(connection, request.storedPerson, transaction).Wait();
                            transaction.Commit();
                        }
                        return Task.FromResult(Unit.Value);
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
