using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace mini_game
{
    class Hammer
    {
       
       
        
            
        
        
        public string Name;
        public int Damage { get; }
        public int Price { get; }

        public Hammer(string name , int damage, int price )
        {
            Name = name;
            Damage = damage;
            Price = price;
            
        }
    }
}
