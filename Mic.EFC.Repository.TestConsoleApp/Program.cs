using Mic.EFC.Repository.Impl;
using Mic.EFC.Repository.Models;
using System;

namespace Mic.EFC.Repository.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            IStudentRepository studentRepository = new StudentRepository(context);
            Students s = new Students() {Name = "AAA", Surname= "VVV", GenderId = 1, UniversityId = 6 };
            studentRepository.Create(s);
            

            IUnitOfWork unitOfWork = new UnitOfWork_(context);
            
            unitOfWork.Commit();

        }
    }
}
