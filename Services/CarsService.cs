using System;
using System.Collections.Generic;
using gregsListC_Wdb.Models;
using gregsListC_Wdb.Repositories;

namespace gregsListC_Wdb.Services
{
    public class CarsService
    {
        private readonly CarsRepository _repo;

        public CarsService(CarsRepository repo){
            _repo = repo;
        }
        internal IEnumerable<Car> Get(){
            return _repo.Get();
        }
        internal Car Get(int id){
            Car car = _repo.GetCar(id);
            if(car == null){
                throw new Exception("Invalid ID");
            }
            return car;
        }
        internal Car Create(Car newCar){
            return _repo.Create(newCar);
        }
        internal Car Edit(Car editCar){
            Car original = Get(editCar.Id);
            original.Description = editCar.Description != null ? editCar.Description : original.Description;
            original.Year = editCar.Year != null ? editCar.Year : original.Year;
            original.Make = editCar.Make != null ? editCar.Make : original.Make;
            original.Model = editCar.Model != null ? editCar.Model : original.Model;
            original.Price = editCar.Price != null ? editCar.Price : original.Price;
            original.ImgUrl = editCar.ImgUrl != null ? editCar.ImgUrl : original.ImgUrl;

            return _repo.Edit(original);
        }
        internal Car Delete(int id){
            Car original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}