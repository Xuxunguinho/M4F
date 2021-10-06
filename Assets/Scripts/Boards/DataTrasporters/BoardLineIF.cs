// Dveloped by : Julio Jose de Andrade Reis


using System;
using UnityEngine;

namespace Assets.Scripts.Boards.DataTrasporters
{
    /// <summary>
    /// this is simplely to Fix data in the real board(BoardITC Object)
    /// </summary>
    [Serializable]
    public class BoardLineIf
    {


        [Header("INICIO DA TARGET LINE")]
        public LineAlgs[] TargetLinesAlgs;
       
        public int[] Numbers { get; set; }
        public int Target { get; set; }

        public bool IsIcognitLine;
        [Header("FIM DA LINE ")]
        private int[] _sorteds;
        public int[] Sorteds
        {
            get { return _sorteds; }
            set
            {
                _sorteds = value;
                var alg = TargetLinesAlgs.GetFirst(Target).AlgsIndex;
                if (_sorteds.Length < 0) return;
                Numbers = new int[alg.Length];
                for (var i = 0; i < alg.Length; i++)
                    Numbers[i] = _sorteds[alg[i]];
            }
        }

       
    }

   
}
