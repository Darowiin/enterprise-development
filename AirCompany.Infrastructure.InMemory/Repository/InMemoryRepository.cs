using AirCompany.Domain;

namespace AirCompany.Infrastructure.InMemory.Repository;

/// <summary>
/// Generic in-memory repository that provides basic CRUD operations
/// for entities of type <typeparamref name="TEntity"/> with key type <typeparamref name="TKey"/>.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
/// <typeparam name="TKey">Type of entity primary key. Must be <see cref="int"/> for automatic ID generation.</typeparam>
public abstract class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
    where TKey : struct
{
    /// <summary>
    /// Internal list that stores all entities in memory.
    /// </summary>
    private readonly List<TEntity> _entities;

    /// <summary>
    /// Local ID generator for this repository type.
    /// </summary>
    private int _currentId;

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="entities">Shared list of entities.</param>
    protected InMemoryRepository(List<TEntity> entities)
    {
        _entities = entities ?? [];

        if (typeof(TKey) == typeof(int))
        {
            _currentId = _entities.Count != 0 ? _entities.Max(e => (int)(object)GetEntityId(e)) + 1 : 1;
        }
    }

    /// <summary>
    /// Creates a new entity and assigns a unique ID.
    /// </summary>
    /// <param name="entity">Entity to create.</param>
    public virtual Task<TEntity> Create(TEntity entity)
    {
        if (typeof(TKey) == typeof(int))
        {
            SetEntityId(entity, (TKey)(object)_currentId++);
        }

        _entities.Add(entity);

        return Task.FromResult(entity);
    }

    /// <summary>
    /// Returns an entity by its ID, or <see langword="null"/> if not found.
    /// </summary>
    /// <param name="entityId">Entity ID.</param>
    /// <returns>The entity if found; otherwise, <see langword="null"/>.</returns>
    public virtual Task<TEntity?> Get(TKey entityId) => Task.FromResult(_entities.FirstOrDefault(e => GetEntityId(e).Equals(entityId)));

    /// <summary>
    /// Returns all entities stored in memory.
    /// </summary>
    public virtual Task<IList<TEntity>> GetAll() => Task.FromResult<IList<TEntity>>([.. _entities]);

    /// <summary>
    /// Updates an existing entity by replacing it with the new version.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    public virtual Task<TEntity> Update(TEntity entity)
    {
        Delete(GetEntityId(entity));
        _entities.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Deletes an entity by its ID, if it exists.
    /// </summary>
    /// <param name="entityId">Entity ID.</param>
    public virtual Task<bool> Delete(TKey entityId)
    {
        var entity = Get(entityId).Result;
        if (entity != null)
        {
            _entities.Remove(entity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected abstract TKey GetEntityId(TEntity entity);

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected abstract void SetEntityId(TEntity entity, TKey id);
}