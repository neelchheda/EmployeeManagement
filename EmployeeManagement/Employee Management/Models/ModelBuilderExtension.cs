using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Models {
    public static class ModelBuilderExtension {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(

                 new Employee
                 {
                     Id = 1,
                     Name = "Neel",
                     Email = "neel@gmail.com",
                     Department = Depte.Intern
                 },
                 new Employee
                 {
                     Id = 2,
                     Name = "Pranit",
                     Email = "pranit@gmail.com",
                     Department = Depte.IT
                 },
                 new Employee
                 {
                     Id = 3,
                     Name = "Nikhil",
                     Email = "nikhil@gmail.com",
                     Department = Depte.MCA
                 }
            );
        }
    }
}
