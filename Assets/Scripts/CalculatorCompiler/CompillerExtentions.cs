/**********************************************
 *  This software was developed by :
 *  
 *  Júlio José de Andrade Reis
 *  Email: julioreisdev@outlook.com 
 * 
 * OpenSource
 **********************************************/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Assets.Scripts.CalculatorCompiler
{
  internal  static class CompillerExtentions
  {

       private static readonly char[] Operators = CalcCompiller.SuportedOperators;
         
        /// <summary>
         /// Extrai numeros dentro de uma string 
         /// </summary>
         /// <param name="source">a Equaccao</param>
         /// <returns></returns>
        internal static double[] ExtractNumbers(this string source)
        {
            try
            {
                var nums = source.Split(Operators.ToArray());
                var values = new double[nums.Length];
                for (var i = 0; i < values.Length; i++)
                {
                    var st = 0.0;
                    double.TryParse(nums[i], out  st);
                    values[i] = st;
                }
                return values;
            }
            catch (Exception)
            {
                return new double[] { };
            }
      }
        /// <summary>
        /// Extrai numeros dentro de uma string 
        /// </summary>
        /// <param name="source"> a equacao</param>
        /// <param name="op"> Operadores entre os numeros</param>
        /// <returns></returns>
        internal static double[] ExtractNumbers(this string source, char[] op)
        {
          try
          {
              var nums = source.Split(op);
              var values = new double[nums.Length];
              for (var i = 0; i < values.Length; i++)
              {
                  var st = 0.0;
                  double.TryParse(nums[i],out st);
                  values[i] = st;
              }
              return values;
          }
          catch (Exception)
          {
              return new double[]{};
           
          }
      }

      /// <summary>
      /// extrai os operadores dentro de um conjunto de caracters string
      /// </summary>
      /// <param name="source"></param>
      /// <returns></returns>
      internal  static char[] ExtractOperators(this string source)
        {

           
               var list = source.ToCharArray();
               return  list.Where(Operators.Contains).ToArray();
           
            
        }
      internal static char[] ExtractOperators(this string source,char[] op)
      {
          var list = source.ToCharArray();
          return list.Where(op.Contains).ToArray();

      }
        /// <summary>
        /// Calcula e retorna o resultado
        /// </summary>
        /// <param name="sources">Numeros da equação</param>
        /// <returns></returns>
      internal static double Compute(string sources)
        {
            var m = new EnumerableMensure();
            var tempOperadores = new List<char>();
            var tempNums = new List<double>();
            var usedsId = new List<int>();
            var source = sources.ExtractNumbers();
            var oprs = sources.ExtractOperators();

            if (oprs.Length < 1 ) return double.Parse(sources);

            for (var i = 0; i < oprs.Length; i++)
            {

                m.RightCount = source.Length - (i + 1);
                m.LeftCount = source.Length - m.RightCount;
                
                double valueM = 1;
                switch (oprs[i])
                {
                    case '*' :

                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() * m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add(valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);
                            m.Mult();
                            valueM = m.Result;
                            tempNums.Add(valueM);
                        }
                        break;
                    case 'x':

                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() * m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add(valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);
                            m.Mult();
                            valueM = m.Result;
                            tempNums.Add(valueM);
                        }
                        break;
                    case '/':
                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() / m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add(valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);
                           
                            valueM = m.Div(); 
                            tempNums.Add(valueM);
                        }
                        break;
                    case '÷':
                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() / m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add(valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);

                            valueM = m.Div();
                            tempNums.Add(valueM);
                        }
                        break;
                    case '\\':
                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() / m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add((int)valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);
                            valueM = m.IntDiv();
                            tempNums.Add((int)valueM);
                        }
                        break;
                    case '%':
                        if (usedsId.Contains(i))
                        {
                            m.RightNumber = source[i + 1];
                            valueM = tempNums.Last() % m.RightNumber;
                            tempNums.RemoveAt(tempNums.Count - 1);
                            tempNums.Add(valueM);
                            usedsId.Add(i + 1);
                        }
                        else
                        {
                            m.LeftNumber = source[i];
                            m.RightNumber = source[i + 1];
                            usedsId.Add(i + 1);
                            valueM = m.RestDiv();
                            tempNums.Add(valueM);
                        }
                        break;
                    default:

                        if (!usedsId.Contains(i))
                        {
                            m.LeftNumber = source[i];
                            tempNums.Add(m.LeftNumber);
                        }
                        tempOperadores.Add(oprs[i]);
                        break;

                }
            }
             double value = 0;
            if (tempNums.Count < 1) return value;
           
                value = tempNums[0];
                for (var i = 1; i < tempNums.Count; i++)
                {
                    switch (tempOperadores[i - 1])
                    {
                        case '+':
                            value += tempNums[i];
                            break;
                        case '-':
                            value -= tempNums[i];
                            break;
                        default:
                            value += 0;
                            break;
                    }
                }



            //var str = tempNums.Aggregate(string.Empty, (current, n) => current + (n + " , "));
            //var str1 = tempOperadores.Aggregate(string.Empty, (current, n) => current + (n + " , "));
            //Console.WriteLine(str1);  // {//26/05/1992}
            var ts = value;
            return ts;
        }

      internal static double Execute(string source)
      {
          var str = SplitParenteses(source);
          return  Compute(str);
      }
      /// <summary>
        /// separa os calculos dentro de parenteses para aplicar a ordem de precedencia
        /// </summary>
        /// <param name="source"> A equação</param>
      
        /// <returns></returns>
       internal static string SplitParenteses(string source)
        {
            var strs = string.Empty;
            var blocked = false;
            var idx = 0;
            if (!(source.Contains("(") || source.Contains(")"))) return SplitExpoents(source);
            for (var i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case '(':
                        blocked = true;
                        idx = i;/*source.IndexOf(source[i], 0);*/
                        break;
                    case ')':
                        var idx1 = i;
                        var str = source.Substring(idx + 1, idx1 - idx - 1);

                        str += "+0";

                        var num = Compute(str);

                        strs += (num);
                        blocked = false;
                        break;
                    default:
                        if (!blocked)
                            strs += source[i].ToString();
                        break;
                }
            }
            var st = SplitExpoents(strs);
            return st;
        }
      
      private  static string SplitExpoents( string source)
      {
          if (!source.Contains("^")) return source;
          
          var oprs = source.ExtractOperators(new[] { '^', '+', '*', 'x', '-', '%', '/', '\\' });
          var context =new  List<string>();
          var ns = source.ExtractNumbers(oprs);
          
          var m = new EnumerableMensure();
          var usedsId = new List<int>();
         
        
          for (var i = 0; i < oprs.Length; i++)
          {
              m.RightCount = source.Length - (i + 1);
              m.LeftCount = source.Length - m.RightCount;

              switch (oprs[i])
              {
                  case '^':

                      if (usedsId.Contains(i))
                      {
                          m.RightNumber = ns[i + 1];
                          var ct = Math.Pow(double.Parse(context.Last()), m.RightNumber);
                          context.RemoveAt(context.Count - 1);
                          context.Add(ct.ToString(CultureInfo.InvariantCulture));
                          usedsId.Add(i + 1);
                        }
                      else
                      {
                          var ct =  Math.Pow(ns[i] , ns[i + 1]);
                          context.Add(ct.ToString(CultureInfo.InvariantCulture));
                          usedsId.Add(i);
                          usedsId.Add(i + 1);
                      }
                      break;
                  default:
                      if (!usedsId.Contains(i))
                      {
                            context.Add(ns[i].ToString(CultureInfo.InvariantCulture));
                           
                            usedsId.Add(i);
                        }
                      context.Add(oprs[i].ToString());
                        break;
              }
          }
         
          return context.Aggregate(string.Empty, (current, n) => current + (n)) +"0";
        }
  }
}