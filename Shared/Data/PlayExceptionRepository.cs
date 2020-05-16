using ComputerTime.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shared.Data
{
    public sealed class PlayExceptionRepository : IPlayExceptionRepository
    {
        private static object lockObject = new object();
        private string dbPath;

        public string DbPath 
        {
            get { return dbPath; }
            set 
            {
                if (!File.Exists(value))
                {
                    File.CreateText(value);
                }
                dbPath = value;
            } 
        }

        public PlayException Create(PlayException playException)
        {
            var playExceptions = ReadAll();
            if (playExceptions.Any())
            {
                playException.Id = playExceptions.Select(x => x.Id).Max() + 1;
            }
            else
            {
                playException.Id = 1;
            }
            playExceptions.Add(playException);
            WriteAll(playExceptions);
            return playException;
        }

        public void Delete(int id)
        {
            var playExceptions = ReadAll();
            var playException = playExceptions.FirstOrDefault(x => x.Id == id);
            if (playException != null)
            {
                playExceptions.Remove(playException);
                WriteAll(playExceptions);
            }
        }

        public ICollection<PlayException> Get()
        {
            var playExceptions = ReadAll();
            return playExceptions;
        }

        public PlayException Get(int id)
        {
            var playExceptions = ReadAll();
            var playException = playExceptions.FirstOrDefault(x => x.Id == id);
            if (playException != null)
            {
                return playException;
            }
            throw new ArgumentException(nameof(id));
        }

        public void Update(PlayException playException)
        {
            var playExceptions = ReadAll();
            var listPlayException = playExceptions.FirstOrDefault(x => x.Id == playException.Id);
            if (listPlayException != null)
            {
                listPlayException.Start = playException.Start;
                listPlayException.Duration = playException.Duration;
                listPlayException.Reason = playException.Reason;
                WriteAll(playExceptions);
            }
            else
            {
                throw new ArgumentException(nameof(playException));
            }
        }

        private IList<PlayException> ReadAll()
        {
            var str = File.ReadAllText(dbPath);
            if (!string.IsNullOrEmpty(str))
            {
                var list = JsonSerializer.Deserialize<IList<PlayException>>(str);
                list = list.OrderBy(x => x.Start).ToList();
                return list;
            }
            else
            {
                return new List<PlayException>();
            }
        }

        private void WriteAll(IList<PlayException> playExceptions)
        {
            lock(lockObject)
            {
                var str = JsonSerializer.Serialize<IList<PlayException>>(playExceptions);
                File.WriteAllText(dbPath, str);
            }
        }
    }
}
