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
    public class SellersRepository : BaseRepository, IDataRepository<Seller>
    {
        private IList<Seller> _sellers;

        public IList<Seller> Items { get; set; }

        public SellersRepository(AppDBContext appDBContext) : base(appDBContext) { }

        public override async Task DownloadData()
        {
            _sellers = await _appDBContext.Sellers.ToListAsync();
        }

        public string PrintHTML()
        {
            return PrintHTML(_sellers);
        }

        public string PrintHTML(IList<Seller> items)
        {
            var res = "<html><ul>";

            foreach (IDisplayableItem seller in items)
            {
                res += "<li>" + seller.PrintHTML() + "</li>";
            }

            return res + "</ul></html>";
        }

        public IList<Seller> List()
        {
            return _sellers;
        }

        public Seller Get(int id)
        {
            return _sellers.FirstOrDefault(car => car.Id == id);
        }

        public bool Add(Seller item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Seller item)
        {
            throw new NotImplementedException();
        }

    }
}
