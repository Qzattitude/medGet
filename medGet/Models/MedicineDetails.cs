namespace medGet.Models
{
    public class MedicineDetails
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public string Generic { get; set; }
        public string Strength { get; set; }
        public string Dosages { get; set; }
        public string Price { get; set; }
        public string UsedFor { get; set; }
        public string DAR { get; set; }
    }
}
