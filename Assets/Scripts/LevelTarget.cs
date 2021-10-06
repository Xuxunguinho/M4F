using System.ComponentModel;
using UnityEngine;

[System.Serializable]
// ReSharper disable once CheckNamespace
public class LevelTarget 
{
    [Range(1,10)]
    [DefaultValue(1)]
    public int Init=1;
    [Range(1,10)]
    public int Final;
}