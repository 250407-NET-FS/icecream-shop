using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories;

namespace IcecreamShopAPI.Services {
    class IcecreamService: IIcecreamService {
        private readonly IceCreamRepo _icecreamRepo;

        public IcecreamService(IceCreamRepo iceCreamRepo) {
            _icecreamRepo = iceCreamRepo;
        }
        public bool ValidateIcecream(Icecream icecream) {
            return (
                icecream.Scoops > 0 &&
                (icecream.Flavors.Count == icecream.Scoops)
            );
        }
        public Icecream AddIcecream(Icecream icecream) {
            if (ValidateIcecream(icecream)) {
                return _icecreamRepo.AddIcecream(icecream);
            }
            else {
                throw new ArgumentException("Icecream has invalid input");
            }
        }
        public Icecream UpdateIcecream(Icecream icecream) {
            if (ValidateIcecream(icecream)) {
                return _icecreamRepo.UpdateIcecream(icecream);
            }
            else {
                throw new ArgumentException("Icecream has invalid input");
            }
        }
        public Icecream DeleteIcecream(Icecream icecream) {
            return _icecreamRepo.RemoveIcecream(icecream);
        }
        public List<Icecream> GetIcecreamList() {
            return _icecreamRepo.GetAllIcecream();
        }
    }
}