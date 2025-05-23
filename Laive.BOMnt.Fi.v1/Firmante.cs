using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Fi;
using Laive.Core.Common;
using FIDOMnt = Laive.DOMnt.Fi;
using System.ServiceModel;

namespace Laive.BOMnt.Fi
{

   [ServiceContract()]
   public interface IFirmante
   {
      /// <summary>
      /// Actualiza la imagen de la Firma del Firmante
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un int</returns>
      [OperationContract()]
      [NetDataContract()]
      int UpdateFirma(IEntityBase value);
   }



   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: FI_Firmante (FI_Firmante)
   /// </summary>
   public class Firmante : BusinessObjectBase, IBOUpdate, IFirmante
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         EFirmante objE = (EFirmante)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {


               objRet = this.UpdateMaster(objE);

               if (objRet == null)
                  this.UpdateDetail(objE.EFirmantePcList, objE.CodigoFirmante);
               else
                  this.UpdateDetail(objE.EFirmantePcList, objRet[0].ToString());

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

      private object[] UpdateMaster(EFirmante entity)
      {

         IDOUpdate objDO = new FIDOMnt.Firmante();

         if (entity.EntityState == EntityState.Unchanged)
            return null;

         object[] objRet = null;

         switch (entity.EntityState)
         {

            case EntityState.Added:
               objRet = objDO.Insert(entity);
               break;
            case EntityState.Modified:
               objDO.Update(entity);
               break;
            case EntityState.Deleted:
               objDO.Delete(entity);
               break;

         }


         //this.UpdateDetail(entity.ListaPoder, objRet);

         return objRet;
      }

      private void UpdateDetail(List<EFirmantePc> col, string codigoFirmante)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new FIDOMnt.FirmantePc();

         foreach (EFirmantePc objE in col)
         {
            objE.CodigoFirmante = codigoFirmante;

            switch (objE.EntityState)
            {

               case EntityState.Added:
                  objDO.Insert(objE);
                  break;

               case EntityState.Modified:
                  objDO.Update(objE);
                  break;

            }

         }

      }

      private void DeleteMaster(EFirmante entity)
      {

         IDOUpdate objDO = new FIDOMnt.Firmante();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      private void DeleteDetail(IList<EFirmante> col, bool filterModified)
      {

         if (col == null)
            return;

         IDOUpdate objDO = new FIDOMnt.Firmante();
         IEnumerable<EFirmante> colSel = null;

         if (filterModified)
         {
            var deleteItems = from itm in col
                              where itm.EntityState == EntityState.Deleted
                              select itm;

            colSel = (IEnumerable<EFirmante>)deleteItems;
         }
         else
         {
            var deleteItems = from itm in col
                              select itm;

            colSel = (IEnumerable<EFirmante>)deleteItems;
         }
         foreach (EFirmante objE in colSel)
            objDO.Delete(objE);

      }
      public int UpdateFirma(IEntityBase value)
      {
         int rtun;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               FIDOMnt.Firmante objDO = new FIDOMnt.Firmante();
               rtun = objDO.UpdateFirma(value);

               tx.Complete();

            }

            return rtun;

         }
         catch (Exception ex)
         {

            throw ex;

         }



      }
   }
}
