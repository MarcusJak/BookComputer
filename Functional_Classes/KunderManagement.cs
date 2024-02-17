using System;
using MethodTimer;
using System.Threading.Tasks;

namespace exjobb.Functional_Classes
{
	public class KunderManagement: UserManagement
	{
		public KunderManagement()
		{
		}

        [Time]
        public async Task<bool> login(string userID, string password)
        {
            if (userID == "0")
            {
                return false;
            }
            Kund temp = await data.checkLogInInput(userID, password);

            if (temp != null)
            {
                kundInfo = temp;
                return true;
            }
            return false;
        }

    }
}

