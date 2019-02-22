using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;



[TestFixture]
public class ActionMasterTest
{

    private List<int> pinFalls;

    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup()
    {
        // this structure inserts below line in every test
        //actionMaster = new ActionMaster();
        pinFalls = new List<int>();
    }

    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02BowlReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03TestEndGameOnTenStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10,10,10,10,10};

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04Bowl28SpareReturnsEndTurn()
    {
        // spare to zbicie wszystkich 10 w dwóch rzutach.
        int[] rolls = { 10 };
        // czyli najpierw wywołujemy rzut zbijający 2 kręgle

        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
        // a potem zbicie kolejnych 8 oznacza strącenie wszystkich w 2 rzutach, czyli "spare"
    }


    [Test]
    public void T05CheckResteAtStrkieInLastFrame()
    {
        // przelatujemy wszystkie 9 framów
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4 ,6};
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07YouTubeRollsEndinEndGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 6, 6 };

        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08GameEndsAtBowl20()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 3};
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09IsThereATidyOnBowl20()
    {
        int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,5 };

        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10SecondBowlInFrameIncrementsBowlBy2()
    {
        int[] rolls = { 0, 10, 5, 1 };

        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
}