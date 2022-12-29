using Microsoft.AspNetCore.Mvc;
using respositorUnitSw.Model;
using respositorUnitSw.Service;
using respositorUnitSw.View;
using System.Collections.Generic;

namespace respositorUnitSw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private IUnitOfWork dbff;
        private readonly IPersonService _service;

        public ValuesController(IPersonService service)
        {
            _service = service;

        }

        //private void AddDataInMemory()
        //{
        //    db.WorkRepository.Insert(new Work() { Name = "333" });
        //    db.Save();
        //}

        // GET api/values
        [HttpGet]
        public ActionResult<ServiceListResponse<VM>> Get()
        {
            ServiceListResponse<VM> response = _service.GetPerson();
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] VM value)
        {
            // db.Persons.Add(new Person() { Age = 12, Name = value.Name });
            //db.Complete();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
