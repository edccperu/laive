using System;
using System.Runtime.Serialization;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;

namespace Laive.Entity.Di
{
	/// <summary>
	/// Entidad para la Tabla: CO_PedidoConsolidado (CO_PedidoConsolidado)
	/// </summary>
	public class EPedidoConsolidado: IEntityBase
	{
		#region Campos

        public EntityState EntityState { get; set; }
        public string EntityFilter { get; set; }
        public int IdRuta { get; set; }
        public int IdCargaUnidad { get; set; }
        public string CodigoPartner { get; set; }
        public string GlosaPartner { get; set; }
        public decimal PaletaFrios { get; set; }
        public decimal PesoFrios { get; set; }
        public decimal ImporteFrios { get; set; }
        public decimal PaletaSecos { get; set; }
        public decimal PesoSecos { get; set; }
        public decimal ImporteSecos { get; set; }
        public int StPcf { get; set; }
        public int StPcs { get; set; }
        public string IdUserTkCarga { get; set; }
        public string Dpto { get; set; }

        public string CodigoDpto { get; set; }
        public string GlosaDpto { get; set; }
        public string CodigoProv { get; set; }
        public string GlosaProv { get; set; }
        public string CodigoUbigeo { get; set; }
        public string GlosaDist { get; set; }

        public string CodigoCanalBaan { get; set; }
        public string GlosaCanalBaan { get; set; }

		#endregion

        public List<Column> ColumnSet()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdRuta"));
            columnSet.Add(new Column("CodigoPartner"));
            columnSet.Add(new Column("GlosaPartner"));
            columnSet.Add(new Column("StPcf"));
            columnSet.Add(new Column("PaletaFrios", "", false, "N2"));
            columnSet.Add(new Column("PesoFrios", "", false, "N4"));
            columnSet.Add(new Column("ImporteFrios", "", false, "N2"));
            columnSet.Add(new Column("StPcs"));
            columnSet.Add(new Column("PaletaSecos", "", false, "N2"));
            columnSet.Add(new Column("PesoSecos", "", false, "N4"));
            columnSet.Add(new Column("ImporteSecos", "", false, "N2"));
            columnSet.Add(new Column("CodigoDpto"));
            columnSet.Add(new Column("GlosaDpto"));
            columnSet.Add(new Column("CodigoProv"));
            columnSet.Add(new Column("GlosaProv"));
            columnSet.Add(new Column("CodigoUbigeo"));
            columnSet.Add(new Column("GlosaDist"));
            columnSet.Add(new Column("CodigoCanalBaan"));
            columnSet.Add(new Column("GlosaCanalBaan"));
            //columnSet.Add(new Column("CodigoCanalComercialN1"));
            //columnSet.Add(new Column("GlosaCanalComercialN1"));
            //columnSet.Add(new Column("CodigoCanalComercialN2"));
            //columnSet.Add(new Column("GlosaCanalComercialN2"));
           
            return columnSet;
        }

        public List<Column> ColumnSetForCamionConsolidado()
        {
            List<Column> columnSet = new List<Column>();
            columnSet.Add(new Column("IdRuta"));
            columnSet.Add(new Column("CodigoPartner"));
            columnSet.Add(new Column("GlosaPartner"));
            columnSet.Add(new Column("PaletaFrios", "", false, "N2"));
            columnSet.Add(new Column("PesoFrios", "", false, "N4"));
            columnSet.Add(new Column("ImporteFrios", "", false, "N2"));
            columnSet.Add(new Column("PaletaSecos", "", false, "N2"));
            columnSet.Add(new Column("PesoSecos", "", false, "N4"));
            columnSet.Add(new Column("ImporteSecos", "", false, "N2"));
            columnSet.Add(new Column("IdCargaUnidad"));
            return columnSet;
        }

	}
}
