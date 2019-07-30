
namespace Mic.EFC.Repository
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }
        IUniversityRepository Universities { get; }
        IGenderRepository Genders { get; }

        void Commit();
        void RejectChanges();
        void Dispose();
    }
}
