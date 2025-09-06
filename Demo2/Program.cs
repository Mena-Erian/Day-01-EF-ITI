using Demo2.Data;
using HelperUtilities;

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
            using (ITIContext contect = new ITIContext())
            {
                var Departments = contect.Departments;
                Departments.PrintAll();
                var Students = contect.Students;
                Students.PrintAll();
            }
            

            Console.ReadLine();
        }
    }
}
