using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [AllowNull]
        public int CategoryId { get; set; }
        [AllowNull]
        public string CategoryName { get; set; }
        [AllowNull]
        public string UnitName { get; set; }
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public string Code { get; set; }
        [AllowNull]
        public string ParentCode { get; set; }
        [AllowNull]
        public string ProductBarcode { get; set; }
        [AllowNull]
        public string Description { get; set; }
        [AllowNull]
        public string BrandName { get; set; }
        [AllowNull]
        public string SizeName { get; set; }
        [AllowNull]
        public string ColorName { get; set; }
        [AllowNull]
        public string ModelName { get; set; }
        [AllowNull]
        public string VariantName { get; set; }
        [AllowNull]
        public float OldPrice { get; set; }
        [AllowNull]
        public float Price { get; set; }
        [AllowNull]
        public float CostPrice { get; set; }
        [AllowNull]
        [NotMapped]
        public string[] WarehouseList { get; set; }
        [AllowNull]
        public float stock { get; set; }
        [AllowNull]
        public float TotalPurchase { get; set; }
        [AllowNull]
        public DateTime LastPurchaseDate { get; set; }
        [AllowNull]
        public string LastPurchaseSupplier { get; set; }
        [AllowNull]
        public float TotalSales { get; set; }
        [AllowNull]
        public DateTime LastSalesDate { get; set; }
        [AllowNull]
        public string LastSalesCustomer { get; set; }
        [AllowNull]
        public string ImagePath { get; set; }
        [AllowNull]
        public string Type { get; set; }
        [AllowNull]
        public string Status { get; set; }
    }
}
