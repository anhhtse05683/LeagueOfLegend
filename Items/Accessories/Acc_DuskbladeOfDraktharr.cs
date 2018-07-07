using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using LeagueOfLegend.Items.AttackDamageClass;

namespace LeagueOfLegend.Items.Accessories
{
    public class Acc_DuskbladeOfDraktharr : ModItem
    {
        public const int PRICE = 2900;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duskblade of Draktharr");
            Tooltip.SetDefault(string.Format("[c/0596aa:+55 Attack Damage]" +
                "\n[c/b99d66:UNIQUE Passive:] +18 Lethality"));
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
            recipe.AddIngredient(mod.ItemType<Items.Accessories.CaulfieldsWarhammer>());
            recipe.AddIngredient(mod.ItemType<Items.Accessories.SerratedDirk>());
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), PRICE - CaulfieldsWarhammer.PRICE - SerratedDirk.PRICE);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            AttackDamagePlayer modPlayer = AttackDamagePlayer.ModPlayer(player);
            modPlayer.attackBonus += 55;
            modPlayer.lethality += 18;
        }
    }
}
