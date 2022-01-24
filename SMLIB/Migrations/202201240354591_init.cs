namespace SMLIB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        AttributeId = c.Guid(nullable: false),
                        AttributeName = c.String(),
                        AttributeValue = c.String(),
                        ProductId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AttributeId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        CategoryValue = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        Order_Transaction = c.Guid(nullable: false),
                        Order_UserId = c.Guid(nullable: false),
                        Order_ProductId = c.Guid(nullable: false),
                        Order_DateTime = c.DateTime(nullable: false),
                        Order_Quantity = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Guid(nullable: false),
                        ProductName = c.String(),
                        ProductDescription = c.String(),
                        ProductBarcode = c.String(),
                        ProductBarcodeImage = c.String(),
                        ProductSku = c.String(),
                        ProductImage = c.String(),
                        ProductVat = c.Double(nullable: false),
                        ProductUnitCost = c.Double(nullable: false),
                        ProductQuantity = c.Double(nullable: false),
                        ProductReplenishLimit = c.Double(nullable: false),
                        ProductReorderLimit = c.Double(nullable: false),
                        ProductDiscount = c.Double(nullable: false),
                        ProductDateAdded = c.String(),
                        ProductUnitOfMeasurement = c.Guid(nullable: false),
                        ProductCategory = c.Guid(nullable: false),
                        ProductSubCategory = c.Guid(nullable: false),
                        ProductStatus = c.Guid(nullable: false),
                        ProductStore = c.Guid(nullable: false),
                        ProductSupplier = c.Guid(nullable: false),
                        ProductWarehouse = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Guid(nullable: false),
                        StatusValue = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Guid(nullable: false),
                        StoreName = c.String(),
                        StoreAddress = c.String(),
                        StoreContactNumber = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Guid(nullable: false),
                        SubCategoryValue = c.String(),
                    })
                .PrimaryKey(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierId = c.Guid(nullable: false),
                        SupplierName = c.String(),
                        SupplierAddress = c.String(),
                        SupplierContactNumber = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Guid(nullable: false),
                        TransactionAmountReceived = c.Double(nullable: false),
                        TransactionAmountReturned = c.Double(nullable: false),
                        TransactionNewAmountReturned = c.Double(nullable: false),
                        TransactionSubTotal = c.Double(nullable: false),
                        TransactionDate = c.String(),
                        Transaction_Remarks = c.String(),
                        Transaction_Status = c.String(),
                        Transaction_OwnerId = c.Guid(nullable: false),
                        Transaction_CashierId = c.Guid(nullable: false),
                        Transaction_Time = c.String(),
                        TransactionDateModified = c.String(),
                        TransactionTimeModified = c.String(),
                    })
                .PrimaryKey(t => t.TransactionId);
            
            CreateTable(
                "dbo.UnitOfMeasurements",
                c => new
                    {
                        UnitOfMeasurementId = c.Guid(nullable: false),
                        UnitOfMeasurementName = c.String(),
                    })
                .PrimaryKey(t => t.UnitOfMeasurementId);
            
            CreateTable(
                "dbo.UserDetails",
                c => new
                    {
                        UserDetailId = c.Guid(nullable: false),
                        UserFirstName = c.String(),
                        UserLastName = c.String(),
                        UserAddress = c.String(),
                        UserContactNumber = c.Double(nullable: false),
                        UserImage = c.String(),
                        UserRole = c.String(),
                        UserStatus = c.String(),
                    })
                .PrimaryKey(t => t.UserDetailId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        UserPassword = c.String(),
                        UserEmail = c.String(),
                        UserDetail_UserDetailId = c.Guid(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserDetails", t => t.UserDetail_UserDetailId)
                .Index(t => t.UserDetail_UserDetailId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        WarehouseId = c.Guid(nullable: false),
                        WarehouseName = c.String(),
                        WarehouseAddress = c.String(),
                        WarehouseContactNumber = c.Double(nullable: false),
                        WarehouseSubLocation = c.String(),
                    })
                .PrimaryKey(t => t.WarehouseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserDetail_UserDetailId", "dbo.UserDetails");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropIndex("dbo.Users", new[] { "UserDetail_UserDetailId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.Users");
            DropTable("dbo.UserDetails");
            DropTable("dbo.UnitOfMeasurements");
            DropTable("dbo.Transactions");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Stores");
            DropTable("dbo.Status");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductAttributes");
        }
    }
}
