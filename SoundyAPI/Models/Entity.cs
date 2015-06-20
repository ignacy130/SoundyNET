﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoundyAPI.Models
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual bool Deleted { get; set; }
    }
}