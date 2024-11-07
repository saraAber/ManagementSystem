using AutoMapper;
using DAL.Management;
using DTO;


namespace BLL
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {
            CreateMap<Manager, ManagerDTO>().ReverseMap();
            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();
            CreateMap<Manager, ManagerCreateDTO>().ReverseMap();
        }
    }
}
