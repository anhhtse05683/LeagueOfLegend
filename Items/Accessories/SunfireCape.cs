using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace LeagueOfLegend.Items.Accessories
{
    public class SunfireCape : ModItem
    {
        public const int PRICE = 2900;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault(
                string.Format("[c/0596aa:+450 Health]" +
                "\n[c/0596aa:+60 Armor]" +
                "\n[c/b99d66:UNIQUE Passive - Immolate:]") +
                "\nDeals 25(+1 per 100 player's health)" +
                "\nmagic damage per second to nearby enemies." +
                "\nDeals 100% bonus damage while in desert biome.");
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
            recipe.AddIngredient(mod.ItemType<Items.Accessories.ChainVest>());
            recipe.AddIngredient(mod.ItemType<Items.Accessories.RubyCrystal>());
            recipe.AddIngredient(mod.ItemType<Items.Accessories.BamisCinder>());
            recipe.AddIngredient(mod.ItemType<Items.Gold>(), (PRICE - ChainVest.PRICE - RubyCrystal.PRICE - BamisCinder.PRICE));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += 450;
            player.statDefense += 60;
            mod.ProjectileType<Projectiles.ImmolateProjectile>();
        }
        
    }
}
