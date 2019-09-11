
using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.ReturnsExtensions;
using ProductMadness.CoreTech.Core.Promises;
using ProductMadness.CoreTech.DataContracts;
using ProductMadness.CoreTech.Domains.Bonuses.v2;
using ProductMadness.CoreTech.Integration.Bonuses;
using ProductMadness.CoreTech.Integration.Bonuses.v2;
using ProductMadness.ProductMadness.CoreTech.Integration.Player;
using UnityEngine.Profiling;


public class NewEditModeTest {
	
//	private BonusServiceFactory BonusServiceObject;
	
	private  PlayerFactory Player;
	private IBonusService _bonusService_nonVip,_bonusService_Vip = null;
	private IPlayer _player = null;
	private IBonusStoreReader _bonus { get; set; }
	
	
	

	
	[SetUp]
	public void SetUp()
	{
		//Mocking the interfaces
//		_bonusService_nonVip = Substitute.For<IBonusService>();
//		_bonusService_Vip = Substitute.For<IBonusService>();
//		 _player = Substitute.For<IPlayer>();
//		 _bonus = Substitute.For<IBonusStoreReader>();
//		 _bonus.GetBonus(BonusType.CashbackBonus);
		 
		 _player=PlayerFactory.Create("ebfe61bf5740b4a08baf561df9fdda27f", "12345", "12345678", 7869000000000, true,
			 "123@gmail.com");
		
		//Object creation for BonusServiceFactory and PlayFactor
//		BonusServiceObject = new BonusServiceFactory();
//		BonusService.Create(null);
		_bonusService_nonVip = BonusServiceFactory.Create();
		_bonusService_Vip = BonusServiceFactory.Create(_player);
		//_player= PlayerFactory.Create();
		//Player = new PlayerFactory();
//		Player = Substitute.For<PlayerFactory>();

	}

//	[Test]
//	public void PlayerApiTokenTest() {
////		var _player = Substitute.For<IPlayer>();
//		var apiToken = "ebfe61bf5740b4a08baf561df9fdda27f";
//		_player.ApiToken.Returns(apiToken);
//		
//		Assert.AreEqual(_player.ApiToken, apiToken );
//		
//
//	}

	[Test]
	public void Player_Platform_Account_ID_Test()
	{
		var platformAccID = "";
		_player.PlatformAccountId.Clone();
			
		Assert.AreEqual(_player.PlatformAccountId,platformAccID);

	}

	[Test]
	public void PlayerArgumentTests()
	{
		String sample = null;

//		_player = PlayerFactory.Create("ebfe61bf5740b4a08baf561df9fdda27f", "12345", "12345678", 7869000000000, true,
//			"123@gmail.com");
		Console.WriteLine(_player.ApiToken.Equals("ebfe61bf5740b4a08baf561df9fdda27f"));
//		Assert.AreEqual("ebfe61bf5740b4a08baf561df9fdda27f",_player.ApiToken.Clone());

		Assert.IsTrue(_player.ApiToken.Equals("ebfe61bf5740b4a08baf561df9fdda27f"));

	}
	
	
	
	[Test]
	public void IbonusIsNotNull()
	{
		
		Assert.IsNotNull(_bonusService_nonVip);
		
		Console.WriteLine(_bonusService_nonVip.CollectBonus<IVipBonus>().State);
		//_player = typeof(IBonusesCollectedData).Assembly.Evidence.Count.Equals()
		Console.WriteLine(_bonusService_Vip.CollectBonus<IVipBonus>().GetType());

//		Console.WriteLine(_bonusService_Vip.CollectBonus(0));


	}
	IPromise<IBonusesCollectedData> CollectBonus<IVipBonus>()
	{
//		IsPurchasing = true;
//
		var outcome = new Promise<IBonusesCollectedData>();
//		var transaction = new PaymentTransaction(product, GetRandomMultiplier());
//		Scheduler.Instance.SubmitCoroutine(CompleteAfterDelay(outcome, transaction));

		return outcome;
	}

	[Test]
	public void SubscribeToBonus()
	{
//		_bonus.Received().BonusDataUpdated += Arg.Any<value>();
Assert.IsTrue(_bonus.HasBonusOfType<ITimeBonus>());
//Assert.IsTrue(_bonus.HasBonusOfType<IVipBonus>());
//Assert.IsTrue(_bonus.HasBonusOfType<IBonus>());
//		Assert.IsTrue(_bonus.HasBonusOfType<CashBonus>());
	}


	[Test()]
	public void WillUpdateGivenBonusesOnly()
	{
		var b1 = _bonus.GetBonusWithType<IVipBonus>();
		var b2 = _bonus.GetBonusWithType<ITimeBonus>();
		var b3 = _bonus.GetBonusWithType<IBonus>();

		var n1 = Substitute.For<IVipBonus>();
		n1.GetType();

		var n2 = Substitute.For<ITimeBonus>();
		n1.Type.Returns(BonusType.TimeBonus);

		var n3 = Substitute.For<IBonus>();
		n3.GetType();
		

		Console.WriteLine(n2.GetType());
		Assert.AreSame(b1, _bonus.GetBonusWithType<IVipBonus>());

	}
	
	[Test()]
	public void WillGetClaimedBonus()
	{
		Assert.IsNull(_bonus.GetClaimedBonusWithType<IVipBonus>());

		_bonus.GetBonusWithType<IVipBonus>().IsCollected.Returns(true);

		Assert.IsNotNull(_bonus.GetClaimedBonusWithType<IVipBonus>());
	}
	
	[Test]
	public void Is_EventSubscription_WorkingFine()
	{
		_bonusService_nonVip.BonusStoreReader.BonusDataUpdated += OnUpdated;
		Console.ReadKey(true);
	}
	
	private void OnUpdated()
	{
		//add { _bonusStore.BonusDataUpdated += value; }
	//	Console.WriteLine(_bonusService_nonVip.BonusStoreReader.GetBonus(BonusType.CashbackBonus));
	Console.WriteLine("Event is subscribed successfully");
	}
}







