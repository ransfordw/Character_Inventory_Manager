﻿using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.CharacterModels
{
    public class CharacterCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string CharacterName { get; set; }
        [Display(Name = "Class")]
        public CharacterClass CharacterClass { get; set; }
        [Display(Name = "Race")]
        public CharacterRace CharacterRace { get; set; }

        public override string ToString() => CharacterName;
    }
}