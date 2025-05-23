using System;
using SamNet.Core.Data;
using System.Collections.Generic;
using SamNet.Core.Common;

namespace SamNet.Entity.Mg
{
    /// <summary>
    /// Entidad para la Tabla: MG_BienServicio (MG_BienServicio)
    /// </summary>
    public class EBienServicio : IEntityBase
    {
        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public string IdBien { get; set; }
        public string DsBien { get; set; }
        public string IdTipoBien { get; set; }
        public string DsTipoBien { get; set; }
        public string IdGrupo { get; set; }
        public string DsGrupo { get; set; }
        public string IdClase { get; set; }
        public string DsClase { get; set; }
        public string IdFamilia { get; set; }
        public string DsFamilia { get; set; }
        public string IdUniMedUso { get; set; }
        public string DsUniMedUso { get; set; }
        public string IdUniMedCompra { get; set; }
        public string DsUniMedCompra { get; set; }
        public decimal QtFactConv { get; set; }
        public string IdConfinanza { get; set; }
        public string StActivo { get; set; }
        public Nullable<decimal> MtPrecioRef { get; set; }
        public Nullable<DateTime> FechaRef { get; set; }
        public Nullable<decimal> MtPeso { get; set; }
        public Nullable<decimal> MtVolumen { get; set; }
        public string StEstadoMEF { get; set; }
        public string StAnulado { get; set; }
        public string IdUserTk { get; set; }
        public string IdPc { get; set; }
        public DateTime FeRegistro { get; set; }
                
    }
}
