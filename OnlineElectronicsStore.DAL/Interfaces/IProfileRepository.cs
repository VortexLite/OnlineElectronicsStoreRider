﻿using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<int> GetByNameAsync(string? name);
}