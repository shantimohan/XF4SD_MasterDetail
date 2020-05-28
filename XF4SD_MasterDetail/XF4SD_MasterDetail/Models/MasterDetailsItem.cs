using System;
using System.Collections.Generic;
using System.Text;

namespace XF4SD_MasterDetail.Models
{
    public class MasterDetailsItem
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public bool IsShowActionBar { get; set; }

        public MasterDetailsItem(int x)
        {
            Title = $"Title {x}";
            Details = $"This is the description of title {x}";
            IsShowActionBar = false;
        }
    }
}
