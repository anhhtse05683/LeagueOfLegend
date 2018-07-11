using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using LeagueOfLegend.Items.AttackDamageClass;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_InfinityEdge : ModItem
    {
        public const int PRICE = 3600;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Infinity Edge"));
            Tooltip.SetDefault(string.Format("+80 Attack Damage" +
                "\n[c/b99d66:UNIQUE Passive:] Double your critical strike chance."));
        }

        public override void SetDefaults()
        {
            item.value = 1;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Acc_BFSword>(), 2);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_BFSword.PRICE * 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LeagueOfLegendPlayer>(mod).infinityEdge = true;

            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackBonus += 80;
        }
    }
}
