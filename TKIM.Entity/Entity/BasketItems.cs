﻿namespace TKIM.Entity.Entity;

public class BasketItems : BaseEntity
{
    public Guid ID { get; set; }
    public Product Product { get; set; }
    public Guid PRODUCT_ID  { get; set; }
    public int QUANTITY_IN_CART { get; set; }
    public int QUANTITY_AFTER { get; set; }
    public int QUANTITY_CURRENT { get; set; }
    public decimal CURRENT_PURCHASE_PRICE { get; set; }
    public decimal CURRENT_SALE_PRICE { get; set; }
    public decimal CURRENT_PROFIT { get; set; }
    public decimal CURRENT_TAX { get; set; }
    public decimal TOTAL_PRICE { get; set; }

    public Basket Basket { get; set; }
    public Guid BASKET_ID { get; set; }

}
