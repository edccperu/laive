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

namespace Laive.BOMnt.Fi
{
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   public class Cheque : BusinessObjectBase, IBOUpdate
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         ECheque objE = (ECheque)value;
         object[] objRet = null;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.ECheque, true);

               objRet = this.UpdateMaster(objE);
               //this.UpdateDetail(objE.ECheque, objRet);

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

         ECheque objE = (ECheque)value;

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               //this.DeleteDetail(objE.ECheque, false);
               this.DeleteMaster(objE);

               tx.Complete();

            }

            return 1;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      #endregion

      private object[] UpdateMaster(ECheque entity)
      {

         IDOUpdate objDO = new FIDOMnt.Cheque();

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

         return objRet;
      }

      private void DeleteMaster(ECheque entity)
      {

         IDOUpdate objDO = new FIDOMnt.Cheque();

         if (entity.EntityState == EntityState.Unchanged)
            return;

         objDO.Delete(entity);

      }

      public int ImportChequeBaan(IEntityBase value)
      {
         try
         {
            FIDOMnt.Cheque DO = new FIDOMnt.Cheque();

            int rsta = DO.ImportChequeBaan(value);

            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int ImportChequeInconsistente(IEntityBase value)
      {
         try
         {
            FIDOMnt.Cheque DO = new FIDOMnt.Cheque();

            int rsta = DO.ImportChequeInconsistente(value);

            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


      public int AsignarFirmante(IEntityBase value)
      {
         try
         {
            int rsta = 0;
            using (TransactionScope tx = new TransactionScope())
            {

               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.AsignarFirmante(value);
               tx.Complete();

            }
            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }


      }

      public int CambiarEstado(IEntityBase value)
      {
         try
         {
            int rsta = 0;
            using (TransactionScope tx = new TransactionScope())
            {

               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.CambiarEstado(value);
               tx.Complete();

            }
            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }


      }

      public int FirmarCheque(IEntityBase value)
      {
         try
         {
            int rsta = 0;
            using (TransactionScope tx = new TransactionScope())
            {

               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.FirmarCheque(value);
               tx.Complete();

            }
            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }


      }

      public int RechazarCheque(IEntityBase value)
      {
         try
         {
            int rsta = 0;
            using (TransactionScope tx = new TransactionScope())
            {

               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.RechazarCheque(value);
               tx.Complete();

            }
            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }


      }

      public int RevertirChequeFirmado(IEntityBase value)
      {
         try
         {
            int rsta = 0;
            using (TransactionScope tx = new TransactionScope())
            {

               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.RevertirChequeFirmado(value);
               tx.Complete();

            }
            return rsta;

         }
         catch (Exception ex)
         {

            throw ex;

         }


      }

       public int ImportarDetraccionCabArchivo(IEntityBase value)
      {
           try
           {
               int rsta = 0;
               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.ImportarDetraccionCabArchivo(value);
               return rsta;
           }
           catch (Exception ex)
           {

               throw ex;

           }

      }

        public int ImportarDetraccionDetArchivo(IEntityBase value)
       {

           try
           {
               int rsta = 0;
               FIDOMnt.Cheque DO = new FIDOMnt.Cheque();
               rsta = DO.ImportarDetraccionDetArchivo(value);
               return rsta;
           }
           catch (Exception ex)
           {

               throw ex;

           }
       }

   }
}
