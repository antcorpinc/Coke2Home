using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Models.Base
{
    public class User : BaseModel
    {
        public User()
        {
           
        }

        /// <summary>
        /// User First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User Last Name
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Http Url for Profile picture.
        /// </summary>
        public string ProfilePictureUri { get; set; }
        
        /// <summary>
        /// User Login Username. ALFA-NUMERIC. 1 LETTER CAPITAL . 1 SPECIAL CHARACTER.
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// User email Address
        /// </summary>
        public string Email { get; set; }
        
       
        
        /// <summary>
        /// User Activation Date.
        /// </summary>
        public DateTime ActivationDate { get; set; }
        
        /// <summary>
        /// User De-Activation Date.
        /// </summary>
        public DateTime? DeActivationDate { get; set; }
        
        

    }
}
