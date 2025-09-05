using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Lernperiode_6.Held
{


    class Hulk
    {
        public string Name;
        public int Id;
        public int Leben;
        public int Gold;

        public Hulk(string name, int id, int leben, int gold)

        {

            Name = name;
            Id = id;
            Leben = leben;
            Gold = gold;

        }

        public void AddGold(int betrag)
        {
            if (betrag > 0) Gold += betrag;

        }


        public bool TrySpendGold(int betrag)
        {

            if (betrag <= 0) return false;
            if (Gold >= betrag) { Gold -= betrag; return true; }
            return false;

        }
        public void TrankTrinken(int wirkung)
        {
            Leben += wirkung;

            if (Leben < 0) Leben = 0;

            Console.WriteLine($"{Name} trinkt einen Trank. Neue Lebenspunkte: 30");
        }


    }


}



