using Cinema.DataLayer.DBLayer;
using Cinema.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class ViewModelSessRepository
    {
        IGenericRepository<Hall> repohall;

        IGenericRepository<SessionDate> reposes;

        public ViewModelSessRepository(IGenericRepository<Hall> repohall, IGenericRepository<SessionDate> reposes)
        {
            this.repohall = repohall;
            this.reposes = reposes;
        }

        public IEnumerable<ViewModelSess> GetAll()
        {
            return from s in reposes.GetAll().AsQueryable()
                   join p in repohall.GetAll().AsQueryable() on s.hall_id equals p.hall_id into grp
                   from gr in grp.DefaultIfEmpty()

                   select new ViewModelSess
                   {
                       ses_id = s.ses_id,
                       seats=gr.seats,
                       name=gr.name,
                       statuss= gr.stat_id,
                       sesDate=s.sesDate,
                       time=s.timeIsh
                   };

        }

    }
}