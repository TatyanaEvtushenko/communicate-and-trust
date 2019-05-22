namespace CAT.DataLayer.Models
{
    public class TrainingSource
    {
        public int Id { get; set; }
        
        public string SourceUrl { get; set; }

        public TrainingSession TrainingSession { get; set; }
    }
}
