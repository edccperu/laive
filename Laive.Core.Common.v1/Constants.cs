using System;

namespace Laive.Core.Common
{
   public class ConstSistema
   {
      public static readonly string CONFIGDATA = "ConfigData.xml";
      public static readonly string LOGO_WEBPAGE = "wfLogo.aspx?Filter=1";
      public static readonly string ROOT_FOLDER_PATH = "~/Reports";
      public static readonly string ROOT_IMAGES_PATH = "~/Images";
      public static readonly string OTHERFILES_PATH = "~/OtherFiles";
      public static readonly string ROOT_ENA_ICONS_PATH = ROOT_IMAGES_PATH + "/Icons/Enabled";
      public static readonly string ROOT_DIS_ICONS_PATH = ROOT_IMAGES_PATH + "/Icons/Disabled";
      public static readonly string SYS_NAME = "LAIVE.TI";
      public static readonly string APSET_AD_DOMAIN = "ActiveDirectoryDomain";
      public static readonly string APSET_AD_LDAP = "ActiveDirectoryLDAP";
      public static readonly string ROOT_UPLOADFOLDER_PATH = "~/UploadFiles";
   }

   public class ConstAuthenticationType
   {
      public static readonly string LDAP = "LdapAuthentication";
      public static readonly string FORM = "Forms";
   }

   public class ConstSeguridadGrupo
   {
      public static readonly string ADMINS = "G0001";
   }

   public class ConstSegTipoUsuario
   {
      public static readonly string GRUPO = "G";
      public static readonly string USUARIO = "U";
   }

   public class ConstQueryString
   {
      public static readonly string OPTION_FILTER = "optFilter";
   }


   public class ConstLotePagoEstado
   {

       public static readonly string NUEVO_CARGA = "1";
       public static readonly string ACTUALIZAR_PAGO = "2";
       public static readonly string GENERAR_PAGO_SUNAT = "3";
       public static readonly string CONCILIAR_PAGO = "4";
       public static readonly string NO_CONCILIADO = "5";
   }

   public class ConstSessionVar
   {
      public static readonly string LAST_ERR = "_LASTERR";
      public static readonly string PERIODO = "_PERIODO";
      public static readonly string USERLOGON = "_USERLOG";
      public static readonly string USERID = "_USERID";
      public static readonly string ISADM = "_ISADM";
      public static readonly string SEDEID = "_SEDEID";
      public static readonly string HOST_NAME = "REMOTE_HOST";
      public static readonly string REPORT_SOURCE = "_RPTSRC";
      public static readonly string UFILTER = "_FILTER";
      public static readonly string MESSAGE = "_MSG";
      public static readonly string IPCLIENT = "_IPCLIENT";
      public static readonly string NAMEPCCLIENT = "_NAMEPCCLIENT";
      public static readonly int TIMERSESSION = 20;

   }

   public class ConstFlagEstado
   {
      public static readonly string ACTIVADO = "1";
      public static readonly string DESACTIVADO = "0";
   }

   public class ConstEstadoUnidadCarga
   {
      public static readonly string PROGRAMADO = "001";
      public static readonly string CERRADO = "002";
      public static readonly string XML_GENERADO = "003";
      public static readonly string HISTORICO = "004";
   }

   public class ConstRowDeleted
   {
      public static readonly string ACTIVE = "0";
      public static readonly string DELETE = "1";
      public static readonly string LOCAL_DELETE = "2";
   }

   public class ConstDefaultValue
   {
      public static readonly string PERIODO = "0000";
      public static readonly string UNIDAD_EJECUTORA = "000001";
      public static readonly string UNIDAD_EJECUTORA_TEXT = "LAIVE";
      public static readonly string SEDE = "001";
      public static readonly string ROOTMENU = "_ROOT___";
      public static readonly string NOEXITCODE = "000";

   }

   public class ConstConnection
   {
      //public static readonly string NODO_CONEXION = "LOCAL";
      public static readonly string NODO_CONEXION = "CNX";
   }

   public class ConstGridRowCommand
   {
      public const string GRIDNEW = "CmdNew";
      public const string GRIDCOPY = "CmdCopy";
      public const string GRIDEDIT = "CmdEdit";
      public const string GRIDDELETE = "CmdDel";
      public const string GRIDPREVIEW = "CmdPrev";
      public const string GRIDCHECK = "CmdCheck";
      public const string GRIDDOWLOAD = "CmdDow";
   }

   public class ConstCustomFirstListItem
   {
      public const string ITEM_ALL = "(TODOS)";
      public const string ITEM_NONE = "(NINGUNO)";
      public const string ITEM_SELECT = "(SELECCIONE)";
   }

   public class ConstHTMLTagValue
   {
      public const string GRID_CELL_EMPTY = "&nbsp;";
   }

   //******************** Constantes ***********************************
   public class ConstMenuToolbarValue
   {
      public const string BUTTON_NEW = "_BTTNEW";
      public const string BUTTON_COPY = "_BTTCOPY";
      public const string BUTTON_EDIT = "_BTTEDIT";
      public const string BUTTON_DELETE = "_BTTDEL";
      public const string BUTTON_PREVIEW = "_BTTPREVI";
      public const string BUTTON_PRINT = "_BTTPRN";
      public const string BUTTON_SAVE = "_BTTSAVE";
      public const string BUTTON_SAVENEW = "_BTTSAVNEW";
      public const string BUTTON_SAVEOK = "_BTTSAVOK";
      public const string BUTTON_SAVEOBS = "_BTTSAVOBS";
      public const string BUTTON_EXIT = "_BTTEXIT";
      public const string BUTTON_EXPORT = "_BTTEXPO";
      public const string BUTTON_CALCULAR = "_BTTCALC";
   }

