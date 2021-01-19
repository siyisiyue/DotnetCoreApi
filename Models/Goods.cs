using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Models
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string GoodsType { get; set; }
        public int Start { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
