using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using yenideneme.Models;
using Users = yenideneme.Models.Users;

namespace yenideneme.Services
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly AppDbContext _context;

        #endregion
        #region Ctor
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region GetStudentsAsync 
        public async Task<List<Users>> GetAllStudentsAsync()
        {
            try
            {
                return await _context.User.Where(x => x.Status == 0).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region GetStudentsByIdAsync 
        public async Task<Users> GetStudentsByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(s => s.Id == id);
        }
        #endregion

        #region PostCreateStudentsAsync 
        public async Task<Users> PostCreateStudentsAsync([FromBody] Users newStudent)
        {
            if (newStudent == null)
            {
                return null;
            }

            await _context.User.AddAsync(newStudent);
            _context.SaveChanges();

            return newStudent;
        }
        #endregion

        #region DeleteStudentsByIdAsync 
        public async Task<Users> DeleteStudentsByIdAsync(int id)
        {
            var studentDelete =  await _context.User.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (studentDelete != null)
            {
                studentDelete.Status = 1;
                _context.User.Update(studentDelete);
                await _context.SaveChangesAsync();
            }

            return studentDelete;
        }
        #endregion

        #region UpdateStudentsByIdAsync 
        public async Task<Users> UpdateStudentsByIdAsync(int id, Users updatedStudent)
        {
            var existingStudent = await _context.User.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                existingStudent.Firstname = updatedStudent.Firstname;
                existingStudent.Lastname = updatedStudent.Lastname;
                existingStudent.Phone  = updatedStudent.Phone;
                await _context.SaveChangesAsync();
            }

            return existingStudent;
        }
        #endregion
    }
}
