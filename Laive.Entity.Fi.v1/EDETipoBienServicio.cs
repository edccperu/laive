using System;
using Laive.Core.Data;

namespace Laive.Entity.Fi
{
    public class EDETipoBienServicio : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }

        public string CodigoBienServicio { get; set; }
        public string GlosaBienServicio { get; set; }
    }

}
