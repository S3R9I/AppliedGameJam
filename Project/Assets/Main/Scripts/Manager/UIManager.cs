﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//This class handles the UI displaying and only that. The choiceManager gets called from here.
public class UIManager : MonoBehaviour {
    public GameObject Choice;
    public GameObject Screen;
    public GameObject Screen_Sprite;
    public GameObject Results;

    public GameObject DesicionButton;
    public GameObject ContinueButton;
    public Text Textbubble;
    public Image Character;

	private Transform currentChar;

    public Text Population;
    public Text Biodiversity;
    public Text Land_Use;
    public Text Currency;
    public Text Environment;

    public Text Pollution;
    public Text AirPollution;
    public Text SoilPollution;
    public Text WaterPollution;

    public Text ResultPop;
    public Text ResultPol;
    public Text ResultBio;
    public Text ResultLandU;
    public Text ResultCur;

    //Format of: population, currency, happiness, environment

    private ResourceStorage resourceDeltas;
    private void Start() {
        EventManager.ChoiceLoad += LoadChoice;
        EventManager.DisplayChoice += SetChoice;
        EventManager.UIEnable += EnableUI;
        EventManager.UIDisable += DisableUI;
        EventManager.UIContinue += ContinueUI;
        EventManager.SendV4 += GetDeltas;
        Screen_Sprite.transform.DOScale(0, 1);
    }
    private void Update() {
        Population.text = "" + AppManager.instance.User.population;
        Land_Use.text = "" + AppManager.instance.User.land_use + "%";
        Currency.text = "" + AppManager.instance.User.currency;
        Biodiversity.text = "" + AppManager.instance.User.biodiversity;
        Pollution.text = "" + ((AppManager.instance.User.air_pollution + AppManager.instance.User.water_pollution + AppManager.instance.User.soil_pollution) / 3) + "%";
        AirPollution.text = "" + AppManager.instance.User.air_pollution + "%";
        SoilPollution.text = "" + AppManager.instance.User.soil_pollution + "%";
        WaterPollution.text = "" + AppManager.instance.User.water_pollution + "%";
    }

    void EnableUI() {
        Screen.SetActive(false);
        Results.SetActive(true);
        ResultPop.DOText("" + (resourceDeltas.population - AppManager.instance.User.population) + " people", 1, true,ScrambleMode.None);
        ResultPol.DOText("" + (((resourceDeltas.airPollution + resourceDeltas.waterPollution + resourceDeltas.soilPollution) / 3) - (AppManager.instance.User.air_pollution + AppManager.instance.User.water_pollution + AppManager.instance.User.soil_pollution) / 3) + " %", 1, true, ScrambleMode.None);
        ResultLandU.DOText("" + (resourceDeltas.landUse - AppManager.instance.User.land_use) + "%", 1, true, ScrambleMode.None);
        ResultCur.DOText("" + (resourceDeltas.currency - AppManager.instance.User.currency) + " paluta", 1, true, ScrambleMode.None);
        ResultBio.DOText("" + (resourceDeltas.biodiversity - AppManager.instance.User.biodiversity) + "%", 1, true, ScrambleMode.None);
        Choice.SetActive(false);

    }
    void DisableUI() {
        Screen.SetActive(true);
        Results.SetActive(false);
        Choice.SetActive(true);
    }

    //Format of: population, currency, happiness, environment
    private void GetDeltas(ResourceStorage v4) {
        resourceDeltas = v4;
    }
    void ContinueUI() {
    }
    void LoadChoice(Choice _choice) {
        
		if(currentChar != null)
			DestroyImmediate(currentChar.gameObject);
        Choice.SetActive(true);
        DesicionButton.SetActive(true);
        ContinueButton.SetActive(false);
		currentChar = Instantiate(EventManager._GetAnimation(_choice.character)).transform;
		Character.enabled = false;
		currentChar.parent = Character.transform;
		Debug.Log(currentChar.localScale);
		currentChar.localScale = new Vector3(0.03f, 0.058f, 0.03f);
        currentChar.localRotation = Quaternion.identity;
        Screen_Sprite.transform.DOScale(0, 0.001f);
        Debug.Log(currentChar.localScale);
		currentChar.localPosition = Vector3.zero;
		Debug.Log(_choice.Dilemma);
        //Textbubble.text = _choice.Dilemma;
        Textbubble.DOText(_choice.Dilemma, 4, true, ScrambleMode.All);
        Screen_Sprite.transform.DOScale(1, 1f);
    }

    void SetChoice(Choice _choice) {
        DesicionButton.SetActive(false);
        ContinueButton.SetActive(true);
        switch (_choice.State) {
            case (State.Negative):
                Textbubble.DOText(_choice.NegativeDialog.text, 4, true, ScrambleMode.All);
                break;
            case (State.Positive):
                Textbubble.DOText(_choice.PositiveDialog.text, 4, true, ScrambleMode.All);
                break;
        }
    }

    public void Choose(int state) {
        EventManager.Choose_Choice(state);
    }
    public void Continue() {
        Choice.SetActive(false);
        EventManager.Day_Cycle();
        EventManager.Choice_Unload();
    }
}
