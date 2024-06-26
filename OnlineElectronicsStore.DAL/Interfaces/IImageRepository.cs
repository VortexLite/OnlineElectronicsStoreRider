﻿using OnlineElectronicsStore.Domain.Entity;

namespace OnlineElectronicsStore.DAL.Interfaces;

public interface IImageRepository : IBaseRepository<Image>
{
    Task<bool> CreateImagesAsync(List<Image> entities);
}