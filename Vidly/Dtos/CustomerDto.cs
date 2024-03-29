﻿using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

    
        //[Min18YearsIfAMember]
        public DateTime Dob { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }


    
        public byte MembershipTypeId { get; set; }
    }
}