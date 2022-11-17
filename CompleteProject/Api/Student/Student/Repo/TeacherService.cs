using Student.DbConnection;
using Student.Model;

namespace Student.Repo
{
    public class TeacherService:ITeacherService
    {
        private readonly DbClass dbClass;
        public TeacherService(DbClass dbClass)
        {
            this.dbClass = dbClass;
        }

        public List<TeacherClass> GetTeachers()
        {
            try
            {
                var rest = dbClass.Teachers.ToList();
                return rest;    
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void postData(TeacherClass teacher)
        {
            try
            {
                if(teacher == null)
                {
                    throw new ArgumentNullException("Data Can't Empty");
                }
                dbClass.Teachers.Add(teacher);
                dbClass.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception 
                    (ex.Message);
            }
        }
    }
}
