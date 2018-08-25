using InventoryMangager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.ItemModels
{
    public class ItemCreate
    {
        [Required]
        [Display(Name = "Name")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "Select a Type")]
        public ItemType ItemType { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ItemDescription { get; set; }

        //TODO: Clarify "Value"... as a new player, I was not sure what this meant. Maybe... "Market Value"? "Price"?
        [Required]
        [Display(Name = "Value")]
        public int ItemValue { get; set; }

        [Required]
        [Display(Name = "Select a type of Currency")]
        public Currency Currency { get; set; }

        public override string ToString() => ItemName;
    }
}