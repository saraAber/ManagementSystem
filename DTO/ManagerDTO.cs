using System.ComponentModel.DataAnnotations;

namespace DTO;

public class ManagerDTO 
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string FullName { get; set; } = "";
    public string GUID { get; set; } = ""; 
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}

