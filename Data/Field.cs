namespace Project_PRN221_BookingFields.Data
{
    public class Field
    {
        public int Id { get; set; }
        public int FieldNumber { get; set; }
        public int FieldTypeId { get; set; }
        public FieldBook Status { get; set; }
        public decimal Price {  get; set; }
        public string FieldPicture { get; set;}
        public FieldType FieldType { get; set; }
    }
    public enum FieldBook
    {
        Booked,Available
    }
}
