﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSub
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
