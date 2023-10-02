namespace Data.DTO
{
    public class WorkDto
    {

        public int CodWork { get; set; }

        public DateTime Date { get; set; }

        public ProjectGetMinDto Project { get; set; }

        public ServiceGetMinDto Service { get; set; }

        public int HourQty { get; set; }

        public decimal HourValue { get; set; }

        public decimal Cost { get; set; }


    }
}
