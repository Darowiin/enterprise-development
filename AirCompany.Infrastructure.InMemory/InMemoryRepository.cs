namespace AirCompany.Infrastructure.InMemory;

/// <summary>
/// Generic in-memory repository that provides basic CRUD operations
/// for entities of type <typeparamref name="TEntity"/> with key type <see cref="int"/>.
/// </summary>
/// <typeparam name="TEntity">Entity type.</typeparam>
public abstract class InMemoryRepository<TEntity> : IRepository<TEntity, int>
    where TEntity : class
{
    /// <summary>
    /// Internal list that stores all entities in memory.
    /// </summary>
    private readonly List<TEntity> _entities;

    /// <summary>
    /// Local ID generator for this repository type.
    /// </summary>
    private int _currentId = 1;

    /// <summary>
    /// Initializes a new instance of the repository class.
    /// </summary>
    /// <param name="entities">Shared list of entities.</param>
    protected InMemoryRepository(List<TEntity> entities)
    {
        _entities = entities;
    }

    /// <summary>
    /// Creates a new entity and assigns a unique ID.
    /// </summary>
    /// <param name="entity">Entity to create.</param>
    public virtual void Create(TEntity entity)
    {
        SetEntityId(entity, _currentId++);
        _entities.Add(entity);
    }

    /// <summary>
    /// Returns an entity by its ID, or <see langword="null"/> if not found.
    /// </summary>
    /// <param name="entityId">Entity ID.</param>
    /// <returns>The entity if found; otherwise, <see langword="null"/>.</returns>
    public virtual TEntity? Get(int entityId)
    {
        return _entities.FirstOrDefault(e => GetEntityId(e) == entityId);
    }

    /// <summary>
    /// Returns all entities stored in memory.
    /// </summary>
    public virtual List<TEntity> GetAll() => _entities.ToList();

    /// <summary>
    /// Updates an existing entity by replacing it with the new version.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    public virtual void Update(TEntity entity)
    {
        Delete(GetEntityId(entity));
        _entities.Add(entity);
    }

    /// <summary>
    /// Deletes an entity by its ID, if it exists.
    /// </summary>
    /// <param name="entityId">Entity ID.</param>
    public virtual void Delete(int entityId)
    {
        var entity = Get(entityId);
        if (entity != null)
            _entities.Remove(entity);
    }

    /// <summary>
    /// Retrieves the entity's unique identifier.
    /// </summary>
    protected abstract int GetEntityId(TEntity entity);

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    protected abstract void SetEntityId(TEntity entity, int id);
}
