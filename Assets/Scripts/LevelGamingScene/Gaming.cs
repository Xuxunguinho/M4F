using System;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Boards.DataTrasporters;
using UnityEngine;

// ReSharper disable once CheckNamespace
public class Gaming : LevelInterfaceManager
{
    private SoundManager _soundManager;

    // Use this for initialization 
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        LoadBoard();
    }

    private void Awake()
    {
        OverDrawPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TargetText.text = string.Format("{0} / {1}", "" + World.Levels[this.World.SelectedLevel - 1].TargetGoals.Init,
            World.Levels[this.World.SelectedLevel - 1].TargetGoals.Final);
//        BestTimeText.text = string.Format("{0}  s", "" + World.Levels[this.World.SelectedLevel - 1].BestTime);
        ScoreOfStarsText.text = string.Format("{0}", "" + World.ScoreOfStars);
        LevelShowText.text = string.Format("Level {0}", this.World.SelectedLevel);
        //Tips.text = string.Format("{0}", "" + World.Tips);
//        HartsText.text = "" + World.GoldHarts;
    }

    public override void LoadBoard()
    {
        var idx = this.World.SelectedLevel - 1;
        var level = World.Levels[idx];
        StopWatch.Time = level.TimeSeconds;
        var nSorteds = new SortedNumbers().Execute(level.SortedNumbers);

        Board.Skin = World.BoardThemes[World.SelectedSkin - 1];
        Board.Numbers = nSorteds;

        var boardToload = new BoardIf
        {
            Id = 1,
            Level = idx,
            Lines = level.Lines,
            Target = level.TargetGoals.Init,
            SortedNumbers = nSorteds
        };
        if (Board.ResetLines())
            Board.SetBoardValues(boardToload);


//        foreach (var l in World.Levels)
//        {
//            var idx = World.Levels.ToList().IndexOf(l);
//            if (idx > 17) return;
//            var nSorteds = new SortedNumbers().Execute(l.SortedNumbers);
//            var board = new Boards().Get(nSorteds, new char[] { })[idx];
//            l.Lines = new BoardLineIf[board.Lines.Length];
//            foreach (var x in board.Lines)
//            {


        //        var idxx = board.Lines.ToList().IndexOf(x);
        //        var item = new BoardLineIf();
        //        if (item == null) return; item.IsIcognitLine = x.IsIcognitLine;
        //        item.TargetLinesAlgs = new LineAlgs[1];
        //        item.TargetLinesAlgs[0] = new LineAlgs();
        //        item.TargetLinesAlgs[0].TargetIndex = 1;
        //        if (x.MaskToHide.Length > 0)
        //        {
        //            item.TargetLinesAlgs[0].AlgsToHideMask = new int[x.MaskToHide.Length];

        //            for (var j = 0; j < x.MaskToHide.Length; j++)
        //            {
        //                item.TargetLinesAlgs[0].AlgsToHideMask[j] = x.MaskToHide[j].Index;
        //            }
        //        }

        //        item.TargetLinesAlgs[0].Operators = x.Operators ?? new char[] { };
        //        item.TargetLinesAlgs[0].AlgsMultiplicationFactor = x.SetAlgsMultiplicationFactor;
        //        item.TargetLinesAlgs[0].AlgsExponentsType = x.AlgsExponentsType;
        //        item.TargetLinesAlgs[0].AlgsExponents = x.SetExpoAndIndex;

        //        item.TargetLinesAlgs[0].AlgsIndex = new int[x.Numbers.Length];
        //        for (var j = 0; j < item.TargetLinesAlgs[0].AlgsIndex.Length; j++)
        //        {
        //            item.TargetLinesAlgs[0].AlgsIndex[j] = nSorteds.ToList().IndexOf(x.Numbers[j]);

        //        }
        //        l.Lines[idxx] = item;
        //    }

        //}
        //MigrateBoards();
    }

    //    //private void MigrateBoards()
    //{
    //    foreach (var l in World.Levels)
    //    {
    //        var idx = World.Levels.ToList().IndexOf(l);
    //        if (idx > 17) return;
    //        var nSorteds = new SortedNumbers().Execute(l.SortedNumbers);
    //        var board = new Boards().Get(nSorteds)[idx];
    //        //for (var i = 0; i < boards.Count - 1; i++)
    //        //{
    //        l.Lines = board.Lines;
    //        //l.SortedNumbers = nSorteds;
    //        foreach (var x in l.Lines)
    //        {
    //          var algs = x.TargetLinesAlgs.GetFirst(0).AlgsIndex = new int[x.Numbers.Length];

    //            for (var j = 0; j < algs.Length; j++)
    //            {
    //                algs[j] = nSorteds.ToList().IndexOf(x.Numbers[j]);
    //            }

    //        }
    //        //}

    //    }
    //    Console.WriteLine("");
    //}

    public void StopGame()
    {
        //StopWatch.Stoped = true;
        _soundManager.PlayOnClick();
        this.OverDrawPanel.SetActive(true);
        OverdrawObject.Show(2);
    }

    public void StopGameYes()
    {
        _soundManager.PlayOnClick();
        this.OverDrawPanel.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Levels");
    }

    public void StopGameNo()
    {
        //StopWatch.Stoped = false;
        _soundManager.PlayOnClick();
        this.OverDrawPanel.SetActive(false);
    }
}