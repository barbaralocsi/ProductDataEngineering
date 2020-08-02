namespace ProductDataEngineering.Domain
{
    public class Number
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public bool IsProcessed { get; set; } = false;
    }
}
