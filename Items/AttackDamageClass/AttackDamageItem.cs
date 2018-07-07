﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace LeagueOfLegend.Items.AttackDamageClass
{
    // This class handles everything for our custom damage class
    // Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
    public abstract class AttackDamageItem : ModItem
    {
        // Custom items should override this to set their defaults
        public virtual void SafeSetDefaults()
        {
        }

        // By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
        // We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
            // all vanilla damage types must be false for custom damage types to work
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
        }

        // As a modder, you could also opt to make the Get overrides also sealed, Up to the modder
        public override void GetWeaponDamage(Player player, ref int damage)
        {
            // Multiplies the damage by our custom damage multiplier
            damage = (int)((damage + AttackDamagePlayer.ModPlayer(player).attackBonus) * (AttackDamagePlayer.ModPlayer(player).attackDamage));
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.hardMode)
            {
                if(damage <= AttackDamagePlayer.ModPlayer(player).lethality)
                {
                    damage = (int)(damage + target.defense * 0.75f);
                }
                else
                {
                    damage = (int)(damage + AttackDamagePlayer.ModPlayer(player).lethality * 0.75f);
                }
            }
            else
            {
                if (damage <= AttackDamagePlayer.ModPlayer(player).lethality)
                {
                    damage = (int)(damage + target.defense * 0.5f);
                }
                else
                {
                    damage = (int)(damage + AttackDamagePlayer.ModPlayer(player).lethality * 0.5f);
                }
            }
            
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            // Adds knockback bonuses
            knockback = knockback + AttackDamagePlayer.ModPlayer(player).attackKnockback;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            // Adds crit bonuses
            crit = crit + AttackDamagePlayer.ModPlayer(player).attackCrit;
        }

        // Because we want the damage tooltip to show our custom damage, we need to modify it
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if(tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.text = string.Format("[c/0596aa:{0} attack {1}]", damageValue, damageWord);
            }
        }
    }
}