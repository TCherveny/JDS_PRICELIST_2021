using JDS_PRICELIST_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace JDS_PRICELIST_2021
{
    public interface IProductRepository
    {
        public IEnumerable<products> GetAllProducts();
        public products GetProduct(int id);
        public void UpdateProduct(products Product);
        public void InsertProduct(products productToInsert);
        public IEnumerable<Item> GetItems();
        public products AssignItem();
        public void DeleteProduct(products product);
            
    }

}