   public class ConstGridToolbarValue
   {
      public const string GRIDNEW = "_GRDNEW";
      public const string GRIDCOPY = "_GRDCOPY";
      public const string GRIDEDIT = "_GRDEDIT";
      public const string GRIDDELETE = "_GRDDEL";
   }

   public class ConstTipoAuditoria
   {
      public const string NEW = "001";
      public const string EDIT = "002";
      public const string DELETE = "003";
      public const string ERROR = "004";
   }

   public class ConstTipoMessage
   {
      public const string CORRECTO = "1";
      public const string ATENCION = "2";
      public const string ERROR = "3";
   }

   public class ConstTipoCarga
   {
      public const string FRIOS = "F";
      public const string SECOS = "S";
   }
   public class ConstTipoMovimiento
   {
      public const string SALDO = "S";
      public const string EGRESO = "E";
      public const string INGRESO = "I";
   }

   public class JsonMessageStatus
   {
      public static readonly string SUCCESS = "success";
      public static readonly string WARNING = "warning";
      public static readonly string INVALID = "invalid";
      public static readonly string INFORMATION = "information";
   }

   public class MsgAlertTypeConstant
   {
      public const string SUCCESS = "1";
      public const string INFORMATION = "2";
      public const string ERROR = "3";
   }
   
   public class ConstTipoOperacion
   {
      public const int Saldo_inicial = 0;
      public const int Orden_de_fabricacion = 1;
      public const int Orden_de_compra = 2;
      public const int Orden_de_venta = 3;
      public const int Orden_planificada_de_fabricacion = 4;
      public const int Orden_planificada_de_compra = 5;
      public const int Programa_de_compras = 6;
      public const int Programa_de_ventas = 7;
      public const int Previsión = 11;
      public const int Necesidades_prelim_de_materiales_MPS = 12;
      public const int Oferta_de_venta = 13;
      public const int Programa_de_compras_en_firme = 14;
      public const int Programa_de_ventas_en_firme = 15;
      public const int Correccion_Recuento_ciclico = 16;
      public const int Orden_de_servicio = 17;
      public const int Orden_de_compra_PRP_TP = 18;
      public const int Orden_de_almacenaje_PRP_TP = 19;
      public const int Orden_de_montaje = 21;
      public const int Orden_de_transferencia = 22;
      public const int Lote_de_fabricacion = 26;
      public const int Orden_planificada_de_distribucion = 30;
      public const int Demanda_de_pieza_de_montaje = 31;
      public const int Orden_fabricacion_manual = 32;
      public const int Orden_de_compra_manual = 33;
      public const int Orden_de_venta_manual = 34;
      public const int Orden_servicio_manual = 35;
      public const int Orden_de_transferencia_manual = 36;
      public const int Solicitud_de_oferta = 40;
      public const int Prevision_programa_de_ventas = 41;
   }

   public class ConstTipoTransferencia
   {
      public const int Saldo_inicial = 0;
      public const int Correccion_de_stock = 1;
      public const int Orden_de_compra = 3;
      public const int Recepcion_de_compra = 4;
      public const int Asignacion_de_ventas = 5;
      public const int Entrega_de_venta = 6;
      public const int Entrega_fabricacion = 7;
      public const int Recepcion_de_fabricacion = 8;
      public const int Costos_de_operacion = 9;
      public const int Costos_de_subcontratacion = 10;
      public const int Recargos_reales = 11;
      public const int Resultado_de_fabricacion = 12;
      public const int Resultado_de_compra = 13;
      public const int Resultado_de_lote = 14;
      public const int Revalorizacion = 15;
      public const int Transferir_recepcion = 16;
      public const int Transferir_entrega = 17;

   }
   //public class ConstAlcancePoder
   //{
   //   public static readonly string Cheque_compra_leche = "P01";
   //   public static readonly string Proveedores_max_300M_dolares = "P02";
   //   public static readonly string Proveedores_max_50M_soles = "P03";
   //}
   public class ConstEstadoCheque
   {
      public static readonly string CARGADO = "E01";
      public static readonly string ASIGANDO = "E02";
      public static readonly string VERIFICAR = "E03";
      public static readonly string ENVIADO = "E04";
      public static readonly string PRIMER_FIRMANTE = "E05";
      public static readonly string SEGUNDO_FIRMANTE = "E06";
      public static readonly string EXCLUIDO = "E07";
      public static readonly string IMPRESO = "E08";
      public static readonly string FIRMA_MANUAL = "E09";
      public static readonly string REVERTIR = "E10";
      public static readonly string RECHAZADO = "E11";
   }

   public class ConstTipoCheque
   {
       public static readonly string ELECTRONICO = "E";
       public static readonly string MANUAL = "M";
   }

   public class ConstCargoAbono
   {
      public static readonly string DEBE = "1";
      public static readonly string HABER = "2";
   }

   public class ConstConciliado
   {
       public static readonly string CONCILIADO = "4";
       public static readonly string ERROR = "5";
   }

   public class ConstParametroSistema
   {
       public static readonly int NOMBRE_IMPRESORA_CHEQUE = 1;
       public static readonly int RUTA_XML_DISTRIBUCION = 2;
       public static readonly int RUTA_XML_DISTRIBUCION_BACKUP = 3;
   }

}