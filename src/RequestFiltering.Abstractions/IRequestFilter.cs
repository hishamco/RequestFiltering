namespace RequestFiltering
{
    public interface IRequestFilter
    {
        void ApplyFilter(RequestFilteringContext context);
    }
}
