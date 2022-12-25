﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
            return c.Set<T>().ToList();
        }

        public void Insert(T t)
        {
            throw new NotImplementedException();
        }

		public List<T> GetListAll(Expression<Func<T, bool>> filter)
		{
			using var c = new Context();
            return c.Set<T>().Where(filter).ToList();
		}

		public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
