using Soundy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundy.Models
{
    public static class Dao<T>
    {
        public async static void Insert(T item)
        {
            await App.MobileService.GetTable<T>().InsertAsync(item);
        }

        public async static Task<List<T>> GetAll()
        {
           return  await App.MobileService.GetTable<T>().ToListAsync();
        }

        public async static void Update(T user)
        {
            await App.MobileService.GetTable<T>().UpdateAsync(user);
        }

        public async static void Delete(T user)
        {
            await App.MobileService.GetTable<T>().DeleteAsync(user);
        }
    }
}
