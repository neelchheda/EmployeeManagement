using System.Collections.Generic;
using System.Linq;

namespace Employee_Management.Models {
    public class MockRepository : iEmployeeRepository {

        private List<Employee> _employeeList;
        public MockRepository()
        {

            _employeeList = new List<Employee>()
            {
                new Employee() {Id=1,Name="Neel",Department=Depte.HR, Email="neelchheda@gmail.com" },
                new Employee() {Id=2,Name="Pranit",Department=Depte.IT,Email="pranit@gmail.com" },
                new Employee() {Id=3,Name="Nikhil",Department=Depte.MCA,Email="nikhil@gmail.com" }
            };

        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employee;
        }
        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);

            }
            return employee;
        }
    }
}
