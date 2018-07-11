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
    public class Acc_Zeal : ModItem
    {
        public const int PRICE = 1300;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Zeal"));
            Tooltip.SetDefault(string.Format("+15% Attack Speed" +
                "\n+15% Critical Strike Chance" +
                "\n[c/b99d66:UNIQUE Passive:] +5% Movement Speed"));
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.value = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType<Acc_Dagger>());
            recipe.AddIngredient(mod.ItemType<Acc_BrawlersGloves>());
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_Dagger.PRICE - Acc_BrawlersGloves.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackSpeed += 0.15f;
            modPlayer.attackCrit += 15;
            player.moveSpeed += 0.05f;
        }
    }
}
