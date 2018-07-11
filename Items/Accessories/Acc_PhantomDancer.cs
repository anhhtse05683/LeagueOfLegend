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
    public class Acc_PhantomDancer : ModItem
    {
        public const int PRICE = 2800;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(string.Format("Phantom Dancer"));
            Tooltip.SetDefault(string.Format("+45% Attack Speed" +
                "\n+30% Critical Strike Chance" +
                "\n+5% Movement Speed"));
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
            recipe.AddIngredient(mod.ItemType<Acc_Zeal>());
            recipe.AddIngredient(mod.ItemType<Acc_Dagger>(), 2);
            recipe.AddIngredient(mod.ItemType<Gold>(), PRICE - Acc_Dagger.PRICE * 2 - Acc_Zeal.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackSpeed += .45f;
            modPlayer.attackCrit += 30;
            player.moveSpeed += .05f;
        }
    }
}
