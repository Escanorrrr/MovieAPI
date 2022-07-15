using DataAccess.Abstract;
using DataAccess.Context;
using Entity;

namespace DataAccess;

public class EfMovieDal:EfEntityRepositoryBase<Movie, MovieContext>, IMovieDal
{
    
}