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
        public const int bamisCinder = 5;
        public const int sunfireCape = 25;

        public override void PostUpdateEquips()
        {
            if (immolate)
            {
                if(immolateTimer >= 60)
                {
                    int damage = bamisCinder + player.statLife / 100;

                    if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert)
                    {
                        damage += (int)(damage * 1.0f);
                    }

                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType<Projectiles.ImmolateProjectile>(), damage, 0f, player.whoAmI);

                    immolateTimer = 0;
                }
            }
        }

        public override void ResetEffects()
        {
            immolate = false;
        }
        
    }
}