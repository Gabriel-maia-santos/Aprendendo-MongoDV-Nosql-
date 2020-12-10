using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nyous.noSql.Domains;
using Nyous.noSql.Interfaces.Repositories;

namespace Nyous.noSql.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase {

        private readonly IEventoRepository  _eventoRepository;

        public EventosController(IEventoRepository eventoRepository) {
            _eventoRepository = eventoRepository;
        }

        [HttpPost]
        public ActionResult<EventoDomain> Post(EventoDomain evento) {

            try 
	        {
                _eventoRepository.Adicionar(evento);
                return Ok(evento);
	        }

	        catch (Exception ex)
	        {
                return BadRequest(ex.Message);
	         }
        }

        [HttpGet]
        public ActionResult<List<EventoDomain>> Get() {
            try {
                var eventos = _eventoRepository.Listar();
                return Ok(eventos);
            }
            catch (System.Exception ex) {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<List<EventoDomain>> GetById(string id) {
            try {
                var eventos = _eventoRepository.BuscarPorId(id);
                return Ok(eventos);
            }
            catch (System.Exception ex) {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut("{id}")]
        public ActionResult Put(string id, EventoDomain evento) {
            try {
                _eventoRepository.Atualizar(id, evento);
                return Ok();
            }
            catch (System.Exception ex) {

                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public ActionResult Delete(string id) {
            try {
                _eventoRepository.Remover(id);
                return Ok();
            }
            catch (System.Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}
