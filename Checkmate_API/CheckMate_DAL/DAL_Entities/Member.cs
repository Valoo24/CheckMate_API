﻿using CheckMate_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMate_DAL.DAL_Entities
{
    public class Member : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthdate { get; set; }
        public Char Gender { get; set; }
        public int Elo { get; set; }
        public bool IsAdmin { get; set; }
    }
}
