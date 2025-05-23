using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Laive.Core.Common;
using System.Text.RegularExpressions;

namespace Laive.Core.Common
{
   public class FilterSearch
   {
      public string Create(List<FilterOperator> filterList, List<Column> columns)
      {
         if (filterList == null)
            return "";
         bool isfirstLine = true;
         string strcampo = "";
         string strfilter = "";

         List<FilterOperator> orderFilterList = filterList.OrderBy(elem => elem.fcampo).ToList();
         foreach (FilterOperator itemfilter in orderFilterList)
         {
            if (isfirstLine)
               strfilter = "(";
            else
               if (strcampo == itemfilter.fcampo)
                  strfilter = strfilter + "OR ";
               else
                  strfilter = strfilter + ") AND (";

            if (columns != null)
               strfilter = strfilter + GetColumnMap(columns, itemfilter.fcampo) + " ";
            else
               strfilter = strfilter + itemfilter.fcampo + " ";

            strfilter = strfilter + itemfilter.fconector + " ";
            strfilter = strfilter + (itemfilter.fconector == EnumConectorFilter.CONTIENE ? "'%" : "'");
            strfilter = strfilter + itemfilter.fvalue;
            strfilter = strfilter + (itemfilter.fconector == EnumConectorFilter.CONTIENE ? "%'" : "'") + " ";

            strcampo = itemfilter.fcampo;
            isfirstLine = false;
         }

         strfilter = "WHERE " + strfilter + ")";

         return strfilter;
      }

      public string GetColumnMap(List<Column> columns, string campo)
      {

         return (from c in columns
                 where c.Name == campo
                 select c.NameTable).First();

      }

   }

   public class FilterOperator
   {
      public string id { get; set; }
      public string fconector { get; set; }
      public string fcampo { get; set; }
      public string foperator { get; set; }
      public string fvalue { get; set; }
      public string fvaluefin { get; set; }
      public string[] fvalueArray { get; set; }
      public string fname { get; set; }
      public FilterOperator()
      { 
      }

      public FilterOperator(string varFcampo, string varFconector, string varFvalue)
      {
         fcampo = varFcampo;
         fconector = varFconector;
         fvalue = varFvalue;
      }

      public FilterOperator(string varFcampo, string varFconector, string[] varFvalue)
      {
         fcampo = varFcampo;
         fconector = varFconector;
         fvalueArray = varFvalue;
      }
   }

   public class FilterOperatorList
   {
      public List<FilterOperator> ListOperator { get; set; }
   }

   public class Column
   {
      public string Name { get; set; }
      public string Description { get; set; }
      public string Width { get; set; }
      public bool HiddenCero { get; set; }
      public string DecimalFormat { get; set; }
      public string NameTable { get; set; }

      public Column(string name)
      {
         Name = name;
         Description = "";
         Width = "";
         HiddenCero = false;
         DecimalFormat = "";
         NameTable = "";
      }

      public Column(string name, string nameTable)
      {
         Name = name;
         Description = "";
         Width = "";
         HiddenCero = false;
         DecimalFormat = "";
         NameTable = nameTable;
      }

      public Column(string name, string nameTable, bool hiddenCero)
      {
         Name = name;
         Description = "";
         Width = "";
         HiddenCero = hiddenCero;
         DecimalFormat = "";
         NameTable = nameTable;
      }

      public Column(string name, string nameTable, bool hiddenCero, string decimalFormat)
      {
         Name = name;
         Description = "";
         Width = "";
         HiddenCero = hiddenCero;
         DecimalFormat = decimalFormat;
         NameTable = nameTable;
      }

   }

   public class ColumnButton
   {
      public string icon { get; set; }
      public string onclick { get; set; }
      public string alt { get; set; }
      public ColumnButton(string sicon, string sonclick, string salt)
      {
         icon = sicon;
         onclick = sonclick;
         alt = salt;
      }
   }

   public class EntitySelect
   {
      public string value { get; set; }
      public string text { get; set; }
   }

   public static class LaiveFunctions{

      private static string[] UNIDADES = { "", "un ", "dos ", "tres ", "cuatro ", "cinco ", "seis ", "siete ", "ocho ", "nueve " };
      private static string[] DECENAS = {"diez ", "once ", "doce ", "trece ", "catorce ", "quince ", "dieciseis ",
        "diecisiete ", "dieciocho ", "diecinueve", "veinte ", "treinta ", "cuarenta ",
        "cincuenta ", "sesenta ", "setenta ", "ochenta ", "noventa "};
      private static string[] CENTENAS = {"", "ciento ", "doscientos ", "trecientos ", "cuatrocientos ", "quinientos ", "seiscientos ",
        "setecientos ", "ochocientos ", "novecientos "};
      private static Regex r;

