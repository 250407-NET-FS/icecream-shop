using System.Text.Json;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    public class IceCreamRepo : IIcecreamRepo {
        private readonly string _jsonPath;

        public IceCreamRepo() {
            _jsonPath = "./Data-Files/icecream.json";
        }

        public List<Icecream> GetAllIcecream() {
            try {
                if (!File.Exists(_jsonPath)) {
                    return [];
                }

                using FileStream reader = File.OpenRead(_jsonPath);
                return JsonSerializer.Deserialize<List<Icecream>>(reader) ?? [];
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

        public Icecream UpdateIcecream(Icecream icecream, int id) {
            List<Icecream> icecreams = GetAllIcecream();
            icecreams[id] = icecream;
            SaveIcecreamList(icecreams);
            return icecream;
        }

        public Icecream RemoveIcecream(int id) {
            List<Icecream> icecreams = GetAllIcecream();
            Icecream icecream = icecreams[id];
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