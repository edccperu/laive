using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;
using Laive.Core.Common;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Collections;

namespace Laive.Core.Data
{
    public class DataHelper
    {

        public static string GetConnectionString()
        {

            string strXmlFile = Path.Combine(ConfigFilePath, ConstSistema.CONFIGDATA);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(strXmlFile);
            XmlNode nod = xmlDoc.SelectSingleNode("/ConfigData/" + ConstConnection.NODO_CONEXION);
            if (nod == null)
            {
                return null;
            }

            string strSvr = "";
            string strDB = "";
            string strUsr = "";
            string strPsw = "";
            Cryptor objCryptor = new Cryptor();

            strSvr = Encoding.UTF8.GetString(objCryptor.Decrypt(Convert.FromBase64String(nod.Attributes["Server"].Value)));
            strDB = Encoding.UTF8.GetString(objCryptor.Decrypt(Convert.FromBase64String(nod.Attributes["Database"].Value)));
            strUsr = Encoding.UTF8.GetString(objCryptor.Decrypt(Convert.FromBase64String(nod.Attributes["User"].Value)));
            strPsw = Encoding.UTF8.GetString(objCryptor.Decrypt(Convert.FromBase64String(nod.Attributes["Password"].Value)));

            return GetConnectionString(strSvr, strDB, strUsr, strPsw);

        }

        public static string GetConnectionString(string serverName, string dataBase, string user, string password)
        {

            string strCS = "";

            if (string.IsNullOrEmpty(user.Trim()))
            {
                strCS = "Server = " + serverName + "; Database = " + dataBase + "; trusted_connection=yes";
            }
            else
            {
                strCS = "Server = " + serverName + "; Database = " + dataBase + "; User = " + user + "; Password = " + password + "";
            }

            return strCS;

        }

        public static SqlCommand GetSPCommand(SqlConnection connection, string spName)
        {

            SqlCommand cmmSP = new SqlCommand();

            {
                cmmSP.CommandType = CommandType.StoredProcedure;
                cmmSP.CommandText = spName;
                cmmSP.Connection = connection;
            }

            return cmmSP;

        }

        public static SqlParameter CreateParameter(string paramName, SqlDbType dataType, int dataSize, ParameterDirection paramDir, byte dataPrecision, byte dataScale, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType, dataSize);
            prmSP.Direction = paramDir;
            prmSP.Precision = dataPrecision;
            prmSP.Scale = dataScale;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static SqlParameter CreateParameter(string paramName, SqlDbType dataType, int dataSize, byte dataPrecision, byte dataScale, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType, dataSize);
            prmSP.Direction = ParameterDirection.Input;
            prmSP.Precision = dataPrecision;
            prmSP.Scale = dataScale;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static SqlParameter CreateParameter(string paramName, SqlDbType dataType, int dataSize, ParameterDirection paramDir, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType, dataSize);
            prmSP.Direction = paramDir;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static object CreateParameter(string paramName, SqlDbType dataType, ParameterDirection paramDir, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType);
            prmSP.Direction = paramDir;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static SqlParameter CreateParameter(string paramName, SqlDbType dataType, int dataSize, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType, dataSize);
            prmSP.Direction = ParameterDirection.Input;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static SqlParameter CreateParameter(string paramName, SqlDbType dataType, object dataValue)
        {

            SqlParameter prmSP = new SqlParameter(paramName, dataType);
            prmSP.Direction = ParameterDirection.Input;
            prmSP.Value = dataValue;

            return prmSP;
        }

