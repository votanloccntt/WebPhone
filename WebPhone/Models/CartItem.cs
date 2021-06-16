using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPhone.Models
{
    [Serializable]
    public class CartItem
    {      
        public Phones Phones { set; get; }
        public int Quantity { set; get; }
    }
}