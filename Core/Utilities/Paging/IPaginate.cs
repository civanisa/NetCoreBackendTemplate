namespace Core.Utilities.Paging
{
    public interface IPaginate<T>
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public List<T> Items { get; set; }
    }
}
