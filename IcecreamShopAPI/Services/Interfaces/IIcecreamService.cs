using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Services.Interfaces {
    interface IIcecreamService {
        public bool ValidateIcecream(Icecream icecream);
        public Icecream AddIcecream(Icecream icecream);
        public Icecream UpdateIcecream(Icecream icecream);
        public Icecream DeleteIcecream(Icecream icecream);
        public List<Icecream> GetIcecreamList();
    }
}