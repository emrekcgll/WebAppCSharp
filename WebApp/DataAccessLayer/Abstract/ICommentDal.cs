using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
    }
}
