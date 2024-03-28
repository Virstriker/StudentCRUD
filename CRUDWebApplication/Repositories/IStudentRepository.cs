using CRUDWebApplication.Models;

namespace CRUDWebApplication.Repositories
{
    public interface IStudentRepository
    {
        int AddStudent(Student stud);

        List<Student> GetAllStudent();
        Student GetStudent(int id);

        int UpdateStudent(int id,Student student);

        int DeleteStudent(int id);

        int UpdateStudentPatch(int id,StudentPatchModel patch);   
    }
}
