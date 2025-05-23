using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Fi;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Fi
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: FI_FirmantePc (FI_FirmantePc)
   /// </summary>
   /// <remarks></remarks>
   public class FirmantePc : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));
            arrPrm.Add(DataHelper.CreateParameter("@pnuSecuen", SqlDbType.Int, objE.NuSecuen));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_FirmantePc_qry01", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public IEntityBase GetByKey(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            DataTable dt = this.ExecuteDatatable("FI_FirmantePc_qry02", arrPrm);

            objE = null;

            foreach (DataRow dr in dt.Rows)
               objE = DataHelper.CopyDataRowToEntity<EFirmantePc>(dr, typeof(EFirmantePc));

            return objE;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_FirmantePc_qry03", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<T> GetList<T>(IEntityBase value) where T : new()
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "FI_FirmantePc_qry04", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {

            ArrayList arrPrm = BuildParamInterface(objE);

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "FI_FirmantePc_qry06", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      public bool Exists(IEntityBase value)
      {

         EFirmantePc objE = (EFirmantePc)value;

         try
         {


            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, objE.CodigoFirmante));
            arrPrm.Add(DataHelper.CreateParameter("@phostNameFirmante", SqlDbType.VarChar,50, objE.HostNameFirmante));
            arrPrm.Add(DataHelper.CreateParameter("@pipFirmante", SqlDbType.VarChar, 15, objE.IpFirmante));
            int intIdx = arrPrm.Add(DataHelper.CreateParameter("@pexists", SqlDbType.Char, 1, ParameterDirection.InputOutput, "0"));

            SqlParameter[] objPrm = (SqlParameter[])arrPrm.ToArray(typeof(SqlParameter));

            DataTable dt = this.ExecuteDatatable("FI_FirmantePc_qry05", arrPrm);

            return objPrm[intIdx].Value.ToString() == "1" ? true : false;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }

      private ArrayList BuildParamInterface(EFirmantePc value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pcodigoFirmante", SqlDbType.Char, 3, value.CodigoFirmante));
         arrPrm.Add(DataHelper.CreateParameter("@pnuSecuen", SqlDbType.Int, value.NuSecuen));

         return arrPrm;

      }

      #endregion

   }
}
