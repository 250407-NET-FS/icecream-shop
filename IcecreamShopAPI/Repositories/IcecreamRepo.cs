using IcecreamShopAPI.Data;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IcecreamShopAPI.Repositories {
    public class IceCreamRepo : IIcecreamRepo {
        private readonly ShopDbContext _shopDb;

        public IceCreamRepo(ShopDbContext context) {
            _shopDb = context;
        }

        public List<Icecream> GetAllIcecream() {
            return _shopDb.Icecreams.ToList();
        }

        public Icecream AddIcecream(Icecream icecream) {
            _shopDb.Icecreams.Add(icecream);
            _shopDb.SaveChanges();
            return icecream;
        }

        public Icecream UpdateIcecream(Icecream icecream) {
            _shopDb.Icecreams.Update(icecream);
            _shopDb.SaveChanges();
            return icecream;
        }

        public Icecream RemoveIcecream(int id) {
            Icecream icecream = _shopDb.Icecreams.Find(id)!;
            _shopDb.Icecreams.Remove(icecream);
            _shopDb.SaveChanges();
            return icecream;
        }
    }
}