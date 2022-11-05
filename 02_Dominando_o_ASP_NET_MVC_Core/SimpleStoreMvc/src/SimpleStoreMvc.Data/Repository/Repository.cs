using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using SimpleStoreMvc.Business.Interfaces;
using SimpleStoreMvc.Data.Context;
using System.Linq.Expressions;

namespace SimpleStoreMvc.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly SimpleStoreContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(SimpleStoreContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            var entity = new TEntity { Id = id };

            dbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
