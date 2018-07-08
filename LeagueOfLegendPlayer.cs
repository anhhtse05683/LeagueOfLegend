using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LeagueOfLegend
{
    public class LeagueOfLegendPlayer : ModPlayer
    {
        public bool immolate = false;
        public int immolateTimer = 0;

        public override void PostUpdateEquips()
        {
            if (immolate)
            {

            }
        }

        public override void ResetEffects()
        {
            immolate = false;
        }

        public override float UseTimeMultiplier(Item item)
        {
            return immolate ? 1.5f : 1f;
        }
    }
}
