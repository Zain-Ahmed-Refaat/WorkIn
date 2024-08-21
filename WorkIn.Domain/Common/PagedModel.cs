namespace WorkIn.Domain.Common
{
    public class PagedModel<TModel>
    {

        const int MaxPageSize = 500;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalUnSeen { get; set; }
        public int TotalActive { get; set; }
        public int TotalInActive { get; set; }
        public List<TModel> Items { get; set; }

        public PagedModel()
        {
            Items = new List<TModel>();
        }


    }
}
