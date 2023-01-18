using System.Collections.Generic;

namespace Employee_Management.Models {
    public interface iEmployeeRepository {
        Employee GetEmployee(int Id);
        IEnumerable<Employee> GetAllEmployee();
        Employee Add(Employee employee);
        Employee Update(Employee employeeChanges);
        Employee Delete(int id);
    }
}
