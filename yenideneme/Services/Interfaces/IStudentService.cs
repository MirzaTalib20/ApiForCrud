using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using yenideneme;
using yenideneme.Models;

public interface IStudentService
{
    Task<List<Users>> GetAllStudentsAsync();
    Task<Users> GetStudentsByIdAsync(int id);
    Task<Users> PostCreateStudentsAsync([FromBody] Users newStudent);
    Task<Users> DeleteStudentsByIdAsync(int id);
    Task<Users> UpdateStudentsByIdAsync(int id, Users updatedStudent);
}   
