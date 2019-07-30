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
            context.Students.FindAsync(1);

            IUnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.Commit();

        }
    }
}
