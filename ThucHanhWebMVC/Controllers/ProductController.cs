using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThucHanhWebMVC.Models;
using ThucHanhWebMVC.Models.ProductModels;

namespace ThucHanhWebMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        QlbanValiContext db = new QlbanValiContext();
        [HttpGet]
        public IEnumerable<Product> GettAllProducts()
        {
            var sanPham = (from p in db.TDanhMucSps
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai=p.MaLoai,
                               AnhDaiDien=p.AnhDaiDien,
                               GiaNhoNhat=p.GiaNhoNhat

                           }).ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public IEnumerable<Product> GettProductsByCategory(string maLoai)
        {
            var sanPham = (from p in db.TDanhMucSps
                           where p.MaLoai== maLoai
                           select new Product
                           {
                               MaSp = p.MaSp,
                               TenSp = p.TenSp,
                               MaLoai = p.MaLoai,
                               AnhDaiDien = p.AnhDaiDien,
                               GiaNhoNhat = p.GiaNhoNhat

                           }).ToList();
            return sanPham;
        }
    }
}
