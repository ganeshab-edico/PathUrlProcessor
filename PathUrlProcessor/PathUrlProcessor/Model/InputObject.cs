namespace PathUrlProcessor.Model
{
    public class InputObject
    {
        public string Url { get; set; }
        public string Path { get; set; }
        public int Size { get; set; }

        public override string ToString()
        {
            return $"Url - {Url}, Path - {Path}, Size - {Size}";
        }
    }
}