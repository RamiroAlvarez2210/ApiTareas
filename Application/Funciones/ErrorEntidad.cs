namespace Application.Funciones
{
    public static class ErrorEntidad
    {
        public static T BusquedaEntidad<T>(this T entity, string mensaje = null)
        {
            if (entity == null || (entity is int id && id == 0))
            {
                throw new KeyNotFoundException(mensaje ?? $"La entidad '{typeof(T).Name}' no existe.");
            }
            return entity;
        }
    }
}