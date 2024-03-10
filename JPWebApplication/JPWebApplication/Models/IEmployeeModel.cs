namespace JPWebApplication.Models
{
    public interface IEmployeeModel
    {
        int id { get; set; }
        string name { get; set; }
        int Add(string Name);
        IEmployeeModel Get(int id);
        List<IEmployeeModel> GetAll();
    }
}