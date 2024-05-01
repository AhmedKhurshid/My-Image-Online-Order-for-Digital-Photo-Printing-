using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myimage.Models;

namespace myimage.Controllers
{
    public class Item
    {
        private sizeprize Sz = new sizeprize();
      

        public sizeprize sz
        {
            get { return Sz; }
            set { Sz = value; }
        }

       

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Item()
        {

        }

        public Item(sizeprize Sizeprize, int quantity)
        {
            this.Sz = Sizeprize;
            this.quantity = quantity;
        }
    }
}