/* Developed by Julio Jose de Andrade Reis
* 2018 All rigth reserved 
* This game was created for my knowlodge test.
*/
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
public static  class PossibleResultsRenerator
{
    private static List<double> Nums = new List<double>() ;
    private static   int[] _srtSc;
    private static   int[] _srtSomas;
  
    /// <summary>
    /// Calculate de values in multiple form more advanced
    /// </summary>
    /// <param name="line"></param>
    public static  void  Execute(BoardLineITC line)
    {
       _srtSc = new SortedNumbers().Execute(0, 5, 5);
        _srtSomas = new SortedNumbers().Execute(-10, 10, 5);
        Nums = new List<double> {line.Result};
        Poss_results(line);
        
     }
  
    private static  List<double>  Poss_results( BoardLineITC icogniteLine)
    {

        /* verificando se tem alguns dos operadores que estao  na condicao abaixo porque 
         * estes operadores mudam o sentido da geracao  de caolculos 
          * porque temos dois tipos de possiblidades : um onde se encontram erros logicos
         * ( erros na ordem de precedencia dos operadores  por exemplo!) e outro que sao os 
        *erros matematicos( erros normais de calculo) 
        */

        if (icogniteLine.GetNumbers().Length > 2)

            /* Aqui utilizaremos os erros logicos
             * 
             Aqui foi invertido a ordem de precedecia para causar  um erro logico ao calculo
             */
            
            if (icogniteLine.Operators.Contains('*') | icogniteLine.Operators.Contains('/') & icogniteLine.Operators.Contains('+') | icogniteLine.Operators.Contains('-'))
            {
                var list = new List<double>();
                var oprs = new List<char>();
                var breaked = false;
                //int hub = 0;
                double c = 0;
                double t = 0;
              
                    for (var i = 0; i < icogniteLine.GetNumbers().Length; i++)
                    {
                        switch (icogniteLine.OpItc[i].Value)
                        {

                            case 'x':
                                if (i >= 1) //16/06/1946
                                {
                                    if (icogniteLine.OpItc[i - 1].Value == '+' | icogniteLine.OpItc[i - 1].Value == '-')
                                        list[i - 1] *= icogniteLine.Algs[i + 1].Value;

                                    else
                                    {
                                        c = icogniteLine.Algs[i].Value;
                                        list.Add(c);
                                        if (!breaked)
                                            oprs.Add('x');
                                    }
                                }
                                else
                                {

                                    if ((icogniteLine.GetNumbers().Length - 1) >= 2)
                                    {
                                        c = icogniteLine.Algs[i].Value;
                                        list.Add(c);
                                        if (!breaked)
                                            oprs.Add('x');
                                    }
                                    else
                                    {
                                        c = icogniteLine.Algs[i].Value * icogniteLine.Algs[i + 1].Value;
                                        list.Add(c);
                                    }


                                }

                                break;
                            case '%':
                                if (i >= 1) //16/06/1946
                                {
                                    if (icogniteLine.OpItc[i - 1].Value == '+' | icogniteLine.OpItc[i - 1].Value == '-')
                                        list[i - 1] %= icogniteLine.Algs[i + 1].Value;
                                    else
                                    {
                                        c = icogniteLine.Algs[i].Value;
                                        list.Add(c);
                                        if (!breaked)
                                            oprs.Add('%');
                                    }
                                }
                                else
                                {
                                    if ((icogniteLine.GetNumbers().Length - 1) >= 2)
                                    {
                                        c = icogniteLine.Algs[i].Value;
                                        list.Add(c);
                                        if (!breaked)
                                        oprs.Add('%');                                    }
                                    else
                                    {
                                        c = icogniteLine.Algs[i].Value % icogniteLine.Algs[i + 1].Value;
                                        list.Add(c);
                                    }
                                }
                                break;
                            case '+':
                                if (i >= 1) //verifica o antecessor
                                {
                                    if (icogniteLine.OpItc[i - 1].Value == '-')
                                        list[i - 1] += icogniteLine.Algs[i + 1].Value;
                                    else
                                    {
                                        c = (icogniteLine.Algs[i].Value + icogniteLine.Algs[i + 1].Value);
                                        list.Add(c);
                                    }                                 
                                }
                                else
                                {
                                    c = (icogniteLine.Algs[i].Value + icogniteLine.Algs[i + 1].Value);
                                    list.Add(c);
                                }
                                break;
                            case '-':
                                if (i >= 1) //verifica o antecessor
                                {
                                    if (icogniteLine.OpItc[i - 1].Value == '+')
                                        list[i - 1] -= icogniteLine.Algs[i + 1].Value;
                                    else
                                    {

                                        c = (icogniteLine.Algs[i].Value - icogniteLine.Algs[i + 1].Value);
                                        list.Add(c);
                                    }
                                    //}

                                }
                                else
                                {
                                    c = (icogniteLine.Algs[i].Value - icogniteLine.Algs[i + 1].Value);
                                    list.Add(c);
                                }

                                break;
                            case '=':
                                breaked = true;
                                //hub = i;

                                if (i >= 1)
                                {
                                    if (icogniteLine.OpItc[i - 1].Value != '+' | icogniteLine.OpItc[i - 1].Value != '-')
                                    {
                                        c = icogniteLine.Algs[i].Value;
                                        list.Add(c);
                                    }
                                    else
                                    {
                                        break;
                                    }

                                }
                                else
                                {
                                    c = icogniteLine.Algs[i].Value;
                                    list.Add(c);
                                }
                                break;

                        }
                    }
                    t = list[0];
                    if (oprs.Count > 0)
                    {
                    
                        for (var i = 0; i < oprs.Count; i++)
                        {
                            switch (oprs[i])
                            {
                                case 'x':
                                    t *= list[i + 1];
                                    break;
                                case '%':
                                    t %= list[i + 1];
                                    break;
                            }

                        }
                    }

                if (!Nums.Contains(t))
                    Nums.Add(t);
                else {
                    var d = icogniteLine.Result - _srtSomas[_srtSc[4]];
                    if (!Nums.Contains(d))
                        Nums.Add((d));
                    else
                    {
                         d = icogniteLine.Result + _srtSomas[_srtSc[4]];
                        if (!Nums.Contains(d))
                            Nums.Add((d));
                    }
                }
                   
                
               
            }
            //se nao tiver multiplicacao nem divizao entao vai utilizar o que chamo 
            //a lei do negativo e positivo ex: se for 8 passa para -8 e vice-versa
            else if(!icogniteLine.Operators.Contains('*') | !icogniteLine.Operators.Contains('/') & icogniteLine.Operators.Contains('+') & icogniteLine.Operators.Contains('-'))
            {
                //aqui vamos utilizar os erros Matematicos
                //(gerando numeros aproximados simplesmente)
                if (icogniteLine.Result > 0)
                {
                    if (!Nums.Contains(icogniteLine.Result))
                        Nums.Add((-icogniteLine.Result));
                    else
                    {
                        var d = icogniteLine.Result - _srtSomas[_srtSc[0]];
                        if (!Nums.Contains(d))
                            Nums.Add((d));
                    }
                }

                else if (icogniteLine.Result < 0)
                {
                    if (!Nums.Contains(+icogniteLine.Result))
                        Nums.Add((+icogniteLine.Result));
                    else
                    {
                        var d = icogniteLine.Result - _srtSomas[_srtSc[0]];
                        if (!Nums.Contains(d))
                            Nums.Add((d));
                    }
                }

                else if ((icogniteLine.Result == 0)) {
                    var d = icogniteLine.Result - _srtSomas[_srtSc[0]];
                    if (!Nums.Contains(d))
                        Nums.Add((d));
                }
              
            }
        else
        {
           
        }

        for (var i = 1; i < 4; i++)
        {
            var c = icogniteLine.Result + _srtSomas[_srtSc[i]];
            if (!Nums.Contains(c))
                Nums.Add((c));
            else
            {
                c = icogniteLine.Result - _srtSomas[_srtSc[i]];
                if (!Nums.Contains(c))
                    Nums.Add((c));
                else
                {
                    c = icogniteLine.Result - _srtSomas[_srtSc[i]];
                    if (!Nums.Contains(-c))
                        Nums.Add((-c));
                    //Debug.Log("Excecao aqui");
                }
            }
        }

        icogniteLine.Owner.LevelM.Answers.Nresults = Nums;
        return Nums;
    }

    
   
}