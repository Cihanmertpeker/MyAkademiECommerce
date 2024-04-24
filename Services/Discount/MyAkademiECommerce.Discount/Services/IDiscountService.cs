using MyAkademiECommerce.Discount.Dtos;

namespace MyAkademiECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetResultCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsnyc(UpdateCouponDto updateCouponDto);
        Task<ResultCouponDto> GetCouponbById(int id);
    }
}
