using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppXamarin
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> itemsCars;

        List<Item> mockItemsCars = new List<Item>
            {
            new Item { Id = Guid.NewGuid().ToString(), Text = "Audi", 
                Description="Audi AG is a German automobile manufacturer that designs, engineers, produces, markets and distributes luxury vehicles. Audi is a member of the Volkswagen Group and has its roots at Ingolstadt, Bavaria, Germany.", 
                ImageUri="https://upload.wikimedia.org/wikipedia/en/thumb/a/a3/Audi_Logo.svg/300px-Audi_Logo.svg.png", 
                Price="€736.00" },
            new Item { Id = Guid.NewGuid().ToString(), Text = "BMW", 
                Description="BMW is a Germany-based company which currently produces automobiles and motorcycles, and produced aircraft engines until 1945. The company was founded in 1916 and has its headquarters in Munich, Bavaria.",
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/4/44/BMW.svg/240px-BMW.svg.png", 
                Price="€85.48" },
            new Item { Id = Guid.NewGuid().ToString(), Text = "Citröen", 
                Description="Citroën is a major French automobile manufacturer, part of the PSA Peugeot Citroën group since 1976, founded in 1919 by French industrialist André-Gustave Citroën.",
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Citroen_2016_logo.svg/2000px-Citroen_2016_logo.svg.png", 
                Price="€16.91"},
            new Item { Id = Guid.NewGuid().ToString(), Text = "Ferrari", 
                Description="Ferrari N.V. is an Italian sports car manufacturer based in Maranello. Founded by Enzo Ferrari in 1939 out of Alfa Romeo's race division as Auto Avio Costruzioni, the company built its first car in 1940.",
                ImageUri="https://upload.wikimedia.org/wikipedia/en/thumb/d/d1/Ferrari-Logo.svg/1200px-Ferrari-Logo.svg.png", 
                Price="€51.20" },
            new Item { Id = Guid.NewGuid().ToString(), Text = "Mercedes-Benz", 
                Description="Mercedes-Benz is a global automobile manufacturer and a division of the German company Daimler AG. The brand is known for luxury vehicles, buses, coaches, and lorries. The headquarters is in Stuttgart, Baden-Württemberg.",
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Mercedes-Benz_free_logo.svg/240px-Mercedes-Benz_free_logo.svg.png", 
                Price="€70.30"},
            new Item { Id = Guid.NewGuid().ToString(), Text = "Volvo", 
                Description="Volvo Cars, stylized as VOLVO in the logo, is a Swedish vehicle manufacturer established in 1927 and headquartered on Torslanda in Gothenburg.",
                ImageUri="https://upload.wikimedia.org/wikipedia/en/2/25/Volvo_Iron_Logo.png", 
                Price="$25.70"},
            };

        List<Item> itemsElectronics;

        List<Item> mockItemsElectronics = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Apple", 
                Description="Apple Inc. is an American multinational technology company headquartered in Cupertino, California that designs, develops, and sells consumer electronics, computer software, and online services.", 
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/8/84/Apple_Computer_Logo_rainbow.svg/218px-Apple_Computer_Logo_rainbow.svg.png", 
                Price="$169.37" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "BQ", 
                Description="Es una marca española dedicada al diseño, venta y distribución de lectores electrónicos, tabletas, teléfonos inteligentes, impresoras 3D y kits de robótica. Su empresa matriz es Mundo Reader S. L., la cual lanzó al mercado su primer lector electrónico en 2009 bajo la marca Booq, que en 2010 pasaría a ser BQ.3",
                ImageUri="https://www.underconsideration.com/brandnew/archives/bq_logo_detail.png", 
                Price="undefined" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Google", 
                Description="Google LLC is an American multinational technology company that specializes in Internet-related services and products. These include online advertising technologies, search, cloud computing, software, and hardware.",
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2f/Google_2015_logo.svg/272px-Google_2015_logo.svg.png", 
                Price="1,037.05"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Kingston", 
                Description="Kingston Technology Corporation is an American, privately held, multinational computer technology corporation that develops, manufactures, sells and supports flash memory products and other computer-related memory products.",
                ImageUri="https://upload.wikimedia.org/wikipedia/en/thumb/7/74/Kingston_Technology_logo.svg/400px-Kingston_Technology_logo.svg.png", 
                Price="Not relevant" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Mountain", 
                Description="Es una empresa electrónica española fundada en 2007 dedicada a terminar el ensamblado de sistemas informáticos de alto rendimiento fabricados por otras empresas. Sus productos incluyen ordenadores portátiles y de sobremesa destinados al diseño gráfico, al uso de videojuegos y a tareas multimedia.",
                ImageUri="https://i.pinimg.com/736x/37/80/a0/3780a0461d85fa27f2d0ec8efee9cffb--logos-with-mountains-mountain-logos.jpg", 
                Price="null"},
                new Item { Id = Guid.NewGuid().ToString(), Text = "Samsung", 
                Description="Samsung Group is a South Korean multinational conglomerate headquartered in Samsung Town, Seoul. It comprises numerous affiliated businesses, most of them united under the Samsung brand, and is the largest South Korean chaebol.",
                ImageUri="https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Samsung_Logo.svg/320px-Samsung_Logo.svg.png", 
                Price="₩2,600,000"},
            };


        public MockDataStore()
        {
            itemsCars = new List<Item>();           

            foreach (var item in mockItemsCars)
            {
                itemsCars.Add(item);
            }

            itemsElectronics = new List<Item>();

            foreach (var item in mockItemsElectronics)
            {
                itemsElectronics.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            itemsCars.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = itemsCars.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            itemsCars.Remove(_item);
            itemsCars.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = itemsCars.Where((Item arg) => arg.Id == id).FirstOrDefault();
            itemsCars.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(itemsCars.FirstOrDefault(s => s.Id == id));
        }
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {          
            return await Task.FromResult(itemsCars);         
           
        } 
        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false, string nameOfList = "Coches")
        {
            if(nameOfList.Equals("Coches")){
                return await Task.FromResult(itemsCars);
            }
            else{
                return await Task.FromResult(itemsElectronics);
            }
           
        }       
    }
}
