using CRUDWebApplication.Models;

namespace CRUDWebApplication.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> students = new List<Student>();
        public int AddStudent(Student stud)
        {
            try
            {
                students.Add(stud);
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        public int DeleteStudent(int id)
        {
            var stud = GetStudent(id);
            if(stud != null)
            {
                students.Remove(stud);
                return 1;
            }
            return 0;
        }

        public List<Student> GetAllStudent()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            var stud = students.Find(x => x.Id == id);  
            if(stud != null)
            {
                return stud;
            }
            return null;
        }

        public int UpdateStudent(int id, Student student)
        {
            var stud = GetStudent(id);

            if( stud != null )
            {
                stud.Name = student.Name;
                return 1;
            }
            return 0;
        }

        public int UpdateStudentPatch(int id, StudentPatchModel studentPatch)
        {
            var stud = GetStudent(id);

            if (stud != null)
            {
                stud.Name = studentPatch.Name;
                return 1;
            }
            return 0;
        }
    }
}
