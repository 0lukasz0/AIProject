using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebStore.Models.DataBase
{
    public class SampleData : DropCreateDatabaseIfModelChanges<StoreItemsEntities>
    {
        protected override void Seed(StoreItemsEntities context)
        {
            var subCategories = new List<SubCategory>
            {
                new SubCategory { Name = "Cameras" },
                new SubCategory { Name = "Monitors" },
                new SubCategory { Name = "Desktop PCs" },
                new SubCategory { Name = "Game Consoles" },
                new SubCategory { Name = "Camcorders" },
                new SubCategory { Name = "Portable PCs" },
                new SubCategory { Name = "Accessories" },
                new SubCategory { Name = "Home Audio" },
                new SubCategory { Name = "Modems/Fax" },
                new SubCategory { Name = "Memory" },
                new SubCategory { Name = "Operating Systems" },
                new SubCategory { Name = "CD-ROM" },
                new SubCategory { Name = "Documentation" },
                new SubCategory { Name = "Recordable CDs" },
                new SubCategory { Name = "Recordable DVD Discs" },
                new SubCategory { Name = "Bulk Pack Diskettes" },
                new SubCategory { Name = "Printer Supplies" },
                new SubCategory { Name = "Camera Batteries" },
                new SubCategory { Name = "Camera Media" },
                new SubCategory { Name = "Y Box Games" },
                new SubCategory { Name = "Y Box Accessories" },
            };

            var categories = new List<Category>
            {
                new Category { Name = "Photo" },
                new Category { Name = "Peripherals and Accessories" },
                new Category { Name = "Hardware" },
                new Category { Name = "Software/Other" },
                new Category { Name = "Electronics" },
            };

            new List<Item>
            {
                new Item { Title = "5MP Telephoto Digital Camera", Category = categories.Single(g => g.Name == "Photo"), Price = 900M, SubCategory = subCategories.Single(a => a.Name == "Cameras"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now},
                new Item { Title = "17\" LCD w/built-in HDTV Tuner", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 1000M, SubCategory = subCategories.Single(a => a.Name == "Monitors"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Envoy 256MB - 40GB", Category = categories.Single(g => g.Name == "Hardware"), Price = 1000M, SubCategory = subCategories.Single(a => a.Name == "Desktop PCs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Y Box", Category = categories.Single(g => g.Name == "Electronics"), Price = 300M, SubCategory = subCategories.Single(a => a.Name == "Game Consoles"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Mini DV Camcorder with 3.5\" Swivel LCD", Category = categories.Single(g => g.Name == "Photo"), Price = 1100M, SubCategory = subCategories.Single(a => a.Name == "Camcorders"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Envoy Ambassador", Category = categories.Single(g => g.Name == "Hardware"), Price = 1300M, SubCategory = subCategories.Single(a => a.Name == "Portable PCs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Laptop carrying case", Category = categories.Single(g => g.Name == "Software/Other"), Price = 56M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Home Theatre Package with DVD-Audio/Video Play", Category = categories.Single(g => g.Name == "Electronics"), Price = 600M, SubCategory = subCategories.Single(a => a.Name == "Home Audio"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "18\" Flat Panel Graphics Monitor", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 900M, SubCategory = subCategories.Single(a => a.Name == "Monitors"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Envoy External Keyboard", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 25M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "External 101-key keyboard", Category = categories.Single(g => g.Name == "Software/Other"), Price = 22M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "PCMCIA modem/fax 28800 baud", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 46M, SubCategory = subCategories.Single(a => a.Name == "Modems/Fax"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "SIMM- 8MB PCMCIAII card", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 113M, SubCategory = subCategories.Single(a => a.Name == "Memory"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "SIMM- 16MB PCMCIAII card", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 150M, SubCategory = subCategories.Single(a => a.Name == "Memory"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Multimedia speakers- 3\" cones", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Unix/Windows 1-user pack", Category = categories.Single(g => g.Name == "Software/Other"), Price = 200M, SubCategory = subCategories.Single(a => a.Name == "Operating Systems"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "8.3 Minitower Speaker", Category = categories.Single(g => g.Name == "Electronics"), Price = 500M, SubCategory = subCategories.Single(a => a.Name == "Home Audio"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Mouse Pad", Category = categories.Single(g => g.Name == "Software/Other"), Price = 10M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "1.44MB External 3.5\" Diskette", Category = categories.Single(g => g.Name == "Software/Other"), Price = 9M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Multimedia speakers- 5\" cones", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 68M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "PCMCIA modem/fax 19200 baud", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Modems/Fax"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "External 6X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 40M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "External 8X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 50M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Envoy External 6X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Envoy External 8X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 55M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Internal 6X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 30M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Internal 8X CD-ROM", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 35M, SubCategory = subCategories.Single(a => a.Name == "CD-ROM"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - English", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - German", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - French", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - Spanish", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - Italian", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "O/S Documentation Set - Kanji", Category = categories.Single(g => g.Name == "Software/Other"), Price = 45M, SubCategory = subCategories.Single(a => a.Name == "Documentation"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Standard Mouse", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 23M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Deluxe Mouse", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 29M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Keyboard Wrist Rest", Category = categories.Single(g => g.Name == "Software/Other"), Price = 12M, SubCategory = subCategories.Single(a => a.Name == "Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "CD-R Mini Discs", Category = categories.Single(g => g.Name == "Software/Other"), Price = 23M, SubCategory = subCategories.Single(a => a.Name == "Recordable CDs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Music CD-R", Category = categories.Single(g => g.Name == "Software/Other"), Price = 19M, SubCategory = subCategories.Single(a => a.Name == "Recordable CDs"), ItemArtUrl = "/Content/Images/placeholder.gif" , LastInCart = System.DateTime.Now},
                new Item { Title = "CD-R with Jewel Cases pACK OF 12", Category = categories.Single(g => g.Name == "Software/Other"), Price = 7M, SubCategory = subCategories.Single(a => a.Name == "Recordable CDs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "DVD-R Disc with Jewel Case 4.7 GB", Category = categories.Single(g => g.Name == "Software/Other"), Price = 7M, SubCategory = subCategories.Single(a => a.Name == "Recordable DVD Discs"), ItemArtUrl = "/Content/Images/placeholder.gif" , LastInCart = System.DateTime.Now},
                new Item { Title = "DVD-RAM Jewel Case Double-Sided 9.4G", Category = categories.Single(g => g.Name == "Software/Other"), Price = 11M, SubCategory = subCategories.Single(a => a.Name == "Recordable DVD Discs"), ItemArtUrl = "/Content/Images/placeholder.gif" , LastInCart = System.DateTime.Now},
                new Item { Title = "DVD-R Discs 4.7GB Pack of 5", Category = categories.Single(g => g.Name == "Software/Other"), Price = 19M, SubCategory = subCategories.Single(a => a.Name == "Recordable DVD Discs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "DVD-R Discs 4.7GB Pack of 5", Category = categories.Single(g => g.Name == "Software/Other"), Price = 50M, SubCategory = subCategories.Single(a => a.Name == "Recordable DVD Discs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "DVD-RW Discs 4.7GB Pack of 3", Category = categories.Single(g => g.Name == "Software/Other"), Price = 19M, SubCategory = subCategories.Single(a => a.Name == "Recordable DVD Discs"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "3 1/2\" Bulk diskettes Box of 50", Category = categories.Single(g => g.Name == "Software/Other"), Price = 16M, SubCategory = subCategories.Single(a => a.Name == "Bulk Pack Diskettes"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "3 1/2\" Bulk diskettes Box of 100", Category = categories.Single(g => g.Name == "Software/Other"), Price = 29M, SubCategory = subCategories.Single(a => a.Name == "Bulk Pack Diskettes"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model CD13272 Tricolor Ink Cartridge", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 37M, SubCategory = subCategories.Single(a => a.Name == "Printer Supplies"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model SM26273 Black Ink Cartridge", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 28M, SubCategory = subCategories.Single(a => a.Name == "Printer Supplies"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model NM500X High Yield Toner Cartridge", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 193M, SubCategory = subCategories.Single(a => a.Name == "Printer Supplies"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model A3827H Black Image Cartridge", Category = categories.Single(g => g.Name == "Peripherals and Accessories"), Price = 90M, SubCategory = subCategories.Single(a => a.Name == "Printer Supplies"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model K3822L Cordless Phone Battery", Category = categories.Single(g => g.Name == "Photo"), Price = 19M, SubCategory = subCategories.Single(a => a.Name == "Camera Batteries"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model C9827B Cordless Phone Battery", Category = categories.Single(g => g.Name == "Photo"), Price = 25M, SubCategory = subCategories.Single(a => a.Name == "Camera Batteries"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model K8822S Cordless Phone Battery", Category = categories.Single(g => g.Name == "Photo"), Price = 31M, SubCategory = subCategories.Single(a => a.Name == "Camera Batteries"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Model C93822D Wireless Phone Battery", Category = categories.Single(g => g.Name == "Photo"), Price = 21M, SubCategory = subCategories.Single(a => a.Name == "Camera Batteries"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "S27273M Extended Use w/l Phone Batt.", Category = categories.Single(g => g.Name == "Photo"), Price = 50M, SubCategory = subCategories.Single(a => a.Name == "Camera Batteries"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "64MB Memory Card", Category = categories.Single(g => g.Name == "Photo"), Price = 33M, SubCategory = subCategories.Single(a => a.Name == "Camera Media"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "128MB Memory Card", Category = categories.Single(g => g.Name == "Photo"), Price = 53M, SubCategory = subCategories.Single(a => a.Name == "Camera Media"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "256MB Memory Card", Category = categories.Single(g => g.Name == "Photo"), Price = 70M, SubCategory = subCategories.Single(a => a.Name == "Camera Media"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Bounce", Category = categories.Single(g => g.Name == "Electronics"), Price = 20M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Endurance Racing", Category = categories.Single(g => g.Name == "Electronics"), Price = 30M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Smash up Boxing", Category = categories.Single(g => g.Name == "Electronics"), Price = 30M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Martial Arts Champions", Category = categories.Single(g => g.Name == "Electronics"), Price = 20M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Comic Book Heroes", Category = categories.Single(g => g.Name == "Electronics"), Price = 20M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Fly Fishing", Category = categories.Single(g => g.Name == "Electronics"), Price = 8M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Finding Fido", Category = categories.Single(g => g.Name == "Electronics"), Price = 13M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Adventures with Numbers", Category = categories.Single(g => g.Name == "Electronics"), Price = 12M, SubCategory = subCategories.Single(a => a.Name == "Y Box Games"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Extension Cable", Category = categories.Single(g => g.Name == "Electronics"), Price = 8M, SubCategory = subCategories.Single(a => a.Name == "Y Box Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },
                new Item { Title = "Xtend Memory", Category = categories.Single(g => g.Name == "Electronics"), Price = 21M, SubCategory = subCategories.Single(a => a.Name == "Y Box Accessories"), ItemArtUrl = "/Content/Images/placeholder.gif", LastInCart = System.DateTime.Now },         
            }.ForEach(a => context.Items.Add(a));
        }
    }
}