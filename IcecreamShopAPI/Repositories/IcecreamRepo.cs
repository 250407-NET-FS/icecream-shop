using System.Text.Json;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    class IceCreamRepo : IIcecreamRepo {
        private readonly string _jsonPath;

        public IceCreamRepo() {
            _jsonPath = "./Data-Files/icecream.json";
        }

        public List<Icecream> GetAllIcecream() {
            try {
                if (!File.Exists(_jsonPath)) {
                    return [];
                }

                using FileStream stream = File.OpenRead(_jsonPath);
                return JsonSerializer.Deserialize<List<Icecream>>(stream) ?? [];
            }
            catch (Exception) {
                throw new Exception("Could not retrieve any icecream");
            }
        }

        public Icecream AddIcecream(Icecream icecream) {
            List<Icecream> icecreams = GetAllIcecream();
            icecreams.Add(icecream);
            SaveIcecreamList(icecreams);
            return icecream;
        }

        public Icecream UpdateIcecream(Icecream icecream) {
            List<Icecream> icecreams = GetAllIcecream();
            int index = icecreams.FindIndex(i => i.Equals(icecream));
            icecream.Customers = icecreams[index].Customers;
            icecreams[index] = icecream;
            SaveIcecreamList(icecreams);
            return icecream;
        }

        public Icecream RemoveIcecream(Icecream icecream) {
            List<Icecream> icecreams = GetAllIcecream();
            icecreams.Remove(icecream);
            SaveIcecreamList(icecreams);
            return icecream;
        }
        
        public void SaveIcecreamList(List<Icecream> icecreams) {
            FileStream stream = File.Create(_jsonPath);
            JsonSerializer.Serialize(stream, icecreams);
            stream.Close();
        }
    }
}