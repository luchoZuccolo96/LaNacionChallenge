using System.Collections.Generic;
using System.Threading.Tasks;
using ChallengeLaNacion.Models;

namespace ChallengeLaNacion.Business.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact> Find(int id);
        Task CreateContact(Contact contact);
        Task UpdateContact(Contact contact);
        Task DeleteContact(int id);
        Task<IEnumerable<Contact>> SearchContactsBy(string key, string searchValue);

    }
}
