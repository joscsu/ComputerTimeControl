using ComputerTime.Shared;
using System.Collections.Generic;

namespace Shared.Data
{
    public interface IPlayExceptionRepository
    {
        string DbPath { get; set; }
        ICollection<PlayException> Get();
        PlayException Get(int id);
        PlayException Create(PlayException playException);
        void Update(PlayException playException);
        void Delete(int id);
    }
}
