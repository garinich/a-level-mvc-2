using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Animals.Models;
using AutoMapper;
using BusinessLayer;
using BusinessLayer.Managers;
using BusinessLayer.Models;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity.Owin;

namespace Animals.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalsManager _animalsManager;
        private readonly HomesManager _homesManager;
        private readonly Mapper _mapper;

        public AnimalsController()
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

        public ActionResult Index()
        {
            var animals = _animalsManager.GetAllAnimals();
            var animalsMap = _mapper.Map<IList<AnimalViewModel>>(animals);
            var result = new GetAllAnimalViewModel {Animals = animalsMap, Lang = GetLang() };
            return View(result);
        }

        public ActionResult Homes()
        {
            var homes = _homesManager.GetAllHomes();
            var homesMap = _mapper.Map<IList<HomeViewModel>>(homes);
            var result = new GetAllHomeViewModel {Homes = homesMap, Lang = GetLang() };
            return View(result);
        }

        public string GetLang()
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            if (user != null)
            {
                var claimLang = user.Claims.FirstOrDefault(x => x.Type == "Lang");
                return claimLang != null ? claimLang.Value : "";
            }

            return "";
        }
    }
}
