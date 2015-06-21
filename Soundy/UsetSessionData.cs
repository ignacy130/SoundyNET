using Soundy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundy
{
    public class UserSessionData
    {
        private static UserSessionData instance;
        public User User { get; set; }
        public static UserSessionData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserSessionData();
                }
                return instance;
            }
        }

        public UserSessionData()
        {

        }

    }
}
