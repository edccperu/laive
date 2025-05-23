using System;
using Laive.Core.Data;


namespace Laive.Entity.Fi
{
    public class EDETipoOperacion : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string CodigoOperacion { get; set; }

        public string GlosaOperacion { get; set; }

    }
}
