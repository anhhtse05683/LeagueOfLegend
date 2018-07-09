using LeagueOfLegend.Items.Accessories;
using LeagueOfLegend.Items.AttackDamageClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_SerratedDirk : ModItem
    {
        public const int PRICE = 1100;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(string.Format("[c/FF8C00:+25 Attack Damage]" +
                "\n[c/b99d66:UNIQUE Passive:] +10 Lethality"));
        }

        public override void SetDefaults()
        {
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Items.Accessories.Acc_LongSword>(), 2);
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - Acc_LongSword.PRICE * 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackBonus += 25;
            modPlayer.lethality += 10;
        }
    }
}
