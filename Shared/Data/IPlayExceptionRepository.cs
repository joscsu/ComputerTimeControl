using ComputerTime.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Data
{
    public interface IPlayExceptionRepository
    {
        Task<IQueryable<PlayException>> Get();
        Task<PlayException> Create(PlayException playException);
        Task Update(PlayException playException);
        Task Delete(int id);
    }
}
