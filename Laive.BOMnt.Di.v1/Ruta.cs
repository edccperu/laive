using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Core.Common;
using DIDOMnt = Laive.DOMnt.Di;
using Laive.Entity.Di;
using System.ServiceModel;

namespace Laive.BOMnt.Di
{
       /// <summary>
    /// Interface para Consultas personalizadas
    /// </summary>
   [ServiceContract()]
   public interface IRuta
   {
      [OperationContract()]
      [NetDataContract()]
      int UpdateRutaXPartner(string idPartner,int idRuta);
        
   }
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_Ruta (DI_Ruta)
   /// </summary>
   public class Ruta : BusinessObjectBase, IBOUpdate,IRuta
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.ERuta, true);

               objRet = this.UpdateMaster((ERuta)value);
               //this.UpdateDetail(objE.ERuta, objRet);

               tx.Complete();

            }

            if (objRet == null)
               return null;

            return new String[] { objRet[0].ToString() };

         }
         catch (Exception ex)
         {

            throw ex;

         }
      }

      public int DeleteData(IEntityBase value)
      {

         throw new NotImplementedException();

      }

      #endregion

      private object[] UpdateMaster(ERuta entity)
      {

         IDOUpdate objDO = new DIDOMnt.Ruta();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;

            case EntityState.Modified:
               if (entity.Activo == true)
                  objDO.Update(entity);
               else
                  objDO.Delete(entity);
               break;

            case EntityState.Deleted:
               objDO.Delete(entity);
               break;

         }

         return objRet;
      }

      public int UpdateRutaXPartner(string idPartner, int idRuta) {
         int rsta = 0;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               DIDOMnt.Ruta objDO = new DIDOMnt.Ruta();

               rsta = objDO.UpdateRutaXPartner(idPartner, idRuta);

               tx.Complete();

            }

            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }
      
      }
   }
}
