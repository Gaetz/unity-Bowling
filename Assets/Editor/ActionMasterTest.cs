using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System.Linq;


[TestFixture]
public class ActionMasterTests
{
    private ActionMasterOld.Action endTurn = ActionMasterOld.Action.EndTurn;
    private ActionMasterOld.Action tidy = ActionMasterOld.Action.Tidy;
    private ActionMasterOld.Action reset = ActionMasterOld.Action.Reset;
    private ActionMasterOld.Action endGame = ActionMasterOld.Action.EndGame;

    private List<int> pinFalls;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }

    [Test]
    public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_OneStrikeReturnEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T02_8ReturnTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T03_28SpareReturnEndTurn()
    {
        pinFalls.Add(2);
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(pinFalls));
        pinFalls.Add(8);
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T04_CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10 };
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05_CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9 };
        Assert.AreEqual(reset, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06_EndGame()
    {
        int[] rolls = { 8,2, 7,3, 3,4, 10,2, 8,10, 10,8, 0,10, 8,2, 9 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07_GameEndAtBowl20()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,8 };
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T08_TidyAtBowl20()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5 };
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T09_TidyFromStrikeThen0()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0 };
        Assert.AreEqual(tidy, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T10_0Then10PinsGetOnly1BowlMore()
    {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(rolls.ToList()));
    }

    [Test]
    public void T11_PerfectEndScore()
    {
        int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
        pinFalls.AddRange(rolls);
        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMasterOld.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMasterOld.NextAction(pinFalls));
        pinFalls.Add(10);
        Assert.AreEqual(endGame, ActionMasterOld.NextAction(pinFalls));
    }

    [Test]
    public void T12_0Then1()
    {
        pinFalls.Add(0);
        pinFalls.Add(1);
        Assert.AreEqual(endTurn, ActionMasterOld.NextAction(pinFalls));
    }
}
