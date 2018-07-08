using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace LeagueOfLegend.Projectiles
{
    public class ImmolateProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 256;
            projectile.height = 256;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.timeLeft = 1;
            projectile.aiStyle = 0;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.damage = 25;
        }

        public override void AI()
        {
            projectile.Center = Main.LocalPlayer.Center;
        }
    }
}
