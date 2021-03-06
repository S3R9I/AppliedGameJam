﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is the main communications manager. Through this script events get called that every script can reach.
public class EventManager : MonoBehaviour {
    public delegate void ChoiceState (Choice _choice);
    public static event ChoiceState ChoiceLoad;
    public static event ChoiceState DisplayChoice;
    public static event ChooseEvent ChoiceUnLoad;
    public delegate int GetChoice();
    public static event GetChoice ChoiceGet;
	public delegate void SendAudioEvent(AudioClip ac);
	public static event SendAudioEvent SendAudio;

	public delegate void UpdateHealthEvent(HealthState hs);
	public static event UpdateHealthEvent UpdateHealth;

	public delegate void SendAudioSourceEvent(AudioSourceStorage a);
	public static event SendAudioSourceEvent SubmitAudioSource;

	public delegate void SubmitV4(ResourceStorage v4);
	public static event SubmitV4 SendV4;
	public static event SubmitV4 SetupResources;


    public delegate void StoreUserData(UserData item);
    public static event StoreUserData CreateUserData;
    public delegate void StoreItem(Item item);
    public static event StoreItem CreateStoreItem;
    public static event StoreItem BuyStoreItem;
    public delegate void ResourceEvent(params ResourceMessage[] res);
	public static event ResourceEvent SendResourceMessage;
	public static event ResourceEvent EnqueueMessageEvent;

	public delegate void AdvanceEvent();
	public static event AdvanceEvent NextDay;
	public static event AdvanceEvent GameOver;

    public delegate int GetDel();

    public delegate Queue<ResourceMessage> QueueEvent();
	public static event QueueEvent GetQueue;

	public delegate void ChooseEvent();
    public static event ChooseEvent ChoosePositive;
    public static event ChooseEvent ChooseNegative;
    public static event ChooseEvent UIEnable;
    public static event ChooseEvent UIDisable;
    public static event ChooseEvent UIContinue;
	public static event ChooseEvent EmptyQueue;
    public static event ChooseEvent CheckPopulationObjects;

    public delegate void FeedManager(GameObject go);
    public static event FeedManager AddFeed;

	public delegate void EndEvent(Resources r);
	public static event EndEvent EndGame;

	public static event ChooseEvent NightCycle;
	public static event GetDel GetAirPollution;
	public static event GetDel GetSoilPollution;
	public static event GetDel GetWaterPollution;
	public static event GetDel GetLandUse;
	public static event GetDel GetBiodiversity;
	public static event GetDel GetPopulation;
	public static event GetDel GetCurrency;


    public delegate void ParseItem(Item item);
    public static event ParseItem ParseMapItem;
	public delegate void LivingRes(params LivingResource[] res);
	public static event LivingRes AddLivingResource;
	public static event ChooseEvent ExecuteLivingResources;

	public delegate void StringEvent(string message);
	public static event StringEvent SendBreakingNews;

	public delegate void AddBaseEvent(Resources res, int amt);
	public static event AddBaseEvent AddBaseValueEvent;
	public delegate void AddModEvent(Resources res, float amt);
	public static event AddModEvent AddModifierEvent;

	public delegate GameObject GetAnim(Characters ch);
	public static event GetAnim _GetAnim;

	public delegate void LREvent(Resources res, int id);
	public delegate void LRGetEvent(LivingResource lr);

	public delegate void LrSpriteEvent(int id);
	public static event LrSpriteEvent SetLrSprite;

	public static event ChooseEvent DayCycle;
    public static void Day_Cycle() {
        DayCycle();
    }

	#region ResourceEvents
	private static int _GetAirPollution() {
		return GetAirPollution();
	}
	private static int _GetSoilPollution() {
		return GetSoilPollution();
	}
	private static int _GetWaterPollution() {
		return GetWaterPollution();
	}
	private static int _GetLandUse() {
		return GetLandUse();
	}
	private static int _GetBiodiversity() {
		return GetBiodiversity();
	}
	private static int _GetPopulation() {
		return GetPopulation();
	}
	private static int _GetCurrency() {
		return GetCurrency();
	}
	#endregion

	public static void _SetupResourceManager(ResourceStorage rs) {
		SetupResources(rs);
	}
	public static void Night_Cycle() {
        NightCycle();
    }
    public static void Choice_Load(Choice _choice) {
        ChoiceLoad(_choice);
    }

    public static void Choice_Unload() {
        ChoiceUnLoad();
    }
    public static void Parse_MapItem(Item item)
    {
        ParseMapItem(item);
    }
    public static int Choice_Get()
    {
        return ChoiceGet();
    }
    public static void Add_Feed(GameObject go)
    {
        AddFeed(go);
    }

    public static void Create_StoreItem(Item item)
    {
        CreateStoreItem(item);
    }
    public static void Create_UserData(UserData userdata)
    {
        CreateUserData(userdata);
    }
    public static void Buy_StoreItem(Item item)
    {
        BuyStoreItem(item);
    }
    public static Queue<ResourceMessage> Get_Queue() {
		return GetQueue();
	}
    public static void InterMission_Enable() {
        UIEnable();
    }
    public static void InterMission_Disable() {
		UIDisable();
    }
    public static void InterMission_Continue() {
        UIContinue();
    }
    public static void Choose_Choice(int state) {
        switch(state) {
            case (0):
                ChooseNegative();
                break;
            case (1):
                ChoosePositive();
                break;

        }
    }
    public static void Display_Choice(Choice _choice) {
        DisplayChoice(_choice);
    }

    public static void _SendResourceMessage(params ResourceMessage[] res) {
		SendResourceMessage(res);
	}
	public static void _EnqueueMessage(params ResourceMessage[] res) {
		EnqueueMessageEvent(res);
	}
	public static void _ChoiceLoad() {
		ChoiceUnLoad();
	}
	public static void _NextDay() {
		NextDay();
	}
	public static void _EndGame(Resources r) {
		EndGame(r);
	}
	public static void _SendV4(ResourceStorage v4) {
		SendV4(v4);
	}
	public static GameObject _GetAnimation(Characters c) {
		return _GetAnim(c);
	}

	public static void _AddLivingResource(params LivingResource[] res) {
		AddLivingResource(res);
	}

	public static void _ExecuteLivingResources() {
		ExecuteLivingResources();
	}

	public static void _AddBaseValue(Resources res, int amt) {
		AddBaseValueEvent(res, amt);
	}

	public static void _AddModifierValue(Resources res, float amt) {
		AddModifierEvent(res, amt);
	}

	public static void _SendBreakingNews(string s) {
		SendBreakingNews(s);
	}

	public static void _SendAudio(AudioClip ac) {
		SendAudio(ac);
	}

	public static void _SubmitAudioSource(AudioSourceStorage a) {
		SubmitAudioSource(a);
	}

	public static void _UpdateHealth(HealthState hs) {
		UpdateHealth(hs);
	}

	public static void _LrSprite(int i) {
		SetLrSprite(i);
	}

	public static void _GameOver() {
		GameOver();
	}
}
