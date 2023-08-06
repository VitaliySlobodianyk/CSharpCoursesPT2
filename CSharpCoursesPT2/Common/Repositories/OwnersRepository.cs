using Common.Interfaces;
using Common.Interfaces.Items;
using Common.Models;
using Common.Models.Persons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class OwnersRepository : BaseRepository, IDataRepository<Owner>
    {
        private IList<Owner> _owners;

        public IList<Owner> Items { get; set; }

        public OwnersRepository(AppDBContext appDBContext) : base(appDBContext) { }
      
        public override async Task DownloadData()
        {
            _owners = await _appDBContext.Owners.ToListAsync();
        }

        public string PrintHTML()
        {
            return PrintHTML(_owners);
        }

        public string PrintHTML(IList<Owner> items)
        {
            var res = "<html><ul>";

            foreach (IDisplayableItem Owner in items)
            {
                res += "<li>" + Owner.PrintHTML() + "</li>";
            }

            return res + "</ul></html>";
        }

        public IList<Owner> List()
        {
            return _owners;
        }

        public Owner Get(int id)
        {
            return _owners.FirstOrDefault(x => x.Id == id);
        }

        public bool Add(Owner item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Owner item)
        {
            throw new NotImplementedException();
        }
    }
}
