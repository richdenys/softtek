using System;
using System.Collections.Generic;
using System.Text;
using VentasSofttek.Models.Login;
using VentasSofttek.Models.Response;

namespace VentasSofttek.DTO.Service
{
    public interface IUserService
    {
        public MUserResponse Autch(AuthRequest request);
    }
}
