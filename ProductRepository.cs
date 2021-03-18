using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using JDS_PRICELIST_2021.Models;
using Dapper;

namespace JDS_PRICELIST_2021
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _conn;

        public ProductRepository(IDbConnection conn)
        {
            _conn = conn;
        }
     

        public IEnumerable<products> GetAllProducts()
        {
            return _conn.Query<products>("SELECT * FROM PRODUCTS;");
        }       

        public products GetProduct(int id)
        {
            return _conn.QuerySingle<products>("SELECT * FROM PRODUCTS WHERE ITEMID = @id", new { id = id });
        }

       

        public void UpdateProduct(products Product)
        {
            _conn.Execute("UPDATE products SET SHORT_DESCRIPTION = @Name,  LESS_THAN_CASE_PRICE = @PriceLTC, " +
                "ONE_CASE = @PriceOneCase, FIVE_CASE = @PriceFiveCase, TEN_CASE = @PriceTenCase WHERE ItemID = @id",
              new { Name = Product.SHORT_DESCRIPTION, PriceLTC = Product.LESS_THAN_CASE_PRICE, 
                  PriceOneCase = Product.ONE_CASE, PriceFiveCase = Product.FIVE_CASE, PriceTenCase = Product.TEN_CASE,
                  id = Product.ItemID });
        }

      
        public void InsertProduct(products productToInsert)
        {
            _conn.Execute("INSERT INTO products (SHORT_DESCRIPTION, CLASS, ITEM, CASE_QTY, LESS_THAN_CASE_PRICE, ONE_CASE, FIVE_CASE, TEN_CASE, GENDER, MATERIAL, WEIGHT, COLOR, SIZE, LENGTH, WIDTH, HEIGHT, KEYWORD, IMAGE, LONG_DESCRIPTION, PRICE_BREAK_4, PRICE_BREAK_5, PAGE, DESCRIPTION_1, DESCRIPTION_2 )" +
                " VALUES (@short_description, @CLASS, @item, @case_qty, @ltc_price, @one_case, @five_case, @ten_case, @gender, @material, @weight, @color, @size, @length, @width, @height, @keyword,  @image, @long_description, @price_break_4, @price_break_5, @page, @description_1, @description_2 );",
                new { short_description = productToInsert.SHORT_DESCRIPTION,  
                      CLASS = productToInsert.CLASS, 
                      item = productToInsert.ITEM,
                      description_2 = productToInsert.DESCRIPTION_2, 
                      case_qty = productToInsert.CASE_QTY,
                      ltc_price = productToInsert.LESS_THAN_CASE_PRICE, 
                      one_case = productToInsert.ONE_CASE,
                      five_case = productToInsert.FIVE_CASE,
                      ten_case = productToInsert.TEN_CASE, 
                      weight = productToInsert.WEIGHT, image = productToInsert.IMAGE, 
                      color = productToInsert.COLOR, 
                      size = productToInsert.SIZE,
                      material = productToInsert.MATERIAL,
                      gender = productToInsert.GENDER,
                      keyword = productToInsert.KEYWORD, 
                      long_description = productToInsert.LONG_DESCRIPTION, 
                      description_1 = productToInsert.DESCRIPTION_1,
                      length = productToInsert.LENGTH,
                      width = productToInsert.WIDTH, 
                      height = productToInsert.HEIGHT,
                      price_break_4 = productToInsert.PRICE_BREAK_4,
                      price_break_5 = productToInsert.PRICE_BREAK_5,
                      page = productToInsert.PAGE});
        }
        
        public IEnumerable<Item> GetItems()
        {
            return _conn.Query<Item>("SELECT * FROM products;");
        }

        public products AssignItem()
        {
            var itemList = GetItems();
            var product = new products();
            product.Items = itemList;

            return product;

        }
        public void DeleteProduct(products product)
        {
          //  _conn.Execute("DELETE FROM REVIEWS WHERE ItemID = @id;",
          //                             new { id = product.ItemID });
          //  _conn.Execute("DELETE FROM Sales WHERE ItemID = @id;",
          //                             new { id = product.ItemID });
            _conn.Execute("DELETE FROM products WHERE ItemID = @id;",
                                       new { id = product.ItemID });
        }

    }
}
