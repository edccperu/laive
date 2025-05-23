using System;
using System.IO;
using Laive.Core.Data;
using Laive.Core.Common;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Laive.Core.Entity
{
   /// <summary>
   /// Entidad para la el resultado JSON para las Bandejas
   /// </summary>
   public class JsonSamNet
   {
      public int page { get; set; }
      public int total { get; set; }
      public List<Cell> rows { get; set; }

      public JsonSamNet()
      {
         page = 0;
         total = 0;
         List<Cell> rows = new List<Cell>();
      }

      public List<Cell> resultArray<T>(List<Column> columnset, ICollection<T> values)
      {
         return resultArray<T>(columnset, values, null);
      }


      public List<Cell> resultArray<T>(List<Column> columnset, ICollection<T> values, FlexigridParamSamNet Param)
      {

         if (Param != null)
         {
            if (Param.sortname != null)
               if (Param.sortorder == null || Param.sortorder == "asc")
                  values = values.OrderBy(a => a.GetType().GetProperty(Param.sortname).GetValue(a, null)).ToList();
               else
                  values = values.OrderByDescending(a => a.GetType().GetProperty(Param.sortname).GetValue(a, null)).ToList();
         }

         total = values.Count;
         List<Cell> rows = new List<Cell>();
         foreach (T element in values)
         {

            Cell cell = new Cell();
            cell.cell = new List<string>();
            foreach (Column column in columnset)
            {

               if (column.Name != null && column.Name != "" && element.GetType().GetProperty(column.Name).GetValue(element, null) != null)
               {
                  var value = element.GetType().GetProperty(column.Name).GetValue(element, null);

                  switch (Type.GetTypeCode(value.GetType()))
                  {
                     case TypeCode.Decimal:
                        if (column.HiddenCero && (decimal)value == 0)
                        {
                           cell.cell.Add("");
                           continue;
                        }

                        if (column.DecimalFormat != "")
                        {
                           cell.cell.Add(((decimal)value).ToString(column.DecimalFormat, CultureInfo.CreateSpecificCulture("en-US")));
                           continue;
                        }
                        else
                        {
                           cell.cell.Add(value.ToString());
                        }
                        break;
                     case TypeCode.DateTime:
                        if (((DateTime)value).Year > 1)
                        {
                           if (column.DecimalFormat != "")
                              cell.cell.Add(((DateTime)value).ToString(column.DecimalFormat));
                           else
                              cell.cell.Add(value.ToString());
                        }
                        else
                        {
                           cell.cell.Add("");
                        }
                        break;
                     default:
                        if (column.Name == "EntityState")
                        {
                           int entityState = (int)value;
                           cell.cell.Add(entityState.ToString());
                        }
                        else
                           cell.cell.Add(value.ToString());
                        break;
                  }

               }
               else
                  cell.cell.Add("");
            }
            rows.Add(cell);
         }

         return rows;
      }

   }

   public class Cell
   {
      public List<string> cell { get; set; }
   }

   public class JsonMessage
   {
      public string Status { get; set; }
      public string Url { get; set; }
      public string Message { get; set; }
      public object Data { get; set; }
   }

   public class JsonLaiveLib
   {

      public static string GetWhere(List<FilterOperator> filtros)
      {
         return GetWhere(filtros, true);
      }


      public static string GetWhere(List<FilterOperator> filtros, bool includeWhere)
      {

         if (filtros.Count == 0)
            return "";

         int countGroupWhere = 0;
         string pivotCampo = "";
         string where = includeWhere ? "WHERE " : "";
         string whereGroup = "";


         foreach (FilterOperator item in filtros)
         {
            if (pivotCampo != item.fcampo)
            {
               if (countGroupWhere != 0)
               {
                  where = string.Concat(where, "( ", whereGroup, " ) AND");
                  whereGroup = "";
               }
               whereGroup = string.Concat(item.fcampo, " ", getOperatorValue(item));
             
               countGroupWhere = 1;
               pivotCampo = item.fcampo;
            }
            else
            {
               whereGroup = string.Concat(whereGroup, " OR ", item.fcampo, " ", getOperatorValue(item));
               countGroupWhere++;
            }

         }

         if (countGroupWhere != 0)
         {
            where = string.Concat(where, "( ", whereGroup, " )");
         }

         return where;
      }



      private static string getOperatorValue(FilterOperator item) {

         string where = "";
         string valueArray = "(";

         switch (item.fconector)
         {
            case EnumConectorFilter.IN:
               foreach(string value in item.fvalueArray)
               {
                  valueArray = valueArray == "("? valueArray : string.Concat(valueArray,",");
                  valueArray = string.Concat(valueArray,"'",value,"'");
               }
               valueArray = string.Concat(valueArray,")");
               where = string.Concat("in ",valueArray);
               break;
            case EnumConectorFilter.CONTIENE:
               where = string.Concat("like ", "'%", item.fvalue, "%'");
               break;
            case EnumConectorFilter.MAYORIGUAL:
               int positions = item.fvalue.IndexOf("_");
               where = string.Concat(">= ", item.fvalue.Substring(0, positions), " And ", item.fcampo, " <= ", item.fvalue.Substring(positions + 1));
               break;
            case EnumConectorFilter.RANGO:
               int position = item.fvalue.IndexOf("_");
               where = string.Concat(">= ", "'", item.fvalue.Substring(0, position), "'" ," And ", item.fcampo," <= ", "'", item.fvalue.Substring(position + 1), "'");
               break;
            default:
               
               where = string.Concat(item.fconector, " '", item.fvalue,"'");
               break;
         }
         
         return where;
      }
   }
}
