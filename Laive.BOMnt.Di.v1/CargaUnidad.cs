using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using Laive.Core.Data;
using Laive.Entity.Di;
using Laive.Core.Common;
using DIDOMnt = Laive.DOMnt.Di;
using System.ServiceModel;
using System.IO;
using System.Xml;

namespace Laive.BOMnt.Di
{
   /// <summary>
   /// Interface para Consultas personalizadas
   /// </summary>
   [ServiceContract()]
   public interface ICargaUnidad
   {
      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int UpdateAddCamion(string idTrans, string idUnidad, DateTime fechaPrograma, int idRuta, decimal mtFrio, decimal mtSeco);

      /// <summary>
      /// Obtiene un registro por idLogon
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int UpdateTurnoBox(IEntityBase value);

      /// <summary>
      /// actualiza las facturas de cada CargaUnidadOperacion
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int UpdateFactura(IEntityBase value);

      /// <summary>
      /// Cambia un Partner a otro Camion
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int CambiarPartnerToCamion(List<ECargaUnidadChangePartner> listCargaUnidad);

      /// <summary>
      /// Cambia un Partner a otro Camion
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int CambiarCamion(int idCargaUnidad, int newIdCargaUnidad);

      /// <summary>
      /// Expide uno o varios Camiones
      /// </summary>
      /// <param name="value">Entidad base</param>
      /// <returns>Retorna un DataTable</returns>
      [OperationContract()]
      [NetDataContract()]
      int ExpedirCamion(string idCargaUnidad);

   }
   /// <summary>
   /// Business Object para Mantenimiento a la Tabla: DI_CargaUnidad (DI_CargaUnidad)
   /// </summary>
   public class CargaUnidad : BusinessObjectBase, IBOUpdate, ICargaUnidad
   {

      #region IBOUpdate Members

      public string[] UpdateData(IEntityBase value)
      {

         throw new NotImplementedException();
      }

      public int DeleteData(IEntityBase value)
      {

         throw new NotImplementedException();

      }

      #endregion

      public int UpdateAddCamion(string idTrans, string idUnidad, DateTime fechaPrograma, int idRuta, decimal mtFrio, decimal mtSeco)
      {
         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();
               result = objDO.UpdateAddCamion(idTrans, idUnidad, fechaPrograma, idRuta, mtFrio, mtSeco);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


      public int UpdateTurnoBox(IEntityBase value)
      {

         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();
               result = objDO.UpdateTurnoBox(value);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }
      }

      public int UpdateFactura(IEntityBase value)
      {

         int result;
         try
         {

            //using (TransactionScope tx = new TransactionScope())
            //{
            DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();
            result = objDO.UpdateFactura(value);
            //    tx.Complete();
            //}

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }
      }


