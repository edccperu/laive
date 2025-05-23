using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    public class EDEPorcentaje: IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string CodigoPorcDetraccion { get; set; }
        public decimal PorcDetraccion { get; set; }
    }
}
