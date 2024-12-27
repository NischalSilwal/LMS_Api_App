using LMS_Api_App.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS_Api_App.Application.Interfaces
{
    public interface IJwtTokenHelper
    {
        public string GenerateToken(Users user);
    }
}
