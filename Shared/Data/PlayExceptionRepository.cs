using ComputerTime.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Data
{
    public class PlayExceptionRepository : IPlayExceptionRepository
    {
        public Task<PlayException> Create(PlayException playException)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<PlayException>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Update(PlayException playException)
        {
            throw new NotImplementedException();
        }
    }
}
