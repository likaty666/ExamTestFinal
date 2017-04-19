using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using ExamTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamTest1.Controllers
{
    public class FilmController : Controller
    {
        // GET: Film
        IGenericRepository<Film> repofilm;
        IGenericRepository<Genre> repogen;
        IGenericRepository<Hall> repohall;
        IGenericRepository<Photo> repopic;
        IGenericRepository<SessionDate> reposes;
        IGenericRepository<Stat> repostat;
        IGenericRepository<Ticket> repoticket;
        List<ViewModelTicket> ls;
        public FilmController(IGenericRepository<Film> repofilm, IGenericRepository<Genre> repogen, IGenericRepository<Hall> repohall,
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
            ls = new List<ViewModelTicket>();
        }

        public ActionResult Index()
        {
            ViewModelFilmRepository repo = new ViewModelFilmRepository(repofilm,repopic);
            var model = repo.GetAll();
            ViewBag.Ses = reposes.GetAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id) {
            ls.RemoveAt(id);
            return RedirectToAction("Cart");
        }
        public ActionResult Show(int id)
        {
            ViewModelFilmRepository repo = new ViewModelFilmRepository(repofilm, repopic);
            var model = repo.GetAll().Where(x => x.film_id == id);
            ViewBag.Ses = reposes.FindBy(x => x.film_id == id);
            //var model = repopic.FindBy(x => x.film_id == id);
            //ViewBag.FilmId = id;
            return View(model);
        }

        public ActionResult Seat(int? ids)
        {
            ViewModelSessRepository repo = new ViewModelSessRepository(repohall, reposes);
            var model = repo.GetAll().Where(x => x.ses_id == ids);
            ViewBag.Booked = repoticket.FindBy(x => x.ses_id == ids).Select(y=>y.seat);
            return View(model);
        }
        [System.Web.Services.WebMethod]
        public ActionResult Cart(List<string> id) {

            if (ls.Count==0)
            {
                int sid = 0;
                foreach (var x in id)
                {
                    sid++;
                }
                sid--;
                int ses_id = Convert.ToInt32(id.ElementAt(sid));
                int fid = (int)reposes.Get(ses_id).film_id;

               

                int temp = 0;
                foreach (var item in id)
                {
                    if (temp != sid)
                    {
                        ViewModelTicket t = new ViewModelTicket()
                        {
                            film_id = fid,
                            title = repofilm.Get(fid).title,
                            hall = reposes.Get(ses_id).hall_id,
                            ses_id=ses_id,
                            time = reposes.Get(ses_id).timeIsh,
                            price = 55,
                            sessionDate = reposes.Get(ses_id).sesDate,
                            seat = Convert.ToInt32(item)
                        };
                        ls.Add(t);
                        temp++;
                    }

                }
            }
            Session["ShoppingCart"] = ls;
            var model = ls;
            return View(model);
        }
        [HttpPost]
        public ActionResult Cart() {
            List<ViewModelTicket> tls= (List<ViewModelTicket>)Session["ShoppingCart"];
            List<Ticket> temp = new List<Ticket>();
            foreach (var x in tls) {
                Ticket t = new Ticket()
                {
                    film_id = x.film_id,
                    hall_id = x.hall,
                    price = x.price,
                    ses_id = x.ses_id,
                    seat = x.seat
                };
                temp.Add(t);
            }
            if (ModelState.IsValid)
            {
                foreach (var item in temp)
                {
                    repoticket.AddOrUpdate(item);
                }
               
                TempData["notice"] = "You've successfully booked tickets";
                return RedirectToAction("Index");
            }

            return View(tls);
        }


        public ActionResult RedirectToPrevious(String defaultAction, String defaultController)
        {
            if (Session == null || Session["PrevUrl"] == null)
            {
                return RedirectToAction(defaultAction, defaultController);
            }

            String url = ((Uri)Session["PrevUrl"]).PathAndQuery;

            if (Request.Url != null && Request.Url.PathAndQuery != url)
            {
                return Redirect(url);
            }

            return RedirectToAction(defaultAction, defaultController);
        }

    }
}