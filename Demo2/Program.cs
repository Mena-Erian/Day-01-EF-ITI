using Demo2.Data;
using Demo2.Modals;
using HelperUtilities;
using Microsoft.EntityFrameworkCore;

namespace Demo2
{
    #region Should Back To Study this Before go into MVC
    //Using Key word
    //GC
    //Constructor,Disconstrucor
    //contect.Dispose();
    //GC.Collect();
    //GC.WaitForPendingFinalizers(); 
    #endregion
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ITIContext context = new ITIContext())
            {
                var Departments = context.Departments;
                Departments.PrintAll();
                var Students = context.Students;

                var dept = Departments.FirstOrDefault(a => a.Id == 2);

                //Students.Add(new Student() { StdId = 5, Name = "halk Mohammad", Department = dept });
                //dept.Students.Add(new Student() { StdId = 5, Name = "halk Mohammad", Department = dept });


                context.SaveChanges();
                Students.PrintAll();
            }


            Console.ReadLine();
        }
    }
}
