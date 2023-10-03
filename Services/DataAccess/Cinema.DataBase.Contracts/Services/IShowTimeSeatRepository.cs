using Cinema.DataContracts.BaseServices;
using Cinema.Domains.Entities;
using System.Linq.Expressions;

namespace Cinema.DataBase.Contracts.Services;

public interface IShowTimeSeatRepository
{
    ShowTimeSeat[] QueryAsync(Expression<Func<ShowTimeSeat, bool>> filter = null, params Expression<Func<ShowTimeSeat, object>>[] includes);
}