using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LeagueOfLegend.Items.AttackDamageClass;

namespace LeagueOfLegend
{
    public class LeagueOfLegendPlayer : ModPlayer
    {
        public bool immolate = false;
        public int timer = 0;
        public bool eternity = false;
        public const int bamisCinder = 5;
        public const int sunfireCape = 25;
        public float eternityManaConsumed = 0f;
        public float currentTickMana = 0;
        public float lastTickMana = 0;
        public float consumedMana = 0;
        public bool infinityEdge = false;

        public override void PostUpdateEquips()
        {
            timer++;

            // Eternity passive
            lastTickMana = currentTickMana;
            currentTickMana = player.statMana;
            consumedMana = lastTickMana - currentTickMana;
            if (consumedMana < 0)
            {
                eternityManaConsumed += 0;
            }
            else
            {
                eternityManaConsumed += consumedMana;
            }

            if (eternity)
            {
                if (timer % 60 == 0)
                {
                    int healAmount = (int)(eternityManaConsumed * 0.2f);

                    if (healAmount == 0)
                    {

                    }
                    else if (healAmount > 15)
                    {
                        player.HealEffect(15, true);
                        eternityManaConsumed = 0;
                        timer = 0;
                    }
                    else
                    {
                        player.HealEffect(healAmount, true);
                        eternityManaConsumed = 0;
                        timer = 0;
                    }
                }
            }

            // Immolate passive
            if (immolate)
            {
                if(timer % 60 == 0)
                {
                    int k;
                    bool flag = false;
                    int damage = bamisCinder;

                    for (k = 3; k < 8 + player.extraAccessorySlots; k++)
                    {
                        if(player.armor[k].type == mod.ItemType("Acc_SunfireCape"))
                        {
                            damage = sunfireCape;
                            flag = true;
                            break;
                        }
                    }
                    damage += player.statLife / 100;
                    
                    if (Main.player[Player.FindClosest(player.position, player.width, player.height)].ZoneDesert)
                    {
                        if (flag)
                        {
                            damage += (int)(damage * 0.5f);
                        }
                        else
                        {
                            damage += (int)(damage * 1.0f);
                        }
                    }
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, mod.ProjectileType<Projectiles.ImmolateProjectile>(), damage, 0f, player.whoAmI);
                    timer = 0;
                }
            }

            // Infinity Edge passive
            if (infinityEdge)
            {
                AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
                modPlayer.attackCrit *= 2;
            }

        }

        public override void ResetEffects()
        {
            immolate = false;
            eternity = false;
            infinityEdge = false;
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {

        }

    }
}