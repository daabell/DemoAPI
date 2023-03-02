namespace DemoAPI
{
    public class Activity
    {
        public int ActivityID { get; set; }
        public string? ActivityKey { get; set; }
        public string? ActivityName { get; set; }    
        public List<Designee>? Designees { get; set;}


    }
}
