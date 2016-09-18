namespace RequestFiltering
{
    public abstract class RequestFilter<TOptions> : IRequestFilter<TOptions> where TOptions : IRequestFilterOptions
    {
        public abstract TOptions Options { get; }

        public virtual void ApplyFilter(RequestFilteringContext context)
        {
            context.Result = RequestFilteringResult.Continue;
        }
    }
}
