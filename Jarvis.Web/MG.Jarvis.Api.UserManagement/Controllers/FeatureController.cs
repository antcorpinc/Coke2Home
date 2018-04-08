using AutoMapper;
using MG.Jarvis.Api.UserManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.UserManagement.Controllers
{    /// <summary>
     /// Controller to perform the CRUD operations for Feature Entity
     /// </summary>
    [Produces("application/json")]
    [Route("api/Feature")]
    public class FeatureController : Controller
    {
        private readonly IRepository<Entities.Feature> _repository;
        public FeatureController(IRepository<Entities.Feature> repository)
        {
            _repository = repository;
        }

        // GET: api/Application
        [HttpGet]
        [Route("Get")]
        public IEnumerable<Models.Feature> Get()
        {
            var list = Mapper.Map<IEnumerable<Models.Feature>>(_repository.Get());
            if (list != null && list.Count() > 0)
                return list.Where(a => a.IsActive == true);

            return list;
        }

        // PUT: api/Application/5
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Models.Feature model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = _repository.GetById(model.Id);
            Mapper.Map<Models.Feature, Entities.Feature>(model, entity);
            _repository.Update(entity);
            return Ok();
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Models.Base.Feature model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Insert(Mapper.Map<Entities.Feature>(model));
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

