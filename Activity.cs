namespace DemoAPI
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string? ActivityKey { get; set; }
        public string? ActivityName { get; set; }    
        public ICollection<Designee>? Designees { get; set;}


    }
}
