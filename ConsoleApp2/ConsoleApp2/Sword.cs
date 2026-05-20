using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Sword : weapon
    {
        private void Start()
        {
            weaponName = "Dildo";
            damage = 25;
            cooldown = 0.5f;
        }
        
        public void Attack()
        {
            Debug.Log("Swing sword");
            base.Attack();
        }
    }
}
