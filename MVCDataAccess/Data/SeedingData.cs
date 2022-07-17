using Microsoft.EntityFrameworkCore;
using MVCDataAccess.Models;

namespace MVCDataAccess.Data
{
    public static class SeedingData
    {
        public static void StudentData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student
                {
                    Id = 1,
                    Name = "Zafer Eqbal",
                    Address = "Rafiganj"
                },
                new Student
                {
                    Id = 2,
                    Name = "Taukir Alam",
                    Address = "NewArea"
                },
                new Student
                {
                    Id = 3,
                    Name = "Arbaaz Khan",
                    Address = "Basariya"
                },
                new Student
                {
                    Id = 4,
                    Name = "Harsh Babu",
                    Address = "Rajabagicha"
                },

                new Student
                {
                    Id = 5,
                    Name = "Ravish Kumar",
                    Address = "Duniya Mohalla"
                },

                new Student
                {
                    Id = 6,
                    Name = "Yasin Ekbal",
                    Address = "Daudnagar"
                }
            });
        }
    }
}
