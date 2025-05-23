using System;

namespace Laive.Core.Data
{
    /// <summary>
    /// Interface general para los Data Object que realizan mantenimientos a Tablas
    /// </summary>
    public interface IDOUpdate
    {
        /// <summary>
        /// Metodo general para Agregar Datos
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns></returns>
        object[] Insert(IEntityBase value);

        /// <summary>
        /// Metodo general para Actualizar Datos
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns></returns>
        int Update(IEntityBase value);

        /// <summary>
        /// Metodo general para Eliminar o Anular Datos
        /// </summary>
        /// <param name="value">Entidad base</param>
        /// <returns></returns>
        int Delete(IEntityBase value);
    }
}
