using _3T.StaffSphere.Application.StaffSphere;
using _3T.StaffSphere.Domain.StaffSphere;
using _3T.StaffSphere.Persistence.PersistedObject;
using Microsoft.AspNetCore.Mvc;

namespace _3T.StaffSphere.RestApp.Controller
{
    public class PersonController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<StoredPerson>>> GetAllPerson()
        {
            return Ok(await Mediator.Send(new GetPeopleQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreatePerson(StoredPerson storedPerson)
        {
            return Ok(await Mediator.Send(new InsertPersonCommand(storedPerson)));
        }
    }
}
