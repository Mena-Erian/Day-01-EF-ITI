using Data.Models;
using HelperUtilities;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static void Main()
        {
            AdventureWorks2012_aContext context = new AdventureWorks2012_aContext();    

            context.Departments.PrintAll();
        }
    }
}
