namespace Core.Utilities.Paging
{
    public class Pageable
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public Pageable()
        {

        }
        public Pageable(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}
