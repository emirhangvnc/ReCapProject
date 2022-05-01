using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenderDal:IGenderDal
    {
        public void Add(Gender entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var added = context.Entry(entity);
                added.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Gender entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var deleted = context.Entry(entity);
                deleted.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void Update(Gender entity)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                var updated = context.Entry(entity);
                updated.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Gender Get(Expression<Func<Gender, bool>> filter)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                return context.Set<Gender>().SingleOrDefault();
            }
        }

        public List<Gender> GetAll(Expression<Func<Gender, bool>> filter = null)
        {
            using (RentalCarContext context = new RentalCarContext())
            {
                return filter == null ?
                    context.Set<Gender>().ToList() :
                    context.Set<Gender>().Where(filter).ToList();
            }
        }
    }
}
