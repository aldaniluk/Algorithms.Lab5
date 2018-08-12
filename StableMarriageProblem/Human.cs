using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriageProblem
{
    public class Human : IEnumerable<int>
    {
        public int[] Preferences { get; private set; }
        private IEnumerator<int> enumerator;

        public Human(int[] preferences)
        {
            Preferences = preferences;
        }

        public IEnumerator<int> GetEnumerator()
        {
            if (enumerator == null)
            {
                enumerator = new PreferencesEnumerator(this);
            }

            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class PreferencesEnumerator : IEnumerator<int>
        {
            private Human human;
            private int index;

            public PreferencesEnumerator(Human human)
            {
                this.human = human;
                index = -1;
            }

            public int Current => human.Preferences[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return ++index < human.Preferences.Length;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
