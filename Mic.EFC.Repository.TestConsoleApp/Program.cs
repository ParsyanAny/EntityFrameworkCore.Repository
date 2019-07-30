using Mic.EFC.Repository.Impl;
using System;

namespace Mic.EFC.Repository.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            IStudentRepository studentRepository = new StudentRepository(context);
            var sts = studentRepository.GetAll(p => p.Name == "A");
            Console.WriteLine(DateTime.Now.ToString());
            context.Students.FindAsync(1);
            Console.WriteLine(DateTime.Now.ToString());

            IUnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.Commit();

        }
    }
}
