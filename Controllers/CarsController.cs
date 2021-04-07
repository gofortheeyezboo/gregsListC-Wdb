using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregsListC_Wdb.Services;
using gregsListC_Wdb.Models;


namespace gregsListC_Wdb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _service;
        public CarsController(CarsService service){
            _service = service;
        }
    
    [HttpGet]
       public ActionResult<IEnumerable<Car>> Get(){
            try {
                return Ok(_service.Get());
        } catch (Exception e){
                return BadRequest(e.Message);
            }    
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar){
            try{
                return Ok(_service.Create(newCar));
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(int carId){
            try{
                return Ok(_service.Get(carId));
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Car> DeleteCar(int id){
            try{
                return Ok(_service.Delete(id));
            } catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Car> EditCar([FromBody] Car editedCar, int id){
            try{
                editedCar.Id = id;
                return Ok(_service.Edit(editedCar));
            } catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}