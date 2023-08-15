using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChallengeLaNacion.Models;
using ChallengeLaNacion.Data;
using ChallengeLaNacion.Interfaces;
using System.Linq.Expressions;

namespace ChallengeLaNacion.Data.Repositories
{
    public class ContactRepository : IRepository<Contact>
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }
        public async Task<Contact> Find(int id)
        {
            var result = await _context.Contacts.FindAsync(id);
            return result;
        }

        public async Task Delete(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Insert(Contact entity)
        {
            _context.Contacts.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task Update(Contact entity)
        {
            _context.Contacts.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Contact>> FindWhere(string key, string searchValue)
        {
            if (key == "Address")
            {
                return await _context.Contacts
                .Where(c => c.Address.Contains(searchValue))
                .ToListAsync();
            } else if (key == "EmailOrPhone")
            {
                return await _context.Contacts
                .Where(c => c.Email.Contains(searchValue)
                || c.Personal_Phone.Contains(searchValue)
                || c.Work_Phone.Contains(searchValue))
                .ToListAsync();
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }

}
