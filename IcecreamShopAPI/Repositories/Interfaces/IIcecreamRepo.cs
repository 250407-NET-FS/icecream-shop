using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    interface IIcecreamRepo {
        public List<Icecream> GetAllIcecream();
        public Icecream AddIcecream(Icecream icecream);
        public void SaveIcecreamList(List<Icecream> icecream);
        public Icecream UpdateIcecream(Icecream icecream);
        public Icecream RemoveIcecream(Icecream icecream);
    }
}