        public static DataTable ExecuteDatatable(string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {

            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            cmm.CommandType = cmdType;

            if (sqlParams != null)
                cmm.Parameters.AddRange(sqlParams);

            DataTable dt = new DataTable(cmdText);
            SqlDataAdapter da = new SqlDataAdapter(cmm);

            cnn.Open();
            da.Fill(dt);
            cnn.Close();

            return dt;

        }

        public static string ExecuteString(string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {

            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            cmm.CommandType = cmdType;

            if (sqlParams != null)
                cmm.Parameters.AddRange(sqlParams);


            cnn.Open();
            SqlDataReader reader = cmm.ExecuteReader();
            cnn.Close();


            return "Filas afectadas : " + reader.RecordsAffected.ToString();

        }

        public static ICollection<T> ExecuteGetList<T>(Type entity, string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams) where T : new()
        {
            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            cmm.CommandType = cmdType;

            if (sqlParams != null)
                cmm.Parameters.AddRange(sqlParams);

            cnn.Open();
            IDataReader dr = cmm.ExecuteReader();

            ICollection<T> list = MapDataToBusinessEntityCollection<T>(dr);

            cnn.Close();

            return (ICollection<T>)list;
        }

        public static ICollection<T> ExecuteGetList<T>(Type entity, string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams, Int16 timeOut) where T : new()
        {
            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            cmm.CommandType = cmdType;

            if (timeOut > 0)
            {
                cmm.CommandTimeout = timeOut;
            }

            if (sqlParams != null)
                cmm.Parameters.AddRange(sqlParams);

            cnn.Open();
            IDataReader dr = cmm.ExecuteReader();

            ICollection<T> list = MapDataToBusinessEntityCollection<T>(dr);

            cnn.Close();

            return (ICollection<T>)list;
        }

        public static List<T> MapDataToBusinessEntityCollection<T>(IDataReader dr)   where T : new()
        {
            Type businessEntityType = typeof(T);
            List<T> entitys = new List<T>();
            Hashtable hashtable = new Hashtable();
            PropertyInfo[] properties = businessEntityType.GetProperties();
            foreach (PropertyInfo info in properties)
            {
                hashtable[info.Name.ToUpper()] = info;
            }
            while (dr.Read())
            {
                T newObject = new T();
                for (int index = 0; index < dr.FieldCount; index++)
                {
                    PropertyInfo info = (PropertyInfo)
                                        hashtable[dr.GetName(index).ToUpper()];
                    if ((info != null) && info.CanWrite && dr.GetValue(index) != DBNull.Value)
                    {
                        info.SetValue(newObject, dr.GetValue(index), null);
                    }
                }
                entitys.Add(newObject);
            }
            dr.Close();
            return entitys;
        }


        public static DataTable ExecuteDatatable(string connString, CommandType cmdType, string cmdText, int timeOut)
        {

            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);

            if (timeOut > 0)
            {
                cmm.CommandTimeout = timeOut;
            }

            cmm.CommandType = cmdType;
            DataTable dt = new DataTable(cmdText);
            SqlDataAdapter da = new SqlDataAdapter(cmm);

            cnn.Open();
            da.Fill(dt);
            cnn.Close();

            return dt;

        }

        public static object ExecuteScalar(string connection, CommandType commandType, string commandText, params SqlParameter[] sqlParams)
        {

            if ((connection == null))
                throw new ArgumentNullException("connection");

            // Create a command and prepare it for execution
            SqlCommand cmd = new SqlCommand();
            object retval = null;
            bool mustCloseConnection = false;

            SqlConnection cnn = new SqlConnection(connection);

            // If the provided connection is not open, we will open it
            if (cnn.State != ConnectionState.Open)
            {
                cnn.Open();
                mustCloseConnection = true;
            }
            else
            {
                mustCloseConnection = false;
            }

            // Associate the connection with the command
            cmd.Connection = cnn;

            // Set the command text (stored procedure name or SQL statement)
            cmd.CommandText = commandText;

            // Set the command type
            cmd.CommandType = commandType;

            //set the parameters
            cmd.Parameters.AddRange(sqlParams);


            // Execute the command & return the results
            retval = cmd.ExecuteScalar();

            // Detach the SqlParameters from the command object, so they can be used again
            cmd.Parameters.Clear();

            if ((mustCloseConnection))
                cnn.Close();

            return retval;

        }
        // ExecuteScalar

        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams)
        {

            int intRows = 0;

            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            cmm.CommandType = cmdType;
            cmm.Parameters.AddRange(sqlParams);
            cmm.CommandTimeout = 120;

            cnn.Open();
            intRows = cmm.ExecuteNonQuery();
            cnn.Close();

            return intRows;

        }

        public static int ExecuteNonQueryTimeOut(string connString, CommandType cmdType, string cmdText, SqlParameter[] sqlParams, Int16 timeOut)
        {

            int intRows = 0;

            SqlConnection cnn = new SqlConnection(connString);
            SqlCommand cmm = new SqlCommand(cmdText, cnn);
            if (timeOut > 0)
            {
                cmm.CommandTimeout = timeOut;
            }
            cmm.CommandType = cmdType;
            cmm.Parameters.AddRange(sqlParams);

            cnn.Open();
            intRows = cmm.ExecuteNonQuery();
            cnn.Close();

            return intRows;

        }

