using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfLegend
{
    public class LeagueOfLegendPlayer : ModPlayer
    {
        public bool immolate = false;

        public override void PostUpdateEquips()
        {

        }

        public override void ResetEffects()
        {
            immolate = false;
        }
    }
}
