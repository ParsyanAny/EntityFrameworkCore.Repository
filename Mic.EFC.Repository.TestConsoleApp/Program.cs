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
            studentRepository.GetAll(p => p.Name == "A1");
            
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.Commit();

            Console.WriteLine("Hello World!");

        }
    }
}
