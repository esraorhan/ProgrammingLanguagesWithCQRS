using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class SocialMediaAccount:Entity
    {
       
        public string AccountLink { get; set; }
        public string SocialMediaName { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public SocialMediaAccount()
        {
        }

        public SocialMediaAccount(int id,int userId,string accountLink,string socialMediaName) : this()
        {
            Id=id;
            UserId=userId;
            AccountLink=accountLink;
            SocialMediaName=socialMediaName;
        }
    }
}