      public static string GetColorXEstadoCheque(string estado)
      {
         string color = "";

         switch (estado)
         {
            case "E01":
               color = "#71BD71";
               break;
            case "E02":
               color = "#008BD7";
               break;
            case "E03":
               color = "#FFFC00";
               break;
            case "E04":
               color = "#1C92B5";
               break;
            case "E05":
               color = "#FF962F";
               break;
            case "E06":
               color = "#FF962F";
               break;
            case "E07":
               color = "#FC5353";
               break;
            case "E08":
               color = "#085FD2";
               break;
            case "E09":
               color = "#4AABE8";
               break;
            case "E10":
               color = "#8F219C";
               break;
             case "E11":
               color = "#FC5353";
               break;
             default:
               color = "#6ABDB7";
               break;
         }

         return color;
      }

      public static string NumeroToLetras(decimal value,bool mayusculas) { 
       
        string literal = "";
        string parte_decimal;
        //si el numero utiliza (.) en lugar de (,) -> se reemplaza
        string numero = value.ToString().Replace(".", ",");

        //si el numero no tiene parte decimal, se le agrega ,00
        if (numero.IndexOf(",") == -1)
        {
           numero = numero + ",00";
        }
        //se valida formato de entrada -> 0,00 y 999 999 999,00
        r = new Regex(@"\d{1,9},\d{1,2}");

        MatchCollection mc = r.Matches(numero);
        if (mc.Count > 0)
        {
           //se divide el numero 0000000,00 -> entero y decimal
           string[] Num = numero.Split(',');

           //de da formato al numero decimal
           parte_decimal = "CON_" + Num[1] + "/100 SOLES";
           //se convierte el numero a literal
           if (int.Parse(Num[0]) == 0)
           {//si el valor es cero                
              literal = "cero ";
           }
           else if (int.Parse(Num[0]) > 999999)
           {//si es millon
              literal = getMillones(Num[0]);
           }
           else if (int.Parse(Num[0]) > 999)
           {//si es miles
              literal = getMiles(Num[0]);
           }
           else if (int.Parse(Num[0]) > 99)
           {//si es centena
              literal = getCentenas(Num[0]);
           }
           else if (int.Parse(Num[0]) > 9)
           {//si es decena
              literal = getDecenas(Num[0]);
           }
           else
           {//sino unidades -> 9
              literal = getUnidades(Num[0]);
           }
           //devuelve el resultado en mayusculas o minusculas
           if (mayusculas)
           {
              return (literal + parte_decimal).ToUpper();
           }
           else
           {
              return (literal + parte_decimal);
           }
        }
        else
        {//error, no se puede convertir
           return literal = null;
        }
      
      }

      private static string getUnidades(string numero)
      {   // 1 - 9            
         //si tuviera algun 0 antes se lo quita -> 09 = 9 o 009=9
         string num = numero.Substring(numero.Length - 1);
         return UNIDADES[int.Parse(num)];
      }

      private static string getDecenas(string num)
      {// 99                        
         int n = int.Parse(num);
         if (n < 10)
         {//para casos como -> 01 - 09
            return getUnidades(num);
         }
         else if (n > 19)
         {//para 20...99
            string u = getUnidades(num);
            if (u.Equals(""))
            { //para 20,30,40,50,60,70,80,90
               return DECENAS[int.Parse(num.Substring(0, 1)) + 8];
            }
            else
            {
               return DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
            }
         }
         else
         {//numeros entre 11 y 19
            return DECENAS[n - 10];
         }
      }

      private static string getCentenas(string num)
      {// 999 o 099
         if (int.Parse(num) > 99)
         {//es centena
            if (int.Parse(num) == 100)
            {//caso especial
               return " cien ";
            }
            else
            {
               return CENTENAS[int.Parse(num.Substring(0, 1))] + getDecenas(num.Substring(1));
            }
         }
         else
         {//por Ej. 099 
            //se quita el 0 antes de convertir a decenas
            return getDecenas(int.Parse(num) + "");
         }
      }

      private static string getMiles(string numero)
      {// 999 999
         //obtiene las centenas
         string c = numero.Substring(numero.Length - 3);
         //obtiene los miles
         string m = numero.Substring(0, numero.Length - 3);
         string n = "";
         //se comprueba que miles tenga valor entero
         if (int.Parse(m) > 0)
         {
            n = getCentenas(m);
            return n + "mil " + getCentenas(c);
         }
         else
         {
            return "" + getCentenas(c);
         }

      }

      private static string getMillones(string numero)
      { //000 000 000        
         //se obtiene los miles
         string miles = numero.Substring(numero.Length - 6);
         //se obtiene los millones
         string millon = numero.Substring(0, numero.Length - 6);
         string n = "";
         if (millon.Length > 1)
         {
            n = getCentenas(millon) + "millones ";
         }
         else
         {
            n = getUnidades(millon) + "millon ";
         }
         return n + getMiles(miles);
      }




   }

}
