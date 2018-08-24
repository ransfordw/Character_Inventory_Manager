using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Models.Backpack
{
    public class TitleView
    {
        public string CharacterName { get; set; }
        public IEnumerable<CharacterBackpackList> BackpackItemList { get; set; }
    }
}

