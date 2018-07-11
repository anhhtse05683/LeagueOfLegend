using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LeagueOfLegend.Items.AttackDamageClass
{
    // This class stores necessary player info for out custom damage class, such as damage multiplierts and additions to knockback and crit.
    public class AttackDamagePlayer : ModPlayer
    {
        public static AttackDamagePlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<AttackDamagePlayer>();
        }

        // Vanilla only really has damage multiplers in code
        // And crit and knockback is usually just added to
        // As a modder, you could make separate variables for multipliers and simple addition bonuses
        public float attackDamage = 1f;
        public int attackBonus = 0;
        public float attackKnockback = 0f;
        public int attackCrit = 0;
        public int lethality = 0;
        public float attackSpeed = 1f;
        
        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            attackBonus = 0;
            attackDamage = 1f;
            attackKnockback = 0f;
            attackCrit = 0;
            lethality = 0;
            attackSpeed = 1f;
        }
    }
}
