﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public abstract class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual bool Deleted { get; set; }
    }
}