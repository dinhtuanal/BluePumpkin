﻿using DataAccessLayer.Entities;
using SharedObjects.Commons;
using SharedObjects.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Interfaces
{
    public interface IUserClient
    {
        Task<ResponseResult> Login(LoginViewModel model);
        Task<ResponseResult> Add(AddUserViewModel model, string token);
        Task<ResponseResult> Update(UpdateUserViewModel model, string token);
        Task<ResponseResult> Delete(string userId, string token);
        Task<List<ApplicationUser>> GetAll(string token);
        Task<ApplicationUser> GetById(string userId, string token);
        Task<ApplicationUser> GetByUserName(string userName, string token);
    }
}
