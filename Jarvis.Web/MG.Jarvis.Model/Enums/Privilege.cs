using System;
using System.Collections.Generic;
using System.Text;

//Info : Define all the possible features in the application

namespace MG.Jarvis.Model.Enums {

    [Flags]
    public enum Privilege {
        None = 0,
        AddUser = 1,
        EditUserDetails = 2,
        ManageUserRoles = 4,
        SearchForm = 8,
        CreateForm = 16,
        ActionForm = 32,

        // ToDO : Add Others 


    }
}