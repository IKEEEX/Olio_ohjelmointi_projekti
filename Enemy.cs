using System;
using System.Collections.Generic;
using System.Text;

namespace Olio_ohjelmointi_projekti
{
    public class Enemy : Character
    {
        public int Level { get; private set; }
        public int ExperienceReward { get; private set; }
        public int CoinReward { get; private set; }

        public Enemy(string name, int level)
            : base(name, 40 + level * 15, 8 + level * 4)
        {
            Level = level;
            ExperienceReward = 20 + level * 10;
            CoinReward = 15 + level * 5;
        }
    }
}
