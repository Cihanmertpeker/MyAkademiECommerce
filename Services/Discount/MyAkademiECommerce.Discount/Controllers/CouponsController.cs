using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademiECommerce.Discount.Dtos;
using MyAkademiECommerce.Discount.Services;

namespace MyAkademiECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public CouponsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _discountService.GetResultCouponsAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
           await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Değer başarıyla oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
          await _discountService.DeleteCouponAsync(id);
            return Ok("Değer başarıyla silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoupon(int id)
        {
            var value = await _discountService.GetCouponbById(id);
            return Ok(value);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsnyc(updateCouponDto);
            return Ok("Değer başarıyla güncellendi");
        }
    }
}
