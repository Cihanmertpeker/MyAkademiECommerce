namespace MyAkademiECommerce.Discount.Dtos
{
    public class ResultCouponDto
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
