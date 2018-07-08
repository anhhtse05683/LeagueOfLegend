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

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Immolate");
            Main.projFrames[projectile.type] = 1;
        }

        public override void SetDefaults()
        {
            projectile.width = 256;
            projectile.height = 256;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.timeLeft = 1;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.light = 0.2f;
            projectile.aiStyle = 0;
            projectile.timeLeft = 1;
        }

        public override void AI()
        {

            Player player = Main.player[projectile.owner];
            LeagueOfLegendPlayer modPlayer = player.GetModPlayer<LeagueOfLegendPlayer>(mod);
            
            if (!player.active || player.dead || !modPlayer.immolate)
            {
                projectile.Kill();
                return;
            }

            projectile.Center = Main.LocalPlayer.Center;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 1); // sets enemy on fire for 1 tick
        }
    }
}
