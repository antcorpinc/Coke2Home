using AutoMapper;
using MG.Jarvis.Api.UserManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.UserManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/UserType")]
    public class UserTypeController : Controller
    {
        IRepository<Entities.UserType> _repository = null;
        public UserTypeController(IRepository<Entities.UserType> repository)
        {
            _repository = repository;
        }


        // GET: api/Application
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Models.UserType> Get()
        {
            var list = Mapper.Map<IEnumerable<Models.UserType>>(_repository.Get());
            if (list != null && list.Count() > 0)
                return list.Where(a => a.IsActive == true);

            return list;
        }

        // PUT: api/Application/5
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Models.UserType model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = _repository.GetById(model.Id);
            Mapper.Map<Models.UserType, Entities.UserType>(model, entity);
           _repository.Update(entity);
            return Ok(); ;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Models.Base.UserType model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Insert(Mapper.Map<Entities.UserType>(model));
            _repository.Save();

            return Ok();
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] int id)
        {
            if (id <= 0)
            {
                return BadRequest(ModelState);
            }
            _repository.Delete(id);
            return Ok();
        }
    }


}
