using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Services.Interfaces {
    interface IIcecreamService {
        public bool ValidateIcecream(Icecream icecream);
        public Icecream AddIcecream(Icecream icecream);
        public Icecream UpdateIcecream(Icecream icecream);
        public Icecream DeleteIcecream(int id);
        public List<Icecream> GetIcecreamList();
    }
}