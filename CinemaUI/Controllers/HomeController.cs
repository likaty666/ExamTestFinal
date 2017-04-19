using Cinema.DataLayer.DBLayer;
using Cinema.Models;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CinemaUI.Controllers
{
    public class TravelMode
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    [RequireHttps]

    public class HomeController : Controller
    {
        IEnumerable<TravelMode> list = new List<TravelMode>(){
        new TravelMode{id = 1 , name = "Car"},
        new TravelMode{id = 2 , name = "Bike"},
        new TravelMode{id = 3 , name = "Public transport"},
        new TravelMode{id = 4 , name = "On foot"}
        };

        IGenericRepository<Film> repofilm;
        IGenericRepository<Genre> repogen;
        IGenericRepository<Hall> repohall;
        IGenericRepository<Photo> repopic;
        IGenericRepository<SessionDate> reposes;
        IGenericRepository<Stat> repostat;
        IGenericRepository<Ticket> repoticket;
       
        public HomeController(IGenericRepository<Film> repofilm, IGenericRepository<Genre> repogen, IGenericRepository<Hall> repohall,
               IGenericRepository<Photo> repopic, IGenericRepository<SessionDate> reposes, IGenericRepository<Stat> repostat,
               IGenericRepository<Ticket> repoticket)
        {
            this.repofilm = repofilm;
            this.repogen = repogen;
            this.repohall = repohall;
            this.repopic = repopic;
            this.reposes = reposes;
            this.repostat = repostat;
            this.repoticket = repoticket;
            CultureInfo cult = new CultureInfo("en-Us");
            Thread.CurrentThread.CurrentCulture = cult;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            DateTime date = DateTime.Now;
            ViewModelFilmRepository repo = new ViewModelFilmRepository(repofilm, repopic);
            
            var model = repo.GetAll();
          
            ViewBag.Ses = reposes.GetAll();
            return View(model);

                   }

        public ActionResult Contact()
        {

            ViewBag.travelmode = new SelectList(list, "id", "name");
            return View();
        }
    }
}