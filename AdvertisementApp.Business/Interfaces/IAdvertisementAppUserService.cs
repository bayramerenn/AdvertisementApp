﻿using AdvertisementApp.Common;
using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;

namespace AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);

        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);

        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}