using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Transactions;
using System.ServiceModel;
using Laive.Core.Data;
using FIDOQry = Laive.DOQry.Fi;
using System.Collections.Generic;
using Laive.Core.Common;
using Laive.Entity.Fi;

namespace Laive.BOQry.Fi
{
   /// <summary>
   /// Interfaz para Consultas a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   /// <remarks></remarks>
   [ServiceContract()]
   public interface ICheque
   {

      /// <summary>
      /// Obtiene Registros de los cheques con inconsistencia (Opcion Importacion del Menu)
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
          [OperationContract()]
          [NetDataContract()]
      ICollection<T> GetChequeInconsistente<T>(IEntityBase value) where T : new();

      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetChequeXAsignar(ECheque value);


      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetChequeEnvioEmail(ECheque value);
      
      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetChequeXFirmar(ECheque value);

      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetChequeFirmado(ECheque value, string Login);

      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetImprimirCheque(ECheque value);

      [OperationContract()]
      [NetDataContract()]
      ICollection<ECheque> GetConsultaChequeFirma(ECheque value);

      [OperationContract()]
      [NetDataContract()]
      IEntityBase GetFirmasFirmante(IEntityBase value);
   }

   /// <summary>
   /// Business Object para Consultas a la Tabla: FI_Cheque (FI_Cheque)
   /// </summary>
   public class Cheque : BusinessObjectBase, IBOQuery, ICheque


   {



      #region IBOQuery Members

      public ICollection<T> GetByCriteria<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            ICollection<T> dt = objData.GetByCriteria<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public IEntityBase GetByKey(IEntityBase value)
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            IEntityBase objE = objData.GetByKey(value);

            return objE;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetByParentKey<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            ICollection<T> dt = objData.GetByParentKey<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<T> GetList<T>(IEntityBase value) where T : new()
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            ICollection<T> dt = objData.GetList<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public bool Exists(IEntityBase value)
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            bool blnRes = objData.Exists(value);

