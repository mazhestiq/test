﻿using Cinema.DataContracts.BaseServices;
using Cinema.Domains.Entities;

namespace Cinema.DataBase.Contracts.Services;

public interface IMovieRepository : ICrudRepository<Movie>
{
}