using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SamNet.Core.Common
{
   public class GenerarXML
   {
      public DataTable GENARCHIVOFINAL(string pRutaXML, int pTipo, string pXmlRegenerar)
      {
         //preparaXML()

         AsignarDL pAsignarDL = new AsignarDL(strCadenaConexion);
         DataSet odt = new DataSet();
         DataTable dtCabecera = new DataTable();
         DataTable dtDetalle = new DataTable();
         string xml = "<ROOT>";
         object intro = null;
         object archivo = null;
         string ruta = pRutaXML;
         //"D:\Archivo\SalesOrder"
         string quitarRuta = ruta;
         string rutaTemp = "";
         string Dia = "0";
         string ORDEN = "";
         Dia = DateAndTime.Day(System.DateTime.Now);
         Dia = (Dia.Length == 1 ? "0" + Dia : Dia);
         try
         {
            if (pTipo == 1)
            {
               odt = pAsignarDL.GENARCHIVOFINAL();
               dtCabecera = odt.Tables[0];
               dtDetalle = odt.Tables[1];
            }
            else if (pTipo == 2)
            {
               odt = pAsignarDL.REGENARCHIVOFINAL(pXmlRegenerar);
               dtCabecera = odt.Tables[0];
               dtDetalle = odt.Tables[1];
            }
         }
         catch (Exception ex)
         {
         }


         if (dtCabecera.Rows.Count > 0)
         {
            foreach (DataRow item in dtCabecera.Rows)
            {
               string turno = "";
               string idCarga = "";
               string ordenVal = "0";
               int ValDetalle = 0;
               ruta = pRutaXML;
               ruta = string.Concat(ruta, item[1].ToString().Trim(), ".xml");
               turno = item[5].ToString().Trim() + "" + item[4].ToString().Trim();
               idCarga = item[5].ToString().Trim() + item[4].ToString().Trim() + item[2].ToString().Trim() + Dia;

               ORDEN = item[1].ToString().Trim();


               xml = pCabeceraXML(item[0].ToString().Trim(), item[1].ToString().Trim(), item[2].ToString().Trim(), turno, item[6].ToString().Trim(), item[7].ToString().Trim(), item[8].ToString().Trim(), idCarga, item[3].ToString().Trim(), item[10].ToString().Trim(),
               item[9].ToString().Trim());
               //item(14).ToString.Trim
               ordenVal = ORDEN;

               foreach (DataRow det in dtDetalle.Rows)
               {
                  if (item[0].ToString().Trim() == det[0].ToString().Trim())
                  {
                     xml = string.Concat(xml, "<ShipmentItem>");
                     xml = string.Concat(xml, "<ItemID>");
                     xml = string.Concat(xml, "<ID>", det[5].ToString().Trim(), "</ID> ");
                     xml = string.Concat(xml, "</ItemID>");
                     xml = string.Concat(xml, "<ServiceIndicator>false</ServiceIndicator>");
                     xml = string.Concat(xml, "<Description languageID=\"es-PE\">", det[11].ToString().Trim(), "</Description>");
                     xml = string.Concat(xml, "<OrderQuantity unitCode=\"KG\">", det[6].ToString().Trim().Replace(",", "."), "</OrderQuantity> ");
                     xml = string.Concat(xml, "<LineNumber>", det[7].ToString().Trim(), "</LineNumber>");
                     xml = string.Concat(xml, "<HoldCodes>");
                     xml = string.Concat(xml, "<Code listID=\"Hold Reason Codes\" />");
                     xml = string.Concat(xml, "</HoldCodes>");
                     xml = string.Concat(xml, "</ShipmentItem>");
                  }
               }

               xml = string.Concat(xml, "</Shipment>");
               xml = string.Concat(xml, "</DataArea>");
               xml = string.Concat(xml, "</ProcessShipment> ");
               //If VALIDAORDENES(ORDEN) Then
               try
               {
                  intro = Interaction.CreateObject("Scripting.FileSystemObject");
                  archivo = intro.CreateTextFile(ruta, false);
                  //, True
                  archivo.writeline(xml);
                  archivo.close();
               }
               catch (Exception ex)
               {
               }

               //ACTUALIZAORDENES(ORDEN)
               //Imprime archivo en ruta de pruebas - JV 28-10-2013
               intro = Interaction.CreateObject("Scripting.FileSystemObject");
               ruta = ruta.Replace("WMS_OV", "ov2");
               try
               {
                  archivo = intro.CreateTextFile(ruta, false);
                  archivo.writeline(xml);
                  archivo.close();
               }
               catch (Exception ex)
               {
               }

               //End If


            }

         }

         return odt.Tables[0];
      }
      private object pCabeceraXML(string pOrden, string spOrden, string pPartner, string pTurno, string pLocacion, string pEntidad, string pPuerta, string pRuta, string pPlaca, string pDescCli,
      string pGrupo)
      {
         string xml = "<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>";
         //"<?xml version=""1.0"" ?>  "
         xml = string.Concat(xml, "<ProcessShipment xmlns=\"http://schema.infor.com/InforOAGIS/2\" releaseID=\"9.2\" versionID=\"2.8.0\">");
         xml = string.Concat(xml, "<ApplicationArea>");
         xml = string.Concat(xml, "<Sender>");
         xml = string.Concat(xml, "<LogicalID>lid://infor.baan.conex-bann</LogicalID>");
         xml = string.Concat(xml, "<ComponentID>erp</ComponentID>");
         xml = string.Concat(xml, "<ConfirmationCode>OnError</ConfirmationCode>");
         xml = string.Concat(xml, "</Sender>");
         xml = string.Concat(xml, "<CreationDateTime>", System.DateTime.Now.ToString().Replace("/", "-"), "</CreationDateTime>");
         xml = string.Concat(xml, "<BODID>infor-nid:INFOR:AE1:08:0000000007:1?Shipment&verb=Process</BODID>");
         xml = string.Concat(xml, "</ApplicationArea>");
         xml = string.Concat(xml, "<DataArea>");
         xml = string.Concat(xml, "<Process>");
         xml = string.Concat(xml, "<TenantID>INFOR</TenantID>");
         xml = string.Concat(xml, "<AccountingEntityID>LAIVE</AccountingEntityID>");
         xml = string.Concat(xml, "<LocationID>", pLocacion, "</LocationID>");
         //"AE2"
         xml = string.Concat(xml, "<ActionCriteria>");
         xml = string.Concat(xml, "<ActionExpression actionCode=\"Add\" />");
         xml = string.Concat(xml, "</ActionCriteria>");
         xml = string.Concat(xml, "</Process>");
         xml = string.Concat(xml, "<Shipment>");
         xml = string.Concat(xml, "<ShipmentHeader>");
         xml = string.Concat(xml, "<DocumentID>");
         xml = string.Concat(xml, "<ID accountingEntity=\"LAIVE\" location=\"", pLocacion, "\" variationID=\"1\">", spOrden, "</ID> ");
         //"AE2"
         xml = string.Concat(xml, "</DocumentID>");
         xml = string.Concat(xml, "<Note>", pOrden, "</Note>");
         xml = string.Concat(xml, "<DockID>", pPuerta, "</DockID>");
         //pPuerta "1" -- MC
         //PRUEBAS DE PARADAS
         //xml = String.Concat(xml, "<CarrierRoute>")              'Parada
         //xml = String.Concat(xml, "<RouteStop>")                 'Parada
         //xml = String.Concat(xml, "<StopDetail>")                'Parada
         //xml = String.Concat(xml, "<ShipmentReference>")         'Parada
         //xml = String.Concat(xml, "<DocumentID>")                'Parada
         //xml = String.Concat(xml, "<ID accountingEntity=""LAIVE"" location=""", pLocacion, """ >") 'Parada
         //xml = String.Concat(xml, pOrden)                        'Parada
         //xml = String.Concat(xml, "</ID>")                       'Parada
         //xml = String.Concat(xml, "</DocumentID>")               'Parada
         //xml = String.Concat(xml, "</ShipmentReference>")        'Parada
         //xml = String.Concat(xml, "<StopID>", 1, "</StopID>")    'Parada
         //xml = String.Concat(xml, "</StopDetail>")               'Parada
         //xml = String.Concat(xml, "</RouteStop>")                'Parada
         //xml = String.Concat(xml, "</CarrierRoute>")             'Parada -- Comentado MC
         //PRUEBAS DE PARADAS
         xml = string.Concat(xml, "<CarrierRouteReference>");
         xml = string.Concat(xml, "<RouteStop>");
         xml = string.Concat(xml, "<ID>", pPartner, "</ID>");
         //"1"  pRuta ' pTurno
         xml = string.Concat(xml, "</RouteStop>");
         xml = string.Concat(xml, "</CarrierRouteReference>");
         xml = string.Concat(xml, "<DocumentReference type=\"SalesOrder\" > ");
         xml = string.Concat(xml, "<DocumentID>");
         xml = string.Concat(xml, "<ID accountingEntity=\"", pDescCli, "\" location=\"", pPartner, "\">", pTurno, "</ID>");
         //Nro de Remolque 'pPlaca

         xml = string.Concat(xml, "</DocumentID>");
         xml = string.Concat(xml, "</DocumentReference > ");
         xml = string.Concat(xml, "<AlternateDocumentID>");
         xml = string.Concat(xml, "<ID>", spOrden, "</ID>");
         xml = string.Concat(xml, "</AlternateDocumentID>");
         xml = string.Concat(xml, "<DocumentDateTime>", System.DateTime.Now.ToString().Replace("/", "-"), "</DocumentDateTime>");
         xml = string.Concat(xml, "<Status>");
         xml = string.Concat(xml, "<Code listID=\"ShipmentStatus\">Open</Code>");
         xml = string.Concat(xml, "</Status>");
         xml = string.Concat(xml, "<WarehouseLocation>");
         xml = string.Concat(xml, "<ID>", pEntidad, "</ID>");
         // "WHSE2"
         xml = string.Concat(xml, "<Name languageID=\"es-PE\">LAIVE</Name>");
         xml = string.Concat(xml, "</WarehouseLocation>");
         xml = string.Concat(xml, "<ShipFromParty>");
         xml = string.Concat(xml, "<Location type=\"Warehouse\">");
         xml = string.Concat(xml, "<ID accountingEntity=\"", pLocacion, "\">", pEntidad, "</ID> ");
         //"WHSE2"  "AE2"
         xml = string.Concat(xml, "<Name languageID=\"es-PE\">LAIVE</Name>");
         xml = string.Concat(xml, "</Location>");
         xml = string.Concat(xml, "</ShipFromParty>");
         xml = string.Concat(xml, "<ShipToParty>");
         xml = string.Concat(xml, "<PartyIDs>");
         xml = string.Concat(xml, "<ID>", pGrupo, "</ID>");
         //pPartner
         xml = string.Concat(xml, "</PartyIDs>");
         xml = string.Concat(xml, "</ShipToParty>");
         xml = string.Concat(xml, "<CarrierRouteReference>");
         xml = string.Concat(xml, "<DocumentID>");
         xml = string.Concat(xml, "<ID>", pTurno, "</ID>");
         // pTurno ' pRuta
         xml = string.Concat(xml, "</DocumentID>");
         xml = string.Concat(xml, "</CarrierRouteReference>");
         xml = string.Concat(xml, "<PartialShipmentAllowedIndicator>true</PartialShipmentAllowedIndicator> ");
         xml = string.Concat(xml, "<PriorityCode>5</PriorityCode>");
         xml = string.Concat(xml, "</ShipmentHeader>");
         return xml;
      }

   }
}
