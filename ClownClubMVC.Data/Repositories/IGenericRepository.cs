namespace ClownClub.Data.Repositories
{
	public interface IGenericRepository<TEntityModel> where TEntityModel : class
	{
		Task<bool> Insert(TEntityModel modelo);
		Task<bool> Update(TEntityModel modelo);
		Task<bool> Delete (int id);
		Task<TEntityModel> GetOne (int id);
		Task<IQueryable<TEntityModel>> GetAll();
	}
}
