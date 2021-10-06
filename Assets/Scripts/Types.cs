using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts
{

    [Serializable]
    public class DoubleIndexValue
    {
      
        public int Index;
        public double Value;

    }
    public class BoolIndexValue
    {
        public int Index { get; set; }
        public bool Value { get; set; }
    }
    [Serializable]
    public class LineOperator
    {
        public int Target;
        public char[] Operators;
        public char this[int index]
        {
            get { return Operators[index]; }
        }
    }
    [Serializable]
    public class LineAlgs
    {
        [Range(1,10)]
        [DefaultValue(1)]
        public int TargetIndex;
        public int[] AlgsIndex;
        public char [] Operators;
        public DoubleIndexValue[] AlgsMultiplicationFactor;
        public Enums.ExpoType AlgsMaskToHideType;
        public int [] AlgsToHideMask;
        public Enums.ExpoType AlgsExponentsType;
        public DoubleIndexValue[] AlgsExponents;
        public int AlgForResultIndex
        {
            get { return CustonAlgForResultIndex != 0 ? CustonAlgForResultIndex : AlgsIndex.Length; }
        }
        [Range(0, 3)]
        public int CustonAlgForResultIndex;
     
        public int this[int index]
        {
            get { return AlgsIndex[index]; }
        }

       
    }
}