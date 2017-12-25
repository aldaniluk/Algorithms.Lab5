using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriageProblem
{
    public class Human
    {
        public int[] Preferences { get; private set; }

        public Human(int[] preferences)
        {
            Preferences = preferences;
        }
    }
}
