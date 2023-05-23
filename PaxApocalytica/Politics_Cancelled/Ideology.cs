using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaxApocalytica.Politics
{
    public class Ideology
    {
        public Tuple<byte, byte, byte, byte, IdeologyEnum.Name> parties;

        public void IncreaseSupport(byte increaseValue, IdeologyEnum.Name name)
        {
            if (name == IdeologyEnum.Name.Communism)
            {
                parties = Tuple.Create((byte)(parties.Item1 + increaseValue), parties.Item2, parties.Item3, parties.Item4, parties.Item5);
            }
            else if (name == IdeologyEnum.Name.Fascism)
            {
                parties = Tuple.Create(parties.Item1, (byte)(parties.Item2 + increaseValue), parties.Item3, parties.Item4, parties.Item5);
            }
            else if (name == IdeologyEnum.Name.Liberalism)
            {
                parties = Tuple.Create(parties.Item1, parties.Item2, (byte)(parties.Item3 + increaseValue), parties.Item4, parties.Item5);
            }
            else if (name == IdeologyEnum.Name.NonAlligned)
            {
                parties = Tuple.Create(parties.Item1, parties.Item2, parties.Item3, (byte)(parties.Item4 + increaseValue), parties.Item5);
            }
            else
            {
                throw new ArgumentException();
            }
            RandomDecrease(increaseValue, name);
        }

        public Ideology(byte communismSupport, byte fascismSupport, byte liberalismSupport, byte nonAlligned, IdeologyEnum.Name mainParty)
        {
            if (communismSupport + fascismSupport + liberalismSupport + nonAlligned > 100)
            {
                throw new ArgumentException();
            }
            parties = Tuple.Create(communismSupport, fascismSupport, liberalismSupport, nonAlligned, mainParty);
        }

        private void RandomDecrease(byte increaseValue, IdeologyEnum.Name name)
        {
            Random random = new Random();
            if (name == IdeologyEnum.Name.Communism)
            {
                if (random.Next(0, 2) == 0)
                {
                    parties = Tuple.Create(parties.Item1, (byte)(parties.Item2 - increaseValue), parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 1)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, (byte)(parties.Item3 - increaseValue), parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 2)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, parties.Item3, (byte)(parties.Item4 - increaseValue), parties.Item5);
                }
            }
            else if (name == IdeologyEnum.Name.Fascism)
            {
                if (random.Next(0, 2) == 0)
                {
                    parties = Tuple.Create((byte)(parties.Item1 - increaseValue), parties.Item2, parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 1)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, (byte)(parties.Item3 - increaseValue), parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 2)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, parties.Item3, (byte)(parties.Item4 - increaseValue), parties.Item5);
                }
            }
            else if (name == IdeologyEnum.Name.Liberalism)
            {
                if (random.Next(0, 2) == 0)
                {
                    parties = Tuple.Create((byte)(parties.Item1 - increaseValue), parties.Item2, parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 1)
                {
                    parties = Tuple.Create(parties.Item1, (byte)(parties.Item2 - increaseValue), parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 2)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, parties.Item3, (byte)(parties.Item4 - increaseValue), parties.Item5);
                }
            }
            else if (name == IdeologyEnum.Name.NonAlligned)
            {
                if (random.Next(0, 2) == 0)
                {
                    parties = Tuple.Create((byte)(parties.Item1 - increaseValue), parties.Item2, parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 1)
                {
                    parties = Tuple.Create(parties.Item1, (byte)(parties.Item2 - increaseValue), parties.Item3, parties.Item4, parties.Item5);
                }
                else if (random.Next(0, 2) == 2)
                {
                    parties = Tuple.Create(parties.Item1, parties.Item2, (byte)(parties.Item3 - increaseValue), parties.Item4, parties.Item5);
                }
            }
        }
    }
}
