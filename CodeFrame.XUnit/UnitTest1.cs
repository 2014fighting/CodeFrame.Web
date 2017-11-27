using System;
using System.Collections.Generic;
using System.Linq;
using CodeFrame.Models;
using CodeFrame.Models.DbModel;
using CodeFrame.Service.Service;
using CodeFrame.Service.ServiceInterface;
using CodeFrame.UnitOfWork;
using CodeFrame.XUnit.Entity;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CodeFrame.XUnit
{
    public class UnitTest1
    {
        private readonly InMemoryContext _db;

        
        public UnitTest1()
        {
            _db = new InMemoryContext();
         
                _db.AddRange(TestCountries);
                _db.AddRange(TestCities);
                _db.AddRange(TestTowns); 
            _db.AddRange(TestUsers);
            _db.SaveChanges();
        }
        [Fact]
        public void TestMethod1()
        {
            var repository = new Repository<City>(_db);
            var city = repository.GetEntities().ToList();
            var s = "akjdflsjfe2awfjwjafwljfe";
            var res = s.Count(i => i.ToString() == "a");
            Assert.Equal(3, res);
        }

        protected static List<Country> TestCountries => new List<Country>
        {
            new Country {Id = 1, Name = "A"},
            new Country {Id = 2, Name = "B"}
        };

        public static List<City> TestCities => new List<City>
        {
            new City { Id = 1, Name = "A", CountryId = 1},
            new City { Id = 2, Name = "B", CountryId = 2},
            new City { Id = 3, Name = "C", CountryId = 1},
            new City { Id = 4, Name = "D", CountryId = 2},
            new City { Id = 5, Name = "E", CountryId = 1},
            new City { Id = 6, Name = "F", CountryId = 2},
        };

        public static List<Town> TestTowns => new List<Town>
        {
            new Town { Id = 1, Name="TownA", CityId = 1 },
            new Town { Id = 2, Name="TownB", CityId = 2 },
            new Town { Id = 3, Name="TownC", CityId = 3 },
            new Town { Id = 4, Name="TownD", CityId = 4 },
            new Town { Id = 5, Name="TownE", CityId = 5 },
            new Town { Id = 6, Name="TownF", CityId = 6 },
        };

        public static List<Entity.UserInfo> TestUsers => new List<Entity.UserInfo>
        {
           new Entity.UserInfo{Id=1,CreteTime =DateTime.Now,UserName = "wenqing",PhoneNo ="2345678",Password ="123456"},
            new Entity.UserInfo{Id=2,CreteTime =DateTime.Now,UserName = "wenqing1",PhoneNo ="2345678",Password ="123456"}
        };

    }
}
