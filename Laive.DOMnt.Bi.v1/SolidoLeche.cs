using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Bi;
using Laive.Entity.Sy;
using Laive.DOMnt.Sy;

namespace Laive.DOMnt.Bi
{
   /// <summary>
   /// Data Object para Mantenimiento a la Tabla: BI_SolidoLeche (BI_SolidoLeche)
   /// </summary>
   /// <remarks></remarks>
   public class SolidoLeche : DataObjectBase, IDOUpdate
   {

      #region IDOUpdate Members

      public object[] Insert(IEntityBase value)
      {

         ESolidoLeche objE = (ESolidoLeche)value;

         //----------- Generacion de Codigos ------------------
         //----------------------------------------------------
         ArrayList arrPrm = BuildParamInterface(objE);

         try
         {
            int intRes = this.ExecuteNonQuery("BI_SolidoLeche_mnt01", arrPrm);

            return new object[] { objE.CodigoSolidoLeche };

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Update(IEntityBase value)
      {

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            int intRes = this.ExecuteNonQuery("BI_SolidoLeche_mnt02", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      public int Delete(IEntityBase value)
      {

         ESolidoLeche objE = (ESolidoLeche)value;

         try
         {

            ArrayList arrPrm = new ArrayList();


            arrPrm.Add(DataHelper.CreateParameter("@pcodigoSolidoLeche", SqlDbType.Int, objE.CodigoSolidoLeche));

            int intRes = this.ExecuteNonQuery("BI_SolidoLeche_mnt03", arrPrm);

            return intRes;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }

      }

      private ArrayList BuildParamInterface(ESolidoLeche value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoSolidoLeche", SqlDbType.Int, value.CodigoSolidoLeche));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArticulo", SqlDbType.Char, 9, value.CodigoArticulo));
         arrPrm.Add(DataHelper.CreateParameter("@pcodigoArea", SqlDbType.Int, value.CodigoArea));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaIngreso", SqlDbType.DateTime, value.FechaIngreso));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaCaduca", SqlDbType.DateTime, (value.FechaCaduca.HasValue ? (object)value.FechaCaduca : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pslng", SqlDbType.Decimal, value.Slng));
         arrPrm.Add(DataHelper.CreateParameter("@pslg", SqlDbType.Decimal, value.Slg));
         arrPrm.Add(DataHelper.CreateParameter("@pssd", SqlDbType.Decimal, value.Ssd));
         arrPrm.Add(DataHelper.CreateParameter("@pslt", SqlDbType.Decimal, value.Slt));
         arrPrm.Add(DataHelper.CreateParameter("@psltDiluido", SqlDbType.Decimal, value.SltDiluido));
         arrPrm.Add(DataHelper.CreateParameter("@pfactorRendimiento", SqlDbType.Decimal, value.FactorRendimiento));
         arrPrm.Add(DataHelper.CreateParameter("@pestado", SqlDbType.Char, 1, value.Estado));
         arrPrm.Add(DataHelper.CreateParameter("@pidUserCreacion", SqlDbType.Char, 5, value.IdUserCreacion));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaCreacion", SqlDbType.DateTime, value.FechaCreacion));
         arrPrm.Add(DataHelper.CreateParameter("@pidUserModifica", SqlDbType.Char, 5, value.IdUserModifica));
         arrPrm.Add(DataHelper.CreateParameter("@pfechaModifica", SqlDbType.DateTime, (value.FechaModifica.HasValue ? (object)value.FechaModifica : DBNull.Value)));
         arrPrm.Add(DataHelper.CreateParameter("@pisCaducate", SqlDbType.Char,1, value.IsCaducate));

         return arrPrm;

      }

      #endregion

   }
}
