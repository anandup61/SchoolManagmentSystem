using Student.Model;

namespace Student.Repo
{
    public interface IRegisterService
    {
        List<RegisterClass> GetRegister();
        List<StudentListClass> GetRegisteredList();
        void Register(RegisterClass register);
        RegisterClass Unregister(int id);

        void UpdateData(RegisterClass data);
        RegisterClass GetStudentById(int id);


    }
}
