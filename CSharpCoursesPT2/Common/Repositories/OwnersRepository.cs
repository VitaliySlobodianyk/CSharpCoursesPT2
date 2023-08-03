using Common.Interfaces;
using Common.Interfaces.Items;
using Common.Models.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class OwnersRepository : IDataRepository<Owner>
    {
        private IList<Owner> _owners;

        public IList<Owner> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public OwnersRepository(List<Owner> Owners)
        {
            _owners = new List<Owner>(Owners);
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
            return _owners.FirstOrDefault(car => car.Id == id);
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
