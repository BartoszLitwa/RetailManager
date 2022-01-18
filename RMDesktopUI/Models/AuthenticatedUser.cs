using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Models
{
    public class AuthenticatedUser
    {
        public string Access_token { get; set; }
        public string  Token_type { get; set; }
        public string Username { get; set; }
        public int Expires_in { get; set; }
    }
}
