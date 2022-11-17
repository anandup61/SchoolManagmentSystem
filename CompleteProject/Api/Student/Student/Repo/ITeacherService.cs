using Student.Model;

namespace Student.Repo
{
    public interface ITeacherService
    {
        List<TeacherClass> GetTeachers();
        void postData(TeacherClass teacher);
    }
}
