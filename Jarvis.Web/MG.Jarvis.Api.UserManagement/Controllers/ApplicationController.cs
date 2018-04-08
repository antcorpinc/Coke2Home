using AutoMapper;
using MG.Jarvis.Api.UserManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.UserManagement.Controllers
{
    /// <summary>
    /// Controller to perform the CRUD operations for MG Application Entity
    /// </summary>
    [Produces("application/json")]
    [Route("api/Application")]
    public class ApplicationController :Controller
    {

        private readonly IRepository<Entities.Application> _repository;
        public ApplicationController(IRepository<Entities.Application> repository)
        {
            _repository = repository;
        }

        // GET: api/Application
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Models.Application> Get()
        {
            var list = Mapper.Map<IEnumerable<Models.Application>>(_repository.Get());
            if (list != null && list.Count() > 0)
                return list.Where(a => a.IsActive == true);

            return list;
        }

        // PUT: api/Application/5
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Models.Application model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = _repository.GetById(model.Id);
            Mapper.Map<Models.Application, Entities.Application>(model, entity);
            _repository.Update(entity);
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Models.Base.Application model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Insert(Mapper.Map<Entities.Application>(model));
            _repository.Save();

            return Ok();
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            _repository.Delete(id);
            return Ok();
        }
    }


}




