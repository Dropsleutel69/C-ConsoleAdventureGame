using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Bow : weapon
    {
        public GameObject druppelPrefab;
        private void Start()
        {
            weaponName = "Glijmiddel";
            damage = 15;
            cooldown = 1.2f;
        }

        public void Attack()
        {
            Debug.Log("Schiet glijmiddel");
            Instantiate(druppelPrefab);
        }
    }
}
