using System.ComponentModel.DataAnnotations;

namespace FSManage.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        //用户id
        public string UserId { get; set; }
        //商品编号
        public string PrdNo { get; set; }
        ////商品单价
        //public decimal PrdPrice { get; set; }
        //商品名称
        public string PrdName { get; set; }
        //商品数量
        public int PrdQty { get; set; }
        //是否结算
        public int SettleStt { get; set; }
    }
}