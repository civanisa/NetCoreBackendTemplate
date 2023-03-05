namespace Core.Utilities.Paging
{
    public class Paginate<T> : IPaginate<T>
    {
        public int Index { get; set; }
        public int Size { get; set; }
        public int Page { get; set; }
        public int Count { get; set; }
        public List<T> Items { get; set; }

        public Paginate()
        {

        }
        public Paginate<T> MakePagination(List<T> items, Pageable pageable, int count)
        {
            Items = items;
            Index = pageable.Page;
            Size = pageable.Size;
            Count = count;
            Page = count / pageable.Size + 1;
            return this;
        }

    }
}