        public static T CopyDataRowToEntity<T>(DataRow data, Type entity)
        {
            T objType = (T)Activator.CreateInstance(entity);

            PropertyInfo[] arrProp = entity.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo pi in arrProp)
            {
                if (data.Table.Columns.Contains(pi.Name))
                {
                    object objDefVal = pi.GetValue(objType, null);
                    object objValue = ChangeType(data[pi.Name], pi.PropertyType, objDefVal);
                    pi.SetValue(objType, objValue, null);
                }
            }

            return objType;
        }

        public static string GetCamposUpdate<T>(T original, T change, Type entity)
        {
            string campos = "";

            //T objType = (T)Activator.CreateInstance(entity);

            PropertyInfo[] arrProp = entity.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo pi in arrProp)
            {
                if (pi.Name != "EntityState")
                {
                    if (pi.GetValue(original, null).GetType().Name == "Decimal")
                    {

                        if ((decimal)pi.GetValue(original, null) != (decimal)pi.GetValue(change, null))
                        {
                            campos = campos + (campos == "" ? "[" + pi.Name : " , [" + pi.Name) + ":" + pi.GetValue(original, null).ToString() + "->" + pi.GetValue(change, null).ToString() + "]";
                        }
                    }
                    else
                    {
                        if (pi.GetValue(original, null).ToString() != pi.GetValue(change, null).ToString())
                        {
                            campos = campos + (campos == "" ? "[" + pi.Name : " , [" + pi.Name) + ":" + pi.GetValue(original, null).ToString() + "->" + pi.GetValue(change, null).ToString() + "]";
                        }
                    }


                }

            }

            return campos;
        }

        public static object ChangeType(object value, Type conversionType, object defaultValue)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }
            // end if
            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // It's a nullable type, so instead of calling Convert.ChangeType directly which would throw a
                // InvalidCastException (per http://weblogs.asp.net/pjohnson/archive/2006/02/07/437631.aspx),
                // determine what the underlying type is
                // If it's null, it won't convert to the underlying type, but that's fine since nulls don't really
                // have a type--so just return null
                // Note: We only do this check if we're converting to a nullable type, since doing it outside
                // would diverge from Convert.ChangeType's behavior, which throws an InvalidCastException if
                // value is null and conversionType is a value type.
                if (value == null || object.ReferenceEquals(value, DBNull.Value))
                {
                    return null;
                }
                // end if
                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type

                NullableConverter nullableConverter = new NullableConverter(conversionType);

                //conversionType = Nullable.GetUnderlyingType(conversionType); 

                conversionType = nullableConverter.UnderlyingType;
            }
            // end if
            if (value == null || object.ReferenceEquals(value, DBNull.Value))
            {
                value = defaultValue;
            }

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }

        public static T CopyEntity<T>(object entity)
        {

            T objType = (T)Activator.CreateInstance(entity.GetType());

            PropertyInfo[] arrProp = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo pi in arrProp)
            {
                object objVal = pi.GetValue(entity, null);
                pi.SetValue(objType, objVal, null);
            }

            return objType;

        }

        private static string ConfigFilePath
        {
            get
            {
#if DEBUG
                return AppDomain.CurrentDomain.RelativeSearchPath.Replace("\\bin", "\\Config");
#else
			return AppHelper.DirectoryName;
#endif
            }
        }

        public static object IfNullString(string value)
        {
            if (value == null)
                return DBNull.Value;
            return value;

        }
        public static object IfNullString(int value)
        {

            return false;

        }
        // Retrieve data from the Excel spreadsheet.


        public static DataTable RetrieveSheetName(string strConn)
        {
            DataTable dtSchema = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {

                conn.Open();
                dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                conn.Close();

            }

            return dtSchema;
        }


        public static DataTable RetrieveData(string strConn, string sheetname)
        {
            DataTable dtExcel = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {

                if (sheetname == "")
                {
                    DataTable dtSchema = RetrieveSheetName(strConn);
                    sheetname = dtSchema.Rows[0]["TABLE_NAME"].ToString().Replace("'", "");
                }

                OleDbDataAdapter da = new OleDbDataAdapter("select * from [" + sheetname + "]", conn);

                da.Fill(dtExcel);
            }

            return dtExcel;
        }
    }
}
