using Interfaces;

/**
 * Meant for onscreen enemies to fire
 */
public interface IShootable : IPersistable
    {
        void Fire();
    }