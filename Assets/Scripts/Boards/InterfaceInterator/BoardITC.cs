// Dveloped by : Julio Jose de Andrade Reis
using UnityEngine;
using  System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Boards.DataTrasporters;
using Assets.Scripts.CalculatorCompiler;

// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class BoardITC : MonoBehaviour
{ 
   
    /// <summary>
    ///  The Masks will set in de Interface design in Unity editor , cause it isn't propertys
    /// </summary>
    public BoardLineITC[] Lines;
    public LevelInterfaceManager LevelM;
    public Enums.LineOrientation OrientationForFill;
    public  ParticleSystem Psanim;
    /// <summary>
    ///  The Masks will set in de Interface design in Unity editor cause it isn't propertys
    ///  The Mask.lenghs can't < Numbers.length ... or can be ===/>
    /// </summary>
    public BoardTheme Skin { get; set; }
    /// <summary>
    ///  Fields to fill propertys
    /// </summary>
    private int[] _ns=new int[] { };
    private BoardIf _bif;
    /// <summary>
    ///  This the total opers in the board i go to {//29/05/1998} use it in min AI For controls de Calcs
    /// </summary>

    /// <summary>
    ///  This the total Numbers  in the board i go to use it in min AI For controls de Calcs
    ///  and also to set de Masks for each Numbes in Numbers[]
    /// </summary>
    public int[] Numbers {get { return _ns; }  set {
            _ns = value;
            MasksForNumbers();
        }
    }

    public bool ResetLines()
    {
        Lines[0].Reset();
        Lines[1].Reset();
        Lines[2].Reset();
        Lines[3].Reset();
        Lines[4].Reset();
        return true;
    }
    /// <summary>
    ///  this property receive and Fixboard to your propertys and values
    /// </summary>
    public void SetBoardValues(BoardIf value)
    {
        _bif = value;
      


        if (ResetLines())
        {
            this.gameObject.SetActive(false);
            if (Lines.Length < 0) return;
            for (var i = 0; i < _bif.Lines.Length; i++)
            {

                Lines[i].Set(_bif.Lines[i]);
                var xvalue = Lines[i].CompileCalc();
                if (!Lines[i].IsIcognitLine) continue;
                Debug.ClearDeveloperConsole();
                Debug.Log(xvalue.ToString());
            }
        }
        /*ew Compute().Execute(LevelM.Board);*/
        PossibleResultsRenerator.Execute(Lines.FirstOrDefault(x => x.IsIcognitLine));
        Psanim.Play();

        this.gameObject.SetActive(true);
    }
    /// <summary>
    /// Set mask for each numbers in Board without repeat
    /// </summary>
    /// <returns> </returns>
    public  void MasksForNumbers()
    {
        var sn = new SortedNumbers().Execute(0, Skin.AlgsMask.Length, Numbers.Length);
        var lst = new List<MaskItem>();
        lst.Clear();
        lst.AddRange(Numbers.Select((t, i) => new MaskItem
        {
            Number = t,
            Mask = Skin.AlgsMask[sn[i]]
        }));

        Ms = lst  ;
    }
    public List<MaskItem> Ms { get; set; }
}