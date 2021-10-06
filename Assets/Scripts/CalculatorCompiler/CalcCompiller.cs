/**********************************************
 *  This software was developed by:
 *  
 *  Júlio José de Andrade Reis
 *  Email: julioreisdev@outlook.com 
 * 
 * OpenSource
 **********************************************/

namespace Assets.Scripts.CalculatorCompiler
{
    
   

    /// <summary>
    /// Compilador do mini-script
    /// </summary>
    public static  class CalcCompiller
    {
        public  static char[] SuportedOperators = { '+', '*', 'x', '-', '%', '/', '÷', '\\', '^' };
       
    /// <summary>
    /// Calcula a equação e retorna o resultado
    /// </summary>
    /// <param name="sourceScript">mini-script("2+2*25/4")</param>
    /// <returns></returns>
      public static double Compile(string sourceScript)
      {
                //var st = new Stopwatch();
                //st.Start();
                sourceScript += " + 0";
                return CompillerExtentions.Execute(sourceScript);
          
      }
      public static double CompileCalc(this BoardLineITC line)
      {
            var str = line.ToString();
            var result = Compile(str);
            line.Result = result;
            return result;
      }

    }
}
