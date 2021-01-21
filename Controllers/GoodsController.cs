using DotnetCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [EnableCors("any")]
    public class GoodsController  : ControllerBase
    {
        private readonly TodoContext _context;
        public GoodsController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async  Task<ActionResult> ResetGoods()
        {
            var goods = await _context.Goods.ToListAsync();
            Random r = new Random();
            List<string> lst = new List<string>() { "新品", "精选", "流行" };
            foreach (var item in goods)
            {
                item.GoodsType = lst[r.Next(0, 3)];
                item.Price = r.Next(1, 2000);
                item.DiscountPrice = Convert.ToDecimal(Convert.ToDouble(item.Price) * (r.Next(1, 9) * 1.0 / 10));
                _context.Goods.Update(item);
                _context.SaveChanges();
            }

           return Ok();

        }

        public async Task<ObjectResult> GetHomeGoodsList(string type,int page)
        {
            var gtype = "";
            var pageSize = 10;
            switch (type)
            {
                case "news":
                    gtype = "新品";
                    break;
                case "prop":
                    gtype = "流行";
                    break;
                case "sift":
                    gtype = "精选";
                    break;
            }

            var goods = await _context.Goods.Where(x => x.GoodsType == gtype).ToListAsync();
            var lst = goods.Skip(page * pageSize).Take(pageSize);

            return Ok(lst);
        }

        public async Task<ObjectResult> GetDetails( int id)
        {
           
            var goods = await _context.Goods.Where(x => x.Id==id).FirstOrDefaultAsync();
           
            return Ok(goods);
        }

    }
}
