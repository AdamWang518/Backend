using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class OptionModel
    {
        public Guid ID;
        public Guid TypeID;
        public string Option;
        public string Department;
        public string Name;
        public string Image;
    }
}