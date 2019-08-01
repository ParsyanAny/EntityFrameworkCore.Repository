using Mic.EFC.Repository.Impl;
using Mic.EFC.Repository.Models;
using System;
using System.Linq;

namespace Mic.EFC.Repository.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            //IStudentRepository studentRepository = new StudentRepository(context);
            //Students s = new Students() {Name = "AAA", Surname= "VVV", GenderId = 1, UniversityId = 6 };
            //studentRepository.Create(s);

            //Func<string, bool> predicate1 = p => p.StartsWith("Any");
            //Predicate<string> predicate2 = p => p.StartsWith("a");

            IUnitOfWork unitOfWork = new UnitOfWork(context);
            var g1 = unitOfWork.Genders.GetAll().ToList();
            var g2 = unitOfWork.Genders.GetAll().ToList();
            //unitOfWork.Commit();

        }
    }
}
