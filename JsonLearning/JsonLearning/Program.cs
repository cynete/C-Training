using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.Json.Nodes;

namespace JP.JsonLearning
{
    class JsonLearning
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start of Program \n");
            Console.WriteLine("----------------------------------------------------");
            //serialize object to Json
            Employee e1 = new Employee() { ID = 1 , Name = "John" , Age = 30, City = "Chennai"};

            Console.WriteLine( e1.Name);

            string jobj = JsonConvert.SerializeObject(e1);
            Console.WriteLine(jobj);

            Console.WriteLine("----------------------------------------------------");
            //json array to object
            var jarrObj1 = "{ \"ID\":1,\"Name\":\"John\",\"Age\":30,\"City\":\"Chennai\"}";

            var jObjList = new List<string>
            {
                "{ \"ID\":1,\"Name\":\"N1\",\"Age\":30,\"City\":\"Chennai\"}",
                "{ \"ID\":2,\"Name\":\"N2\",\"Age\":31,\"City\":\"Mumbai\"}",
                "{ \"ID\":3,\"Name\":\"N3\",\"Age\":32,\"City\":\"Coimbatore\"}",
                "{ \"ID\":4,\"Name\":\"N4\",\"Age\":33,\"City\":\"Chennai\"}",
                "{ \"ID\":5,\"Name\":\"N5\",\"Age\":34,\"City\":\"Chennai\"}"
            };

            foreach (var item in jObjList)
            {
                var obj = JsonConvert.DeserializeObject<Employee>(item.ToString());
                Console.WriteLine(obj.Name);
            }

            Console.WriteLine("----------------------------------------------------");
            //using linq
            var jsonarray = "[{ \"ID\":1,\"Name\":\"N1\",\"Age\":30,\"City\":\"Chennai\"},{ \"ID\":2,\"Name\":\"N2\",\"Age\":31,\"City\":\"Mumbai\"},{ \"ID\":3,\"Name\":\"N3\",\"Age\":32,\"City\":\"Coimbatore\"}, { \"ID\":4,\"Name\":\"N4\",\"Age\":33,\"City\":\"Chennai\"},{ \"ID\":5,\"Name\":\"N5\",\"Age\":34,\"City\":\"Chennai\"}]";
            
            var jarray = JArray.Parse(jsonarray);
            var selJsonObj = jarray.Where(x => (string)x["City"] == "Chennai");

            foreach (var item in selJsonObj) 
            {
                Console.WriteLine(item);
                var dObj = JsonConvert.DeserializeObject<Employee>(item.ToString());

                Console.WriteLine( " >>>" + dObj.Name + " - " + dObj.City);
            }

            Console.WriteLine("----------------------------------------------------");

            //Json containing array of json
            //  {
            //    "employees":[
            //                    { "name":"Ram", "email":"ram@gmail.com", "age":23},    
            //                    { "name":"Shyam", "email":"shyam23@gmail.com", "age":28},  
            //                    { "name":"John", "email":"john@gmail.com", "age":33},    
            //                    { "name":"Bob", "email":"bob32@gmail.com", "age":41}   
            //  ]}

            string mjson = "{ \"employees\":[{ \"name\":\"Ram\", \"email\":\"ram@gmail.com\", \"age\":23},{ \"name\":\"Shyam\", \"email\":\"shyam23@gmail.com\", \"age\":28}, { \"name\":\"John\", \"email\":\"john@gmail.com\", \"age\":33}, { \"name\":\"Bob\", \"email\":\"bob32@gmail.com\", \"age\":41} ]}";

            var mjsonObj = JsonConvert.DeserializeObject<Employees>(mjson);
            
            foreach (var item in mjsonObj.employees)
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine("\n\nEnd of Program");
            Console.ReadLine();
        }
    }
}