using AutoMapper;
using Dapper;
using MyAkademiECommerce.Discount.Context;
using MyAkademiECommerce.Discount.Dtos;
using MyAkademiECommerce.Discount.Models;

namespace MyAkademiECommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponCode,Rate,IsActive,ValidDate) values (@couponCode,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", createCouponDto.CouponCode);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", true);
            parameters.Add("@validDate", DateTime.Now.AddDays(10));
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "delete from Coupons where CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }


        public async Task<ResultCouponDto> GetCouponbById(int id)
        {
            string query = "select * from Coupons where CouponID = @CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID",id);
            using(var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query,parameters);
                return value;
            }

        }

        public async Task<List<ResultCouponDto>> GetResultCouponsAsync()
        {
            string query = "select * from Coupons";
            using(var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCouponAsnyc(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons set CouponCode =@Couponcode, Rate=@Rate, IsActive=@IsActive, ValidDate=@ValidDate where CouponID=@CouponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", updateCouponDto.CouponCode);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponID", updateCouponDto.CouponID);            
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

    }
}
