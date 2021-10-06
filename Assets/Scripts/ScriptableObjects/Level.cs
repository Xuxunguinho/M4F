using Assets.Scripts;
using Assets.Scripts.Boards.DataTrasporters;
using UnityEngine;

[CreateAssetMenu (fileName ="Level", menuName ="World Level")]
// ReSharper disable once CheckNamespace
public class Level : ScriptableObject
{
  
    public bool IsLocked = true;
    public int Stars;

    public int Score;
    public int TimeSeconds;

    public int BestTime;
    public LevelTarget TargetGoals;

    [Header( "SORTED NUMBERS")]
    public  BoardSortedNumbers SortedNumbers;
    [Header("BOARD LINES")]
    public BoardLineIf[] Lines;
   
}
public class LevelBoardline
{
    public char[] Operators;
    public int[] Algs;
    public int[] Numbers;

    public int ResultIndex;

    public DoubleIndexValue[] MaskToHide;
    public DoubleIndexValue[] SetExpoAndIndex;
    public DoubleIndexValue[] SetAlgsMultiplicationFactor;

    public Enums.ExpoType ExpoType;
    public  Enums.ExpoType AlgsExponentsType;

    public bool IsIcognitLine;
    public override string ToString()
    {
        return "Line";
    }
}
