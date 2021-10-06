using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.Boards.DataTrasporters;

public class Boards
{

    public List<BoardIfCopy> Get( int[] i, params char[] opers)
    {
        return new List<BoardIfCopy>() {
          #region "Level 1"
              // Primeiro board
            new BoardIfCopy
            {
              Level =1,
              Id = 1,
              Lines = new LevelBoardline[]
              {
                new LevelBoardline
                {
                    Numbers = new int[]{ i[0]},
                     Operators = new char[]{'+'},
                    // =1,
                    MaskToHide = new DoubleIndexValue[]{},

                    SetExpoAndIndex =new DoubleIndexValue[] { },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{  }
                    ,IsIcognitLine =false
                },
                   new LevelBoardline{
                    MaskToHide = new DoubleIndexValue[]{ },
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1]},
                    Operators = new char[]{'+'},
                    // =1
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =2,
                    Numbers = new int[]{ i[1],i[0]},
                   Operators = new char[]{'+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion          
          #region "Level 2"
              // Primeiro board
            new BoardIfCopy
            {
              Level=2,
              Id = 1,
              Lines = new LevelBoardline[]
              {
                new LevelBoardline
                {
                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] { },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline{
                    MaskToHide = new DoubleIndexValue[]{ },
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1]},
                    Operators = new char[]{'+'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =2,
                    Numbers = new int[]{ i[1],i[0]},
                    Operators = new char[]{'+'},
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion          
          #region "Level 3"
              // Primeiro board
            new BoardIfCopy
            {
              Level=3,
              Id = 1,
              Lines = new LevelBoardline[]
              {
                new LevelBoardline
                {
                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] { },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline{
                    MaskToHide = new DoubleIndexValue[]{ },
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[0],i[1]},
                    Operators = new char[]{'+'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =2,
                    Numbers = new int[]{ i[1],i[1]},
                    Operators = new char[]{'+'},
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
         #endregion
         #region "Level 4"
              // Primeiro board
            new BoardIfCopy
            {
              Level =4,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[0]},
                    Operators = new char[]{'+'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[0],i[0]},
                   Operators = new char[]{'+',},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 5"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 5,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[0],i[1]},
                    Operators = new char[]{'+'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[0],i[1],i[1]},
                   Operators = new char[]{'+' },

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 6"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 6,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] { },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[0],i[0],i[1]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 7"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 7,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[0],i[0]},
                   Operators = new char[]{'+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 8"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 8,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 9"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 9,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1],i[1]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 10"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 10,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1],i[1]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'+','-'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 11"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 11,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'+','-'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 12"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 12,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[1],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'-'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 13"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 13,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[1],i[0]},
                   Operators = new char[]{'-'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 14"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 14,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[0],i[0]},
                   Operators = new char[]{'-','+'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 15"
              // Primeiro board
            new BoardIfCopy
            {
              Level = 15,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[0],i[0]},
                    Operators = new char[]{'+'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[1],i[0]},
                    Operators = new char[]{'+','-'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[1],i[0],i[0]},
                   Operators = new char[]{'-'},

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                },

              }
            },
            // FIM
#endregion   
          #region "Level 4 mais acima"
              // Primeiro board
            new BoardIfCopy
            {
              Level =16,
              Id = 1,
              Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[1]},
                    Operators = new char[]{'+'},
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{new DoubleIndexValue { Index = 1, Value = i[1] } },
                    SetExpoAndIndex =new DoubleIndexValue[] {},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{}
                    ,IsIcognitLine =false
                },
                   new LevelBoardline
                   {
                    MaskToHide = new DoubleIndexValue[]{new DoubleIndexValue { Index = 1, Value = i[3] } },
                    SetExpoAndIndex =new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    Numbers = new int[]{i[2],i[3]},
                    Operators = new char[]{'+'},
                    // =2
                    IsIcognitLine = false
                },
                new LevelBoardline

                {   // =3,
                    Numbers = new int[]{ i[0],i[2],i[2]},
                   Operators = new char[]{'+' },

                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                   ,IsIcognitLine =true
                },

              }
            },
            new BoardIfCopy
            {
                Level =17,
                Id = 1,
                Lines = new LevelBoardline[] {
                    new LevelBoardline{

                        Numbers = new int[]{ i[0],i[1]},
                        Operators = new char[]{'+','-','*','%'},
                        // =2,
                        MaskToHide = new DoubleIndexValue[]{/*new DoubleIndexValue { Index = 1, Value = i[1] }*/ },
                        SetExpoAndIndex =new DoubleIndexValue[] { new DoubleIndexValue { Index = 0 , Value = 2} },
                        AlgsExponentsType = Enums.ExpoType.ByIndex,
                        SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ /*new DoubleIndexValue { Index = 0 , Value =2}*/ }
                       ,IsIcognitLine =false
                    },
                    new LevelBoardline
                    {
                        MaskToHide = new DoubleIndexValue[]{/*new DoubleIndexValue { Index = 1, Value = i[3] }*/ },
                        SetExpoAndIndex =new DoubleIndexValue[]{ },

                        Numbers = new int[]{i[1],i[1],i[1]},
                        SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ new DoubleIndexValue { Index = 2, Value = 2 } },

                        Operators = new char[]{'+'},
                        // =3
                       IsIcognitLine = false
                    },
                    new LevelBoardline

                    {
                        Numbers = new int[]{ i[0],i[2]},
                        Operators = new char[]{'+','-' },
                        // =2,
                        MaskToHide = new DoubleIndexValue[]{},
                        SetExpoAndIndex = new DoubleIndexValue[]{ },
                        SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                        IsIcognitLine = false
                    },
                    new LevelBoardline
                    {
                        // =1,
                        Numbers = new int[]{i[2]},
                        Operators = new char[]{'+' },
                        MaskToHide = new DoubleIndexValue[]{},
                        SetExpoAndIndex = new DoubleIndexValue[]{ },
                        SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                        ,IsIcognitLine =true
                    }
                  }
               },
            new BoardIfCopy
            {
            Level =18,
            Id = 1,
            Lines = new LevelBoardline[] {
                new LevelBoardline{

                    Numbers = new int[]{ i[0],i[1],i[0]},
                    Operators = new char[]{'+','-'},
                    // =3,
                    MaskToHide = new DoubleIndexValue[]{/*new DoubleIndexValue { Index = 1, Value = i[1] }*/ },
                    SetExpoAndIndex =new DoubleIndexValue[] { new DoubleIndexValue { Index = 0 , Value = 2} },
                   AlgsExponentsType = Enums.ExpoType.ByIndex,
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ /*new DoubleIndexValue { Index = 0 , Value =2}*/ }
                   ,IsIcognitLine =false
                },
                new LevelBoardline
                {
                    MaskToHide = new DoubleIndexValue[]{/*new DoubleIndexValue { Index = 1, Value = i[3] }*/ },
                    SetExpoAndIndex =new DoubleIndexValue[]{ },

                    Numbers = new int[]{i[1],i[1],i[1]},
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ new DoubleIndexValue { Index = 2, Value = 2 } },

                    Operators = new char[]{'+'},
                    // =3
                    IsIcognitLine = false
                },
                new LevelBoardline

                {
                    Numbers = new int[]{ i[0],i[2]},
                    Operators = new char[]{'+','-' },
                    // =2,
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ },
                    IsIcognitLine = false
                },
                new LevelBoardline
                {
                    // =1,
                    Numbers = new int[]{i[2]},
                    Operators = new char[]{'+' },
                    MaskToHide = new DoubleIndexValue[]{},
                    SetExpoAndIndex = new DoubleIndexValue[]{ },
                    SetAlgsMultiplicationFactor= new DoubleIndexValue[]{ }
                    ,IsIcognitLine =true
                }
            }
        }
            // FIM
            #endregion

                    };
        //return new List<BoardIfCopy>();
    }

}


