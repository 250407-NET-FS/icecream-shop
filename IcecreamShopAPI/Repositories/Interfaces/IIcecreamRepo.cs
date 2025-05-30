using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface IIcecreamRepo {
        public List<Icecream> GetAllIcecream();
        public Icecream AddIcecream(Icecream icecream);
        public Icecream UpdateIcecream(Icecream icecream);
        public Icecream RemoveIcecream(int id);
    }
}