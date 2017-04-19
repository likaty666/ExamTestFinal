using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelFilmRepository
    {
        IGenericRepository<Film> repofilm;
        IGenericRepository<Photo> repopic;
        public ViewModelFilmRepository(IGenericRepository<Film> repofilm, IGenericRepository<Photo> repopic)
        {
            this.repopic = repopic;
            this.repofilm = repofilm;
        }

        public IEnumerable<ViewModelFilm> GetAll()
        {
            return from f in repofilm.GetAll().AsQueryable()
                   join p in repopic.GetAll().AsQueryable() on f.film_id equals p.film_id into grp
                   from gr in grp.DefaultIfEmpty() 

                   select new ViewModelFilm
                   {
                       film_id = f.film_id,
                       title = f.title,
                       about = f.about,
                       director = f.director,
                       starring = f.starring,
                       BeginDate = (DateTime?)f.beginDate,
                       photo_id = gr.photo_id,
                       isMain = (bool?)gr.isMain,
                       pathPhoto = gr.pathPhoto,
                       trailer=f.trailer,
                       catalog=gr.catalog
                   };
        }
    }
}