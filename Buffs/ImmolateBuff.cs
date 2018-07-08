using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LeagueOfLegend.Buffs
{
    public class ImmolateBuff : ModBuff
    {

        public override void SetDefaults()
        {
        }

        public override void Update(Player player, ref int buffIndex)
        {
            mod.ProjectileType<Projectiles.ImmolateProjectile>();
        }
    }
}
