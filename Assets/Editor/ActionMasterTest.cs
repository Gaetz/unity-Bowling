using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using System;


[TestFixture]
public class ActionMasterTests
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster actionMaster;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00_PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01_OneStrikeReturnEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02_8ReturnTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03_28SpareReturnEndTurn()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(2));
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }

}
