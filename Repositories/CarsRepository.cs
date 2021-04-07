using System;
using System.Collections.Generic;
using System.Data;
using gregsListC_Wdb.Models;
using Dapper;

namespace gregsListC_Wdb.Repositories
{
    public class CarsRepository
    {
        public readonly IDbConnection _db;

        public CarsRepository(IDbConnection db){
            _db = db;
        }
        internal IEnumerable<Car> Get(){
            string sql = "SELECT * FROM cars;";
            return _db.Query<Car>(sql);
        }
        internal Car GetCar(int Id){
            string sql = "SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, new { Id });
        }
        internal Car Create(Car newCar){
            string sql = @"
            INSERT INTO cars
            (make, model, year, price, description, imgUrl)
            VALUES
            (@Make, @Model, @Year, @Price, @Description, @ImgUrl);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCar);
            newCar.Id = id;
            return newCar;
        }
        internal Car Edit(Car targetCar){
            string sql = @"
            UPDATE cars
            SET
                make = @Make,
                model = @Model,
                year = @Year,
                price = @Price,
                description = @Description,
                imgUrl = @ImgUrl
            WHERE id = @Id;
            SELECT * FROM cars WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Car>(sql, targetCar);
        }

        internal void Delete(int id){
            string sql = "DELETE FROM cars WHERE id = @Id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}