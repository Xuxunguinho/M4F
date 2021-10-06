using UnityEngine;

[CreateAssetMenu (fileName ="World", menuName ="World")]
// ReSharper disable once CheckNamespace
public class World : ScriptableObject {
    [Range(0,3)]
    public int GoldHarts;
    public int Tips;
    public int ScoreOfStars;
    public int SelectedLevel;
    public int SelectedSkin;
    [Header("LEVELS")]
    public Level[] Levels;
    [Header("BOARD SKINS")]
    public BoardTheme[] BoardThemes;

}
