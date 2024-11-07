using DTO;

namespace BLL.Interface
{
    public interface IEmployeeBLL
    {
        EmployeeDTO Create(EmployeeCreateDTO employee);
        List<EmployeeDTO> GetListByManger(int id);
        bool Delete(int id);


    }
}
