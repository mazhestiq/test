using System.Data.Entity;
using System.Linq.Expressions;
using Cinema.Core.Extensions;
using Cinema.DataAccess;
using Cinema.DataAccess.Services.Base;
using Cinema.DataBase.Contracts.Services;
using Cinema.DataContracts.Contracts;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Implementation.Services;

public class ShowTimeSeatRepository : IShowTimeSeatRepository
{
    private readonly CinemaDbContext _dbContext;

    public ShowTimeSeatRepository(IDbContextFactory<CinemaDbContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.GetContext();
    }

    public virtual ShowTimeSeat[] QueryAsync(Expression<Func<ShowTimeSeat, bool>> filter = null, params Expression<Func<ShowTimeSeat, object>>[] includes)
    {
        var query = _dbContext.Set<ShowTimeSeat>().AsNoTracking().AddIncludes(includes);
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query.ToArray();
    }
}