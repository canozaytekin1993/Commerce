namespace Commerce.Domain.Configurations
{
    public class Settings
    {
        public Settings(string name, string value, int id)
        {
            Name = name;
            Value = value;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}