using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class weapon
    {
        public string weaponName;
        public int damage;
        public float cooldown;

        public void Attack()
        {
            Debug.Log(weaponName + " does " + damage + " damage.");
        }
    }
}
]