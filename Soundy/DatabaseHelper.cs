using Soundy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundy
{
    public class DatabaseHelper
    {
        public async void Send()
        {
            var item = new User() { UserName = "user"};
            await App.MobileService.GetTable<User>().InsertAsync(item);
        }
    }
}
