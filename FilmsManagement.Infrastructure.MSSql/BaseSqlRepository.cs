namespace FilmsManagement.Infrastructure.MSSql
{
    public abstract class BaseSqlRepository<TContext> where TContext : BaseSqlContext 
    {
        protected TContext Context;

        protected BaseSqlRepository(TContext context)
        {
            Context = context;
        }
    }
}
