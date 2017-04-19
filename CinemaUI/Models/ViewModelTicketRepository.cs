using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelTicketRepository
    {
        IGenericRepository<Film> repofilm;
        IGenericRepository<SessionDate> reposes;
        IGenericRepository<Ticket> repoticket;

        public ViewModelTicketRepository(IGenericRepository<Film> repofilm, IGenericRepository<SessionDate> reposes, IGenericRepository<Ticket> repoticket)
        {
            this.repofilm = repofilm;
            this.reposes = reposes;
            this.repoticket = repoticket;
        }
        public IEnumerable<ViewModelTicket> GetAll()
        {
            return from t in repoticket.GetAll().AsQueryable()
                   join f in repofilm.GetAll().AsQueryable() on t.film_id equals f.film_id
                   join h in reposes.GetAll().AsQueryable() on t.hall_id equals h.hall_id
                   into grp
                   from gr in grp.DefaultIfEmpty()

                   select new ViewModelTicket
                   {
                       ticket_id = t.ticket_id,
                       hall = gr.hall_id,
                       title = f.title,
                       user_id=t.user_id,
                       price = t.price,
                       sessionDate = gr.sesDate,
                       seat = t.seat,
                       time=gr.timeIsh,
                       hall_id=gr.hall_id,
                       ses_id=gr.ses_id
                   };


        }
    }
}