using MVCDataAccess.Models;
using MVCDataAccess.ViewModels;

namespace MVCDataAccess.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task<Student> AddStudent(StudentViewModel model);
        Task DeleteStudent(int id);
        Task<Student> UpdateStudent(StudentViewModel model);
    }
}
