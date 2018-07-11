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
    public class Acc_RecurveBow : ModItem
    {
        public const int PRICE = 1000;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Recurve Bow"));
            Tooltip.SetDefault(string.Format("+25% Attack Speed"));
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
            recipe.AddIngredient(mod.ItemType<Acc_Dagger>(), 2);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_Dagger.PRICE * 2);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackSpeed += 0.25f;
        }
    }
}
