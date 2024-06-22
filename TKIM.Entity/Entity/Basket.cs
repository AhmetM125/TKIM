namespace TKIM.Entity.Entity;

public class Basket : BaseEntity
{
    public Guid ID { get; set; }
    public Guid PERSON_ID { get; set; }
    public Person Person { get; set; }

    public List<BasketItems> BasketItems { get; set; }

    public decimal TOTAL_PRICE { get; set; }
    public decimal TOTAL_TAX { get; set; }
    public decimal TOTAL_DISCOUNT { get; set; }
    public decimal TOTAL_PAYMENT { get; set; }


}
