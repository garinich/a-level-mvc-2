using Animals.Models;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Animals.Controllers.Api
{
    public class HousesTestController : ApiController
    {

        private readonly AnimalsManager _animalsManager;
        private readonly HomesManager _homesManager;
        private readonly Mapper _mapper;

        public HousesTestController()
        {
            _animalsManager = new AnimalsManager();
            _homesManager = new HomesManager();

            var conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnimalModel, AnimalViewModel>();
                cfg.CreateMap<HomeModel, HomeViewModel>();

                cfg.CreateMap<AnimalViewModel, AnimalModel>();
                cfg.CreateMap<HomeViewModel, HomeModel>();
            });

            _mapper = new Mapper(conf);
        }
        // GET: api/Test
        public IEnumerable<HomeViewModel> Get()
        {
            var homes = _homesManager.GetAllHomes();
            var homesMap = _mapper.Map<IList<HomeViewModel>>(homes);
            return homesMap;
        }

        // GET: api/Test/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
