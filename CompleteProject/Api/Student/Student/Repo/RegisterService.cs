using Student.DbConnection;
using Student.Model;

namespace Student.Repo
{
    public class RegisterServic : IRegisterService
    {
        private readonly ITeacherService teacher;
        private readonly DbClass dbClass;
        public RegisterServic(DbClass dbClass, ITeacherService teacher)
        {
            this.dbClass = dbClass;
            this.teacher = teacher;
        }

        public List<RegisterClass> GetRegister()
        {
            try
            {
                var rest = dbClass.Students.ToList();
                return rest;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Register(RegisterClass register)
        {
            try
            {
                if(register==null)
                {
                    throw new ArgumentNullException("Data can't be null");
                }
                dbClass.Students.Add(register);
                dbClass.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RegisterClass Unregister(int id)
        {
            try
            {
               var rest= dbClass.Students.FirstOrDefault(x => x.Id ==id);
                if (id == null)
                {
                    throw new ArgumentNullException("Id not found");
                }

                dbClass.Students.Remove(rest);
                dbClass.SaveChanges();
                return rest;
            }
            catch(Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }

        public void UpdateData(RegisterClass data)
       {
            try
            {
                var res = dbClass.Students.FirstOrDefault(x => x.Id == data.Id);
                if (data.Id == null)
                {
                    throw new ArgumentNullException("Id Can't be null");
                }
                res.FirstName = data.FirstName;
                res.LastName = data.LastName;
                res.Dob = data.Dob;
                res.Gender = data.Gender;
                res.TeacherId = data.TeacherId;
                dbClass.Students.Update(res);
                dbClass.SaveChanges();

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public List<StudentListClass> GetRegisteredList()
        {
            var teacherList = teacher.GetTeachers().ToList();
            List<StudentListClass> list = new List<StudentListClass>();
            foreach (var item in dbClass.Students)
            {
                var Students = new StudentListClass();
                Students.Id = item.Id;
                Students.Name = item.FirstName + " " + item.LastName;
                Students.Dob = item.Dob;
                Students.Gender = item.Gender=="1"?"Male":"Female";
                var techerFirstName = teacherList.FirstOrDefault(x => x.Id == item.TeacherId).FirstName;
                var techerLastName = teacherList.FirstOrDefault(x => x.Id == item.TeacherId).LastName;
                Students.TeacherName = techerFirstName + " " + techerLastName;
                list.Add(Students);
            }
            return list;
        }

        public RegisterClass GetStudentById(int id)
        {
            var result = dbClass.Students.FirstOrDefault(x => x.Id == id);
            if (result == null)
            {
                throw new ArgumentNullException("student not found");
            }
            return result;
        }
    }
}
