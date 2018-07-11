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
    public class Acc_KircheisShard : ModItem
    {
        public const int PRICE = 800;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Kircheis Shard"));
            Tooltip.SetDefault(string.Format("+15% Attack Speed"));
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
            recipe.AddIngredient(mod.ItemType<Acc_Dagger>());
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_Dagger.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackSpeed += .15f;
        }
    }
}
