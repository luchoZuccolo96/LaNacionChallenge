using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChallengeLaNacion.Models;
using ChallengeLaNacion.Business.Interfaces;
using ChallengeLaNacion.Data.Repositories;
using ChallengeLaNacion.Interfaces;

namespace ChallengeLaNacion.Business.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactRepository.GetAll();
        }

        public async Task<Contact> Find(int id)
        {
            return await _contactRepository.Find(id);
        }

        public async Task CreateContact(Contact contact)
        {
            await _contactRepository.Insert(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await _contactRepository.Update(contact);
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.Delete(id);
        }
        public async Task<IEnumerable<Contact>> SearchContactsBy(string key, string searchValue)
        {
            return await _contactRepository.FindWhere(key, searchValue);
        }

    }
}
