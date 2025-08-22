using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Lernperiode_6.Held
{
    class Michael_Scofield
    {

        public string Name;
        public string Weapon;
        public string Ability;
        public int Life;
        public int Damage;
        public Michael_Scofield(string name, string weapon, string ability, int life, int damage)
        {
            Name = name;
            Weapon = weapon;
            Ability = ability;
            Life = life;
            Damage = damage;

        }



    }
}
