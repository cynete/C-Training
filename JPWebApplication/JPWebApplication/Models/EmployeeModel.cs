using System.Xml.Linq;

namespace JPWebApplication.Models
{
    public class EmployeeModel : IEmployeeModel
    {
        private List<IEmployeeModel> empList = new List<IEmployeeModel>();
        public int id { get; set; }
        public string name { get; set; }

        public int Add(string Name)
        {
            var newId = empList.Count + 1;
            empList.Add(new EmployeeModel()
            {
                id = newId,
                name = Name
            });

            return newId;
        }

        public List<IEmployeeModel> GetAll()
        {
            return empList;
        }

        public IEmployeeModel Get(int id)
        {
            return empList.SingleOrDefault(x => x.id == id);
        }
    }

    public static class EmpHelper
    {

        private static List<EmployeeModel> AllEmployees = new List<EmployeeModel>() {
                new EmployeeModel() { id = 1, name = "Emp1"},
                new EmployeeModel() { id = 2, name = "Emp2"},
                new EmployeeModel() { id = 3, name = "Emp3"}};

        public static int EmpCount = AllEmployees.Count;

        public static List<EmployeeModel> GetEmployeeList()
        {
            return AllEmployees;
        }

        public static void Add(EmployeeModel employee)
        {
            AllEmployees.Add(employee);
        }
    }
}
