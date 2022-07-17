using Microsoft.EntityFrameworkCore;
using MVCDataAccess.Data;
using MVCDataAccess.Models;
using MVCDataAccess.ViewModels;
using System.Threading;

namespace MVCDataAccess.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<List<Student>> GetStudents()
        {
            var list = await context.Students.ToListAsync();
            return list;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            return student;
        }

        public async Task<Student> AddStudent(StudentViewModel model)
        {
            var student = new Student
            {
                Name = model.Name,
                Address = model.Address
            };
            await context.AddAsync(student);
            await context.SaveChangesAsync();
            return student; 
        }

        public async Task<Student> UpdateStudent(StudentViewModel model)
        {
            var student = new Student
            {
                Id = model.Id,
                Address = model.Address,
                Name = model.Name
            };
            context.Students.Update(student);
            await context.SaveChangesAsync();
            return student;
        }


        public async Task DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }
    }
}
