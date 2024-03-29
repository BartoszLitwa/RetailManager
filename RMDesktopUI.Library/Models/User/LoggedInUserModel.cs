﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMDesktopUI.Library.Models.User
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public void LogInUserModel(LoggedInUserModel model)
        {
            Token = model.Token;
            Id = model.Id;
            FirstName = model.FirstName;
            LastName = model.LastName;
            EmailAddress = model.EmailAddress;
            CreatedDate = model.CreatedDate;
        }
    }
}
