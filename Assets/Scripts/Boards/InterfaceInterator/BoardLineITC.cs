// Dveloped by : Julio Jose de Andrade Reis

using System;
using UnityEngine;
using System.Linq;
using System.ComponentModel;
using Assets.Scripts;
using Assets.Scripts.Boards.DataTrasporters;


// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class BoardLineITC : MonoBehaviour
{
    /// <summary>
    ///  The Algs will set in de Interface design in Unity editor , cause it isn't propertys
    /// </summary>
    public LineItemITC[] Algs;
    public BoardITC Owner;
    public int Target;
    /// <summary>
    ///  it's interface operator conector or de scope of text that i'm using;
    /// </summary>
    public OperatorITC[] OpItc;
  
   
    /// <summary>
    ///  Fields to fill propertys
    /// </summary>  
    private int[] _numbers = new int[] { };
    private char[] _ops = new char[] { };
    private double _result = 0;
    private int _rsindex;
    private bool _hasVzs = false;
    public bool HasExponent { get; private set; }
   
    private Enums. ExpoType _expoType = Enums.ExpoType.ByIndex;
    private Enums.ExpoType _algTomask = Enums.ExpoType.ByIndex;

    [Description("Define o tipo de exponete 'Por valor ou por Index'")]
    public Enums.ExpoType AlgsExponentsType { get { return _expoType; } set { _expoType = value; } }
    
    
    public Enums.ExpoType AlgsMaskToHideType {
        get { return _algTomask; }
        set { _algTomask = value; }
    }

    public bool HasVzs { get { return _hasVzs; } private set { _hasVzs = value;  } }

    /// <summary>
    /// This is the numbers that  will be use in Line 
    /// </summary>

    public int[] GetNumbers() { return _numbers; }
    /// <summary>
    /// This is the numbers that  will be use in Line 
    /// </summary>

    public bool SetNumbers(int[] value)
    {
        _numbers = value;
        /* get ramdom numbers without repeat, to use in numbers[ns[i]]
         this make the array unable to repeat inside numbers ...*/

        if (GetNumbers() == null) return true;
        var ns = new SortedNumbers().Execute(0, _numbers.Length, _numbers.Length);

        if (Algs == null) return false ;
        var ridx = Algs.ToList().IndexOf(Algs[AlgForResultIndex]);
        var ms = new MensureToolKit().ExecArray1Dim((_numbers.Length), ridx);


        if (ms.LeftCount > 0)
            for (var i = 0; i < ms.LeftCount; i++)
            {
                Algs[i].Value = _numbers[ns[i]];
                Algs[i].Mask = Owner.Ms
                    .Where(n => n.Number == _numbers[ns[i]]).Select(n => n.Mask).Single();
                Algs[i].ShowMask = true;
            }

        if (ms.RightCount <= 0) return true;
        {
            for (var i = (ridx); i < _numbers.Length; i++)
            {
                Algs[i + 1].Value = _numbers[ns[i]];
                Algs[i + 1].Mask = Owner.Ms
                    .Where(n => n.Number == _numbers[ns[i]]).Select(n => n.Mask).Single();
                Algs[i].ShowMask = true;
            }
        }
        return true;
        //Debug.Log(ms.LeftCount.ToString() + " : " + ms.RightCount.ToString());
    }
    /// <summary>
    ///  this the opers that we will be used in line 
    /// </summary>
    public char[] Operators
    {
        get { return _ops; }
        set
        {

            _ops = value;
            if (Operators == null) return;
            var ns = new SortedNumbers().Execute(0, Operators.Length, Operators.Length);
            if (Operators.Length > 1)
            {
                for (var i = 0; i < GetNumbers().Length; i++)
                {
                    OpItc[i].Index = i;
                    //OpItc[i].gameObject.SetActive(true);
                    if (Algs[i + 1].IsResult != true)
                    {
                        switch (_ops[ns[i]])
                        {
                            case '+':
                                OpItc[i].Value = '+';
                                break;
                            case '-':
                                OpItc[i].Value = '-';
                                break;

                            case '*':
                                OpItc[i].Value = 'x';
                                break;
                            case 'x':
                                OpItc[i].Value = 'x';
                                break;
                            case '/':
                                OpItc[i].Value = '÷';
                                break;
                            case '÷':
                                OpItc[i].Value = '÷';
                                break;
                            case '%':
                                OpItc[i].Value = '%';
                                break;

                        }

                    }
                    else
                    {
                        OpItc[i].Value = '=';
                    }


                }
            }
            else
            {

                for (var i = 0; i < _numbers.Length; i++)
                {
                    OpItc[i].Value = Algs[i + 1].IsResult != true ? TranslateOper(_ops[0])  : '=';
                    OpItc[i].Index = i;
                }

            }
        }
    }

    private static char TranslateOper(char source)
    {
        switch (source)
        {
            case '+':
                return '+';
            case '-':
                return  '-';
            case '*':
                return 'x';
            case 'x':
                return 'x';
            case '/':
                return  '÷';
            case '÷':
                return '÷';
            case '%':
                return  '%';
                default:
                    return '+';
        }
    }

    [Description("Indica o algarismo a ser escondio a sua mascara!" )]
    public int[] AlgsToHideMask
    {
        set
        {
            if (value.Length <= 0) return;
            foreach (var t in value)
            {
                HideMask(t);
            }
        }
    }
    [Description("Indica o numero de vezes que um algarismo ]e repetido dentro da linha")]   
    public DoubleIndexValue[] AlgsMultiplicationFactor
    {
        set
        {
            if (value.Length <= 0) return;
            foreach (var t in value)
            {
                 SetAlgsMultiplicationFactor(t);
                _hasVzs = true;
            }
        }
    }

    [Description ("Seta um expoente para um determinado Algarismo dentro da linha")]
    public DoubleIndexValue[] AlgsExponents
    {
        set
        {
            if (value.Length <= 0) return;
            HasExponent = true;
            foreach (var t in value)
            {
                UseExpo(t);
            }
        }
    }
    /// <summary>
    ///  set the order to organize the Algs
    /// </summary>
    public Enums.LineOrientation ArrangeOrientation { get; set; }

    public BoardLineITC()
    {
        HasExponent = false;
    }

    public void Set(BoardLineIf line)
    {
        //this.gameObject.SetActive(true);
        var trline = line.TargetLinesAlgs.GetFirst(line.Target);

        this.AlgsExponentsType = trline.AlgsExponentsType;

        this.IsIcognitLine = line.IsIcognitLine;
      
        this.AlgsMultiplicationFactor = trline.AlgsMultiplicationFactor;
       
       
        this.AlgForResultIndex = trline.AlgForResultIndex;

        if (this.SetNumbers(line.Numbers))
            this.Operators = trline.Operators;
        
        
        this.AlgsMaskToHideType = trline.AlgsMaskToHideType;
        this.AlgsToHideMask = trline.AlgsToHideMask;
        this.AlgsExponents = trline.AlgsExponents;
    }

    public bool IsIcognitLine { get; set; }

    /// <summary>
    /// it's usede to hide speecific Masknumber
    /// </summary>
    private void HideMask(int index)
    {
        if (AlgsMaskToHideType == Enums.ExpoType.ByIndex)
        {
            Algs[index].ShowMask = false;
            return;
        }
       var xvalue = this.Owner.Numbers[index];
        Algs.Single(ag => Math.Abs(ag.Value - xvalue) < 1 && ag.IsResult !=true ).ShowMask = false;
    }

    /// <summary>
    /// Set expoenet fo the item
    /// </summary>
    /// <param name="didx"></param>
    private void UseExpo(DoubleIndexValue didx)
    {
        if (this.AlgsExponentsType == Enums.ExpoType.ByIndex)
        {
            Algs[didx.Index].UseExpo = true;
            Algs[didx.Index].Exponent = (int)didx.Value;
            return;
        }
      
            var xvalue = this.Owner.Numbers[(int)didx.Index];
            Algs.Single(ag => Math.Abs(ag.Value - xvalue) < 1  ).UseExpo = true;
            Algs.Single(ag => Math.Abs(ag.Value - xvalue) < 1  ).Exponent = (int)didx.Value;
    }

    

    /// <summary>
    /// set item vzs
    /// </summary>
    /// <param name="bidx"></param>
    private void SetAlgsMultiplicationFactor(DoubleIndexValue bidx) {
        Algs[bidx.Index].MultiplicationFactor = (int)bidx.Value;
    }
   
    public double Result
    { get { return _result; }
        set { _result = value;
            Algs[AlgForResultIndex].Value = /*int.Parse(*/_result/*)*/;
        }
    }
    public  int AlgForResultIndex
    {
        get { return _rsindex; }

        set
        {
            _rsindex = value;           
            Algs[_rsindex].IsResult = true;
            //Algs[_rsindex].Index = Algs.Count(n => n.IsResult != true) + 1;
        }
    }
    /// <summary>
    /// Ajustando a posicao dos elementos quadro : Design ! 
    /// </summary>
   
    public void Reset()
    {
            Algs[0].Reset();
            Algs[1].Reset();
            Algs[2].Reset();
            Algs[3].Reset();
            //AlgForResultIndex = 0;
    }
    void Update()
    {
        if (IsIcognitLine)
        {
            Algs[AlgForResultIndex].ValueText.text = "?";
        }

        this.gameObject.SetActive(_numbers.Length >= 1);
    }

    public override string ToString()
    {

        var str = string.Empty;
        for (var x=0;x< Algs.Length-1;x++)
        {
            if (Math.Abs(Algs[x].Value) < 1 ) continue;
            str += string.Format(" ({0}* {1}) ^ {2} {3} ", Algs[x].MultiplicationFactor, Algs[x].Value, Algs[x].Exponent, OpItc[x].Value =='=' ? ' ' : OpItc[x].Value);
        }
        return str;
    }
}
//29/05/1998