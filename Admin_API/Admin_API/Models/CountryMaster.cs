﻿using System;
using System.Collections.Generic;

namespace Admin_API.Models
{
    public partial class CountryMaster
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
