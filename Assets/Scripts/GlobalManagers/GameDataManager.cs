using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class PlayerData
{

    [Header("PLAYER")]
    public int Ege;
    public string Name;
    [Header("PLAYER RECORDS")]
    public int ScoreOfStarsInGame;
    public int GoldHarts;
    public int Tips;
    public string BestTimeGamed;
    [Header("LEVELS DATA")]
    public bool[] IsLocked;
    [Range(0,3)]
    public int[] Stars;
    public int[] ScoreOfStarsInLevel; 
    public int[] BestTime;
    public int[] CurrentTarget;

    /// <summary>
    /// determinadno a quantidade das linhas de dados
    /// </summary>
    /// <param name="i"></param>
    public void SetArray(int i)
    {
        IsLocked = new bool[i];
        Stars = new int[i];
        ScoreOfStarsInLevel = new int[i];
        BestTime = new int[i];
        CurrentTarget = new int[i];
    }
}

public class GameDataManager : MonoBehaviour
{
    private readonly BinaryFormatter _formatter = new BinaryFormatter();
    public static GameDataManager GameData;
    public  PlayerData SaveData;
    public World WorldGame;
    private FileStream _fs;
    private void Start()
    {
        Load();
    }

    private void Awake()
    {
        //if (gameData == null)
        //{
        //    DontDestroyOnLoad(this.gameObject);
        GameData = this;
        //}
        //else
        //{
        //    Destroy(this.gameObject);

        //}

    }
    private bool CreateData() {
        try
        {
          
            _fs = File.Open(Application.persistentDataPath + "/player.dat", FileMode.OpenOrCreate);

            var quantity = WorldGame.Levels.Length;
            SaveData.SetArray(quantity);

            var data = SaveData;

            _formatter.Serialize(_fs, data);
            _fs.Close();
            //Debug.Log("Data Created");
            return true;
        }
        catch (Exception)
        {
            return false;
           
        }
    }
    /// <summary>
    /// Salvando os dados do Jogador
    /// </summary>
    public   void Save()
    {
        // Criando o leitor para os dados

        _fs = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open,FileAccess.Write);
        // Salvando os dados do jogador
        // setando a quantidade exata a abrir nos arrays

          var data = SaveData;
      
        _formatter.Serialize(_fs,data);

        _fs.Close();
         //Debug.Log("Data saved");
    }

    private void OnDisable()
    {
        Save();
    }
   
    /// <summary>
    ///  Lendo os dados gravados do jogador
    /// </summary>
    public  void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {           
            _fs = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open,FileAccess.Read);   
            SaveData = _formatter.Deserialize(_fs) as PlayerData;
           _fs.Close();
            //Debug.Log("Data Loaded");
        }
        else
        {
            CreateData();
            {
                SaveData.ScoreOfStarsInGame = 0;
                SaveData.Tips = 2;
                SaveData.GoldHarts = 3;

                for (var i = 0; i < WorldGame.Levels.Length; i++) {

                    if(i==0)
                    SaveData.IsLocked[i] =false;
                    else
                        SaveData.IsLocked[i] = true;
                    SaveData.ScoreOfStarsInLevel[i] = 0;
                    SaveData.BestTime[i] = WorldGame.Levels[i].TimeSeconds;
                    SaveData.CurrentTarget[i] = 0;

                }
                Save();
               
                
            }
            }
        
        
    }

}
