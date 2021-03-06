﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.UserManagement.Entities
{
    public class Agency
    {
        public int Id { get; set; }

        public string  Code { get; set; }

        public string Name { get; set; }

        public AgencyBranch Branch { get; set; }
    }
}
