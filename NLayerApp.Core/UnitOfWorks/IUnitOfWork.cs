using System.Threading.Tasks;

namespace NLayerApp.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
} 