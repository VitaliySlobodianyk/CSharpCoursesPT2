using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public abstract class BaseRepository
    {
        protected AppDBContext _appDBContext;
       
        public BaseRepository(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
            DownloadData().Wait();
        }

        public abstract Task DownloadData();
    }
}
