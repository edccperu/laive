using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data.SqlClient;
using Laive.Core.Data;
using Laive.Entity.Di;
using System.Collections.Generic;
using Laive.Core.Common;

namespace Laive.DOQry.Di
{
   /// <summary>
   /// Data Object para Consultas a la Tabla: DI_Ruta (DI_Ruta)
   /// </summary>
   /// <remarks></remarks>
   public class Box : DataObjectBase, IDOQuery
   {

      #region IDOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         EBox objE = (EBox)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@pdsFilter", SqlDbType.VarChar, -1, objE.EntityFilter));

            ICollection<T> dt = this.ExecuteGetList<T>(typeof(T), "DI_Box_qry01", arrPrm);

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
         throw new NotImplementedException();
      }

      public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
      {
         throw new NotImplementedException();
      }

      public ICollection<T> GetList<T>(IEntityBase value) where T : new()
      {
         throw new NotImplementedException();
      }

      public bool Exists(IEntityBase value)
      {
         throw new NotImplementedException();
      }

      private ArrayList BuildParamInterface(EBox value)
      {

         ArrayList arrPrm = new ArrayList();

         arrPrm.Add(DataHelper.CreateParameter("@pidBox", SqlDbType.Int, value.IdBox));

         return arrPrm;

      }

      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         EBox objE = (EBox)value;

         try
         {

            ArrayList arrPrm = new ArrayList();

            arrPrm.Add(DataHelper.CreateParameter("@ptipoCarga", SqlDbType.Char, 1, objE.TipoCarga));

            ICollection<EntitySelect> dt = this.ExecuteGetList<EntitySelect>(typeof(EntitySelect), "DI_Box_qry06", arrPrm);

            return dt;

         }
         catch (Exception ex)
         {

            ServerObjectException objEx = (ServerObjectException)this.GetException(MethodBase.GetCurrentMethod(), ex);
            throw objEx;

         }
      }


      #endregion

   }
}
