﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public class MyImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public byte[] Image { get; set; }
    }
}