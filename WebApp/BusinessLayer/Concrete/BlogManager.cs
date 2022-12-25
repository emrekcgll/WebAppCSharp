﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;
		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}

		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public Blog GetById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public void TAdd(Blog t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Blog t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Blog t)
		{
			throw new NotImplementedException();
		}
	}
}