            return blnRes;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }
      public ICollection<EntitySelect> GetListForSelect(IEntityBase value)
      {

         IDOQuery objData = (IDOQuery)new FIDOQry.Cheque();

         try
         {

            ICollection<EntitySelect> dt = objData.GetListForSelect(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      #endregion

      #region ICheque

      public ICollection<T> GetChequeInconsistente<T>(IEntityBase value) where T : new()
      {

         FIDOQry.Cheque objData = new FIDOQry.Cheque();

         try
         {

            ICollection<T> dt = objData.GetChequeInconsistente<T>(value);

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public ICollection<ECheque> GetConsultaChequeFirma(ECheque value)
      {
          FIDOQry.ChequeResumen objDataCR = new FIDOQry.ChequeResumen();
          FIDOQry.Cheque objData = new FIDOQry.Cheque();
          FIDOQry.ChequeComprobante objDataCP = new FIDOQry.ChequeComprobante();
          FIDOQry.ChequeVoucher objDataAC = new FIDOQry.ChequeVoucher();

          try
          {
              //cargra de registros resumen
              string strLogin = value.Login;
              ICollection<ECheque> dt = objDataCR.GetList<ECheque>(value);
              foreach (ECheque echeque in dt)
              {
                  //cheques
                  EChequeResumen echequeresumen = new EChequeResumen();
                  echequeresumen.FechaRegistro = echeque.FechaRegistro;
                  echequeresumen.Login = strLogin; // echeque.Login;
                  //cargar cheques
                  echeque.ListResumen = objData.GetConsultaChequeFirma<EChequeResumen>(echequeresumen);

                  ICollection<EChequeResumen> dtr = echeque.ListResumen;
                  foreach (EChequeResumen echeques in dtr)
                  {
                      
                 
                      //comprobantes
                      EChequeComprobante eComprob = new EChequeComprobante();
                      eComprob.IdCheque = echeques.IdCheque; // echequeresumen.IdCheque;
                      //voucher
                      EChequeVoucher eVoucher = new EChequeVoucher();
                      eVoucher.IdCheque = echeques.IdCheque; //echequeresumen.IdCheque;

                      // cargar comprobantes


                      echeques.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
                      echeque.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
                      // cargar vouchers
                      echeques.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);
                      echeque.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);
                  }

                  
              }
              return dt;
          }
          catch (Exception ex)
          {

              throw ex;

          }
      }

      public ICollection<ECheque> GetChequeXAsignar(ECheque value)
      {

         FIDOQry.Cheque objData = new FIDOQry.Cheque();
         FIDOQry.ChequeComprobante objDataCP = new FIDOQry.ChequeComprobante();
         FIDOQry.ChequeVoucher objDataAC = new FIDOQry.ChequeVoucher();

         try
         {

            ICollection<ECheque> dt = objData.GetByCriteria<ECheque>(value);

            foreach (ECheque echeque in dt)
            {
               EChequeComprobante eComprob = new EChequeComprobante();
               eComprob.IdCheque = echeque.IdCheque;
               EChequeVoucher eVoucher = new EChequeVoucher();
               eVoucher.IdCheque = echeque.IdCheque;

               echeque.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
               echeque.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);

            }

            return dt;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }
      public ICollection<ECheque> GetChequeEnvioEmail(ECheque value)
     
      {
          FIDOQry.Cheque objData = new FIDOQry.Cheque();
          try
          {

              ICollection<ECheque> dt = objData.GetChequeEnvioEmail<ECheque>(value);

              return dt;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }

     

      public ICollection<ECheque> GetChequeXFirmar(ECheque value)
      {

          FIDOQry.Cheque objData = new FIDOQry.Cheque();
          FIDOQry.ChequeComprobante objDataCP = new FIDOQry.ChequeComprobante();
          FIDOQry.ChequeVoucher objDataAC = new FIDOQry.ChequeVoucher();

          try
          {

              ICollection<ECheque> dt = objData.GetChequeXFirmar<ECheque>(value);

              foreach (ECheque echeque in dt)
              {
                  EChequeComprobante eComprob = new EChequeComprobante();
                  eComprob.IdCheque = echeque.IdCheque;
                  EChequeVoucher eVoucher = new EChequeVoucher();
                  eVoucher.IdCheque = echeque.IdCheque;

                  echeque.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
                  echeque.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);

              }

              return dt;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }

      public ICollection<ECheque> GetChequeFirmado(ECheque value,string Login)
      {

          FIDOQry.Cheque objData = new FIDOQry.Cheque();
          FIDOQry.ChequeComprobante objDataCP = new FIDOQry.ChequeComprobante();
          FIDOQry.ChequeVoucher objDataAC = new FIDOQry.ChequeVoucher();

          try
          {

              ICollection<ECheque> dt = objData.GetChequeFirmado<ECheque>(value,Login);

              foreach (ECheque echeque in dt)
              {
                  EChequeComprobante eComprob = new EChequeComprobante();
                  eComprob.IdCheque = echeque.IdCheque;
                  EChequeVoucher eVoucher = new EChequeVoucher();
                  eVoucher.IdCheque = echeque.IdCheque;

                  echeque.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
                  echeque.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);

              }

              return dt;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }
      
      public ICollection<ECheque> GetImprimirCheque(ECheque value)
      {

          FIDOQry.Cheque objData = new FIDOQry.Cheque();
          FIDOQry.ChequeComprobante objDataCP = new FIDOQry.ChequeComprobante();
          FIDOQry.ChequeVoucher objDataAC = new FIDOQry.ChequeVoucher();

          try
          {

              ICollection<ECheque> dt = objData.GetImprimirCheque<ECheque>(value);

              foreach (ECheque echeque in dt)
              {
                  EChequeComprobante eComprob = new EChequeComprobante();
                  eComprob.IdCheque = echeque.IdCheque;
                  EChequeVoucher eVoucher = new EChequeVoucher();
                  eVoucher.IdCheque = echeque.IdCheque;

                  echeque.ListComprobantes = objDataCP.GetList<EChequeComprobante>(eComprob);
                  echeque.ListVoucher = objDataAC.GetList<EChequeVoucher>(eVoucher);

              }

              return dt;

          }
          catch (Exception ex)
          {

              throw ex;

          }

      }


      public IEntityBase GetFirmasFirmante(IEntityBase value)
      {

         FIDOQry.Cheque objData = new FIDOQry.Cheque();

         try
         {

            IEntityBase objE = objData.GetFirmasFirmante(value);

            return objE;

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


      #endregion

   }
}
