using System;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Laive.Core;
using System.Collections.Generic;

namespace Laive.Core.Data
{
/// <summary>
/// Clase base para los Data Objects
/// </summary>
/// <remarks></remarks>
public class DataObjectBase : ServerObject
{

	public Exception GetException(MethodBase method, Exception ex)
	{
		return this.GetException("DataObject", method, ex);
	}

	public DataTable ExecuteDatatable(string cmdText, ArrayList paramList)
	{

		SqlParameter[] objPrm = null;

		if ((paramList != null))
			objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

		DataTable dt = DataHelper.ExecuteDatatable(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, objPrm);

		return dt;

	}

    public string ExecuteString(string cmdText, ArrayList paramList)
    {

        SqlParameter[] objPrm = null;

        if ((paramList != null))
            objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

        string dt = DataHelper.ExecuteString(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, objPrm);

        return dt;

    }

    public ICollection<T> ExecuteGetList<T>(Type entity, string cmdText, ArrayList paramList) where T : new()
    {
        SqlParameter[] objPrm = null;

        if ((paramList != null))
            objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

        ICollection<T> dt = DataHelper.ExecuteGetList<T>(entity, this.GetConnectionString(), CommandType.StoredProcedure, cmdText, objPrm);

        return dt;

    }

    public ICollection<T> ExecuteGetList<T>(Type entity, string cmdText, ArrayList paramList,Int16 timeout) where T : new()
    {
        SqlParameter[] objPrm = null;

        if ((paramList != null))
            objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

        ICollection<T> dt = DataHelper.ExecuteGetList<T>(entity, this.GetConnectionString(), CommandType.StoredProcedure, cmdText, objPrm, timeout);

        return dt;

    }

	public DataTable ExecuteDatatable(string cmdText, Int16 timeOut)
	{

		DataTable dt = DataHelper.ExecuteDatatable(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, timeOut);

		return dt;

	}

	public int ExecuteNonQuery(string cmdText, ArrayList paramList)
	{

		SqlParameter[] objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

		int intRet = this.ExecuteNonQuery(cmdText, objPrm);

		return intRet;
	}

    public int ExecuteNonQueryTimeOut(string cmdText, ArrayList paramList, Int16 timeOut)
    {

        SqlParameter[] objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

        int intRet = this.ExecuteNonQueryTimeOut(cmdText, objPrm, timeOut);

        return intRet;
    }


	public int ExecuteNonQuery(string cmdText, SqlParameter[] paramList)
	{

		int intRet = DataHelper.ExecuteNonQuery(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, paramList);

		return intRet;

	}

    public int ExecuteNonQueryTimeOut(string cmdText, SqlParameter[] paramList, Int16 timeOut)
    {

        int intRet = DataHelper.ExecuteNonQueryTimeOut(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, paramList,timeOut);

        return intRet;

    }

	private string GetConnectionString()
	{

		return DataHelper.GetConnectionString();

	}

	public object ExecuteScalar(string cmdText, ArrayList paramList)
	{

		SqlParameter[] objPrm = (SqlParameter[])paramList.ToArray(typeof(SqlParameter));

		object obj = DataHelper.ExecuteScalar(this.GetConnectionString(), CommandType.StoredProcedure, cmdText, objPrm);

		return obj;

	}

	private string ConfigFilePath {
		get
      {
#if DEBUG
         return AppDomain.CurrentDomain.RelativeSearchPath.Replace("\\bin", "\\Config");
#else
			return AppHelper.DirectoryName;
#endif
		}
	}

}}