      public ICollection<EDatosXml> GenerateXML(DateTime value,string rutaWMS,string rutaWMSBackup) 
      {

         DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();

         string filePath = rutaWMS;
         string filePathTest = string.Concat(rutaWMSBackup, value.ToString("yyyy_MM_dd"), "\\");
         

         //string filePath = "\\\\10.53.1.47\\interface_wms\\OV\\";
         //string filePathTest = string.Concat("\\\\10.53.1.47\\interface_wms\\OV\\TestOV\\", value.ToString("yyyy_MM_dd"), "\\");
         
         //string filePath= "\\\\TOSHIBA\\Fileserver\\OV\\";
         //string filePathTest = string.Concat("\\\\TOSHIBA\\Fileserver\\OV\\", value.ToString("yyyy_MM_dd"),"\\");
         
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               ICollection<EDatosXml> dt = objDO.GenerateXML(value);
               CreateZipFile(dt, filePath,filePathTest);

               tx.Complete();
               return dt;

            }

         }
         catch (Exception ex)
         {
            throw ex;
         }

      }

      private void CreateZipFile(ICollection<EDatosXml> eXml,string filePath, string filePathTest)
      {
         ICollection<EDatosXml> eXmlHeader = (from eHeader in eXml
                                              group eHeader by new
                                              {
                                                 eHeader.Orden,
                                                 eHeader.Sporden,
                                                 eHeader.CodigoPartner,
                                                 eHeader.ClavePartner,
                                                 eHeader.Turno,
                                                 eHeader.Locacion,
                                                 eHeader.Entidad,
                                                 eHeader.IdBox,
                                                 eHeader.CodigoBox,
                                                 eHeader.CodigoGrupo
                                              }
                                                 into grupo
                                                 select new EDatosXml
                                                 {
                                                    Orden = grupo.Key.Orden,
                                                    Sporden = grupo.Key.Sporden,
                                                    CodigoPartner = grupo.Key.CodigoPartner,
                                                    ClavePartner = grupo.Key.ClavePartner,
                                                    Turno = grupo.Key.Turno,
                                                    Locacion = grupo.Key.Locacion,
                                                    Entidad = grupo.Key.Entidad,
                                                    CodigoBox = grupo.Key.CodigoBox,
                                                    CodigoGrupo = grupo.Key.CodigoGrupo
                                                 }).ToList();

         MemoryStream zipStream = new MemoryStream();
      
         foreach (EDatosXml obje in eXmlHeader)
         {


            XmlDocument xmlDoc = new XmlDocument();
            XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "iso-8859-1", null);
            xmlDoc.AppendChild(declaration);

            XmlNode rootNode = xmlDoc.CreateElement("ProcessShipment");
            xmlDoc.AppendChild(rootNode);
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "xmlns", "http://schema.infor.com/InforOAGIS/2"));
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "releaseID", "9.2"));
            rootNode.Attributes.Append(CreateAttribute(xmlDoc, "versionID", "2.8.0"));

            /*ApplicationArea*/

            XmlNode apliArea = xmlDoc.CreateElement("ApplicationArea");
            XmlNode sender = xmlDoc.CreateElement("Sender");
            XmlNode logicalID = xmlDoc.CreateElement("LogicalID");
            logicalID.InnerText = "lid://infor.baan.conex-bann";
            sender.AppendChild(logicalID);
            XmlNode ComponentID = xmlDoc.CreateElement("ComponentID");
            ComponentID.InnerText = "erp";
            sender.AppendChild(ComponentID);
            XmlNode ConfirmationCode = xmlDoc.CreateElement("ConfirmationCode");
            ConfirmationCode.InnerText = "OnError";
            sender.AppendChild(ConfirmationCode);
            apliArea.AppendChild(sender);

            XmlNode CreationDateTime = xmlDoc.CreateElement("CreationDateTime");
            CreationDateTime.InnerText = DateTime.Now.ToString("yyyy-M-d HH:mm:ss");
            apliArea.AppendChild(CreationDateTime);

            XmlNode BODID = xmlDoc.CreateElement("BODID");
            BODID.InnerText = "infor-nid:INFOR:AE1:08:0000000007:1?Shipment&verb=Process";
            apliArea.AppendChild(BODID);

            rootNode.AppendChild(apliArea);

            /*DataArea*/

            XmlNode DataArea = xmlDoc.CreateElement("DataArea");
            XmlNode Process = xmlDoc.CreateElement("Process");

            XmlNode TenantID = xmlDoc.CreateElement("TenantID");
            TenantID.InnerText = "INFOR";
            Process.AppendChild(TenantID);

            XmlNode AccountingEntityID = xmlDoc.CreateElement("AccountingEntityID");
            AccountingEntityID.InnerText = "LAIVE";
            Process.AppendChild(AccountingEntityID);

            XmlNode LocationID = xmlDoc.CreateElement("LocationID");
            LocationID.InnerText = obje.Locacion.Trim();
            Process.AppendChild(LocationID);

            XmlNode ActionCriteria = xmlDoc.CreateElement("ActionCriteria");

            XmlNode ActionExpression = xmlDoc.CreateElement("ActionExpression");
            ActionExpression.Attributes.Append(CreateAttribute(xmlDoc, "actionCode", "Add"));
            ActionCriteria.AppendChild(ActionExpression);
            Process.AppendChild(ActionCriteria);
            DataArea.AppendChild(Process);

            XmlNode Shipment = xmlDoc.CreateElement("Shipment");

            XmlNode ShipmentHeader = xmlDoc.CreateElement("ShipmentHeader");
            XmlNode DocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode ID = xmlDoc.CreateElement("ID");
            ID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", "LAIVE"));
            ID.Attributes.Append(CreateAttribute(xmlDoc, "location", obje.Locacion.Trim()));
            ID.Attributes.Append(CreateAttribute(xmlDoc, "variationID", "1"));
            ID.InnerText = obje.Sporden;
            DocumentID.AppendChild(ID);
            ShipmentHeader.AppendChild(DocumentID);

            XmlNode Note = xmlDoc.CreateElement("Note");
            Note.InnerText = obje.Orden;
            ShipmentHeader.AppendChild(Note);
            XmlNode DockID = xmlDoc.CreateElement("DockID");
            DockID.InnerText = obje.CodigoBox;
            ShipmentHeader.AppendChild(DockID);

            XmlNode CarrierRouteReference = xmlDoc.CreateElement("CarrierRouteReference");
            XmlNode RouteStop = xmlDoc.CreateElement("RouteStop");
            XmlNode RouteStopID = xmlDoc.CreateElement("ID");
            RouteStopID.InnerText = obje.CodigoPartner;
            RouteStop.AppendChild(RouteStopID);
            CarrierRouteReference.AppendChild(RouteStop);
            ShipmentHeader.AppendChild(CarrierRouteReference);

            XmlNode DocumentReference = xmlDoc.CreateElement("DocumentReference");
            DocumentReference.Attributes.Append(CreateAttribute(xmlDoc, "type", "SalesOrder"));
            XmlNode DocRefDocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode DocRefDocumentIDID = xmlDoc.CreateElement("ID");
            DocRefDocumentIDID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", obje.ClavePartner.Trim()));
            DocRefDocumentIDID.Attributes.Append(CreateAttribute(xmlDoc, "location", obje.CodigoPartner));
            DocRefDocumentIDID.InnerText = obje.Turno;
            DocRefDocumentID.AppendChild(DocRefDocumentIDID);
            DocumentReference.AppendChild(DocRefDocumentID);
            ShipmentHeader.AppendChild(DocumentReference);

            XmlNode AlternateDocumentID = xmlDoc.CreateElement("AlternateDocumentID");
            XmlNode AlternateDocumentIDID = xmlDoc.CreateElement("ID");
            AlternateDocumentIDID.InnerText = obje.Sporden;
            AlternateDocumentID.AppendChild(AlternateDocumentIDID);
            ShipmentHeader.AppendChild(AlternateDocumentID);

            XmlNode DocumentDateTime = xmlDoc.CreateElement("DocumentDateTime");
            DocumentDateTime.InnerText = DateTime.Now.ToString("yyyy-M-d HH:mm:ss");
            ShipmentHeader.AppendChild(DocumentDateTime);

            XmlNode Status = xmlDoc.CreateElement("Status");
            XmlNode Code = xmlDoc.CreateElement("Code");
            Code.Attributes.Append(CreateAttribute(xmlDoc, "listID", "ShipmentStatus"));
            Code.InnerText = "Open";
            Status.AppendChild(Code);
            ShipmentHeader.AppendChild(Status);

            XmlNode WarehouseLocation = xmlDoc.CreateElement("WarehouseLocation");
            XmlNode WarehouseLocationID = xmlDoc.CreateElement("ID");
            WarehouseLocationID.InnerText = obje.Entidad.Trim();
            WarehouseLocation.AppendChild(WarehouseLocationID);
            XmlNode Name = xmlDoc.CreateElement("Name");
            Name.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
            Name.InnerText = "LAIVE";
            WarehouseLocation.AppendChild(Name);
            ShipmentHeader.AppendChild(WarehouseLocation);

            XmlNode ShipFromParty = xmlDoc.CreateElement("ShipFromParty");
            XmlNode Location = xmlDoc.CreateElement("Location");
            Location.Attributes.Append(CreateAttribute(xmlDoc, "type", "Warehouse"));
            XmlNode varLocationID = xmlDoc.CreateElement("ID");
            varLocationID.Attributes.Append(CreateAttribute(xmlDoc, "accountingEntity", obje.Locacion.Trim()));
            varLocationID.InnerText = obje.Entidad.Trim();
            Location.AppendChild(varLocationID);
            XmlNode LocationName = xmlDoc.CreateElement("Name");
            LocationName.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
            LocationName.InnerText = "LAIVE";
            Location.AppendChild(LocationName);
            ShipFromParty.AppendChild(Location);
            ShipmentHeader.AppendChild(ShipFromParty);

            XmlNode ShipToParty = xmlDoc.CreateElement("ShipToParty");
            XmlNode PartyIDs = xmlDoc.CreateElement("PartyIDs");
            XmlNode PartyIDsID = xmlDoc.CreateElement("ID");
            PartyIDsID.InnerText = obje.CodigoGrupo == null || obje.CodigoGrupo.Trim() == "" ? obje.CodigoPartner : obje.CodigoGrupo;
            PartyIDs.AppendChild(PartyIDsID);
            ShipToParty.AppendChild(PartyIDs);
            ShipmentHeader.AppendChild(ShipToParty);

            XmlNode varCarrierRouteReference = xmlDoc.CreateElement("CarrierRouteReference");
            XmlNode varDocumentID = xmlDoc.CreateElement("DocumentID");
            XmlNode varDocumentIDID = xmlDoc.CreateElement("ID");
            varDocumentIDID.InnerText = obje.Turno;
            varDocumentID.AppendChild(varDocumentIDID);
            varCarrierRouteReference.AppendChild(varDocumentID);
            ShipmentHeader.AppendChild(varCarrierRouteReference);

            XmlNode PartialShipmentAllowedIndicator = xmlDoc.CreateElement("PartialShipmentAllowedIndicator");
            PartialShipmentAllowedIndicator.InnerText = "true";
            ShipmentHeader.AppendChild(PartialShipmentAllowedIndicator);

            XmlNode PriorityCode = xmlDoc.CreateElement("PriorityCode");
            PriorityCode.InnerText = "5";
            ShipmentHeader.AppendChild(PriorityCode);
            Shipment.AppendChild(ShipmentHeader);

            ICollection<EDatosXml> eXmlDetails = eXml.Where(x => x.Sporden == obje.Sporden).ToList();

            foreach (EDatosXml objDet in eXmlDetails)
            {
               XmlNode ShipmentItem = xmlDoc.CreateElement("ShipmentItem");
               XmlNode ItemID = xmlDoc.CreateElement("ItemID");
               XmlNode ItemIDID = xmlDoc.CreateElement("ID");
               ItemIDID.InnerText = objDet.CodigoArticulo.Trim();
               ItemID.AppendChild(ItemIDID);
               ShipmentItem.AppendChild(ItemID);

               XmlNode ServiceIndicator = xmlDoc.CreateElement("ServiceIndicator");
               ServiceIndicator.InnerText = "false";
               ShipmentItem.AppendChild(ServiceIndicator);

               XmlNode Description = xmlDoc.CreateElement("Description");
               Description.Attributes.Append(CreateAttribute(xmlDoc, "languageID", "es-PE"));
               Description.InnerText = objDet.GlosaArticulo.Trim();
               ShipmentItem.AppendChild(Description);

               XmlNode OrderQuantity = xmlDoc.CreateElement("OrderQuantity");
               //Se comeneto por el correo de Elizabeth
               //OrderQuantity.Attributes.Append(CreateAttribute(xmlDoc, "unitCode", objDet.UnidadPedido.Trim()));
               OrderQuantity.InnerText = objDet.cantidadPedido.ToString().Trim().Replace(",", ".");
               ShipmentItem.AppendChild(OrderQuantity);

               XmlNode LineNumber = xmlDoc.CreateElement("LineNumber");
               LineNumber.InnerText = objDet.Linea.ToString();
               ShipmentItem.AppendChild(LineNumber);

               XmlNode HoldCodes = xmlDoc.CreateElement("HoldCodes");
               XmlNode HoldCodesCode = xmlDoc.CreateElement("Code");
               HoldCodesCode.Attributes.Append(CreateAttribute(xmlDoc, "listID", "Hold Reason Codes"));
               HoldCodes.AppendChild(HoldCodesCode);
               ShipmentItem.AppendChild(HoldCodes);
               Shipment.AppendChild(ShipmentItem);

            }

            DataArea.AppendChild(Shipment);
            rootNode.AppendChild(DataArea);
            xmlDoc.AppendChild(rootNode);

            if (!Directory.Exists(filePathTest))
            {
               Directory.CreateDirectory(filePathTest);
            }

            xmlDoc.Save(string.Concat(filePath, "SalesOrder", obje.Sporden, ".xml"));
            xmlDoc.Save(string.Concat(filePathTest, "SalesOrder", obje.Sporden, ".xml"));


            //Stream stream = new MemoryStream();
            //st.Position = 0;
            //xmlDoc.Save(stream);
            //xmlDoc.Save(string.Concat("\\\\10.53.1.7\\interface_wms\\OV\\SalesOrder", obje.Sporden, ".xml"));
            //xmlDoc.Save(string.Concat("\\\\10.53.1.7\\interface_wms\\OV\\TestOV\\SalesOrder", obje.Sporden, ".xml"));
            //stream.Flush();
            //stream.Position = 0;
            //zipfile.AddEntry(String.Concat("SalesOrder", obje.Sporden, ".xml"), stream);

         }

      }
      private XmlAttribute CreateAttribute(XmlDocument xmlDoc, string nodo, string value)
      {
         XmlAttribute attribute = xmlDoc.CreateAttribute(nodo);
         attribute.Value = value;
         return attribute;
      }

      public ICollection<T> ReGenerateXML<T>(DateTime fecha, int correlativo) where T : new()
      {

         DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();

         try
         {

            using (TransactionScope tx = new TransactionScope())
            {

               ICollection<T> dt = objDO.ReGenerateXML<T>(fecha, correlativo);

               tx.Complete();
               return dt;

            }

         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int CambiarPartnerToCamion(List<ECargaUnidadChangePartner> listCargaUnidad)
      {
         int result = 0;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();

               foreach (ECargaUnidadChangePartner eCargaUnidad in listCargaUnidad)
               {
                  result =+ objDO.CambiarPartnerToCamion(eCargaUnidad.IdCargaUnidad, eCargaUnidad.CodigoPartner, eCargaUnidad.NewIdCargaUnidad);
               }

               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

      public int CambiarCamion(int idCargaUnidad, int newIdCargaUnidad)
      {
         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();
               result = objDO.CambiarCamion(idCargaUnidad, newIdCargaUnidad);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }


      public int ExpedirCamion(string idCargaUnidad)
      {
         int result;
         try
         {

            using (TransactionScope tx = new TransactionScope())
            {
               DIDOMnt.CargaUnidad objDO = new DIDOMnt.CargaUnidad();
               result = objDO.ExpedirCamion(idCargaUnidad);
               tx.Complete();
            }

            return result;
         }
         catch (Exception ex)
         {

            throw ex;

         }

      }

   }
}
