namespace BorderControl
{
    public class Robot : IIdentifiable
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
    }
}