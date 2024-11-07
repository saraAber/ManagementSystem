using BLL.Service;
using DAL.Management;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IManagerBLL
    {
        ManagerDTO Create(ManagerCreateDTO employee);
        ManagerDTO? Login(LoginDTO login);
    }
}
