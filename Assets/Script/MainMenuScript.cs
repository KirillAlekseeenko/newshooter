﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class MainMenuScript : MonoBehaviour {






	public bool isAudioLocked;
	public float musicVolume;
	public float effectsVolume;
	public AudioClip backgroundMusic;

	public GameObject MainPanel;
	public GameObject AudioPanel;
	public GameObject InfoPanel;
	public GameObject LevelPanel;
	public GameObject LevelManager;

	public Toggle audioToggle;
	public Slider effectsSlider;
	public Slider musicSlider;
	public Slider audioSlider;

	// animators
	public Animator titlePanel;
	public List<Animator> mainMenuButtons;
	public List<Animator> audioUI;
	public List<Animator> levelUI;



	[SerializeField]
	private float transition_time;
	private float animation_time = 0.5f;
	//Main Panel

	void Awake()
	{
		Application.targetFrameRate = 60;
	}

	void Start()
	{
		

		SoundManager.instance.PlayMusic (backgroundMusic);
		
		if(PlayerPrefs.HasKey("AUDIO"))
		{
			AudioInfo audioInfo = JsonUtility.FromJson<AudioInfo>(PlayerPrefs.GetString("AUDIO"));

				audioToggle.isOn = audioInfo.muted;
				effectsSlider.value = audioInfo.effectsVolume;
				musicSlider.value = audioInfo.musicVolume;
				audioSlider.value = audioInfo.audioVolume;


		}
		//TEST

		if (PlayerPrefs.HasKey ("TEST") && PlayerPrefs.GetString("TEST") != "{}") {

			var jsonString = PlayerPrefs.GetString ("TEST");

			LevelManagerScript.Level level = JsonUtility.FromJson<LevelManagerScript.Level> (jsonString);

			EnemySizeTextBox.text = level.enemySize.ToString ();
			EnemySpeedTextBox.text = level.enemySpeed.ToString ();
			SpawnRateTextBox.text = level.spawnRate.ToString ();
			EnemyTypeDropdown.value = (int)level.enemyType;

			GunSpeedTextBox.text = level.gunSpeedModifier.ToString ();
			ReloadTextBox.text = level.gunReloadModifier.ToString ();
			BulletSpeedTextBox.text = level.bulletSpeedModifier.ToString ();
			FriendSpawnChanceTextBox.text = level.friendSpawnChance.ToString ();
			ArmoredSpawnChanceTextBox.text = level.armoredSpawnChance.ToString ();
			ArmedSpawnChanceTextBox.text = level.armedSpawnChance.ToString ();
		} 
	}

	// animations

	private IEnumerator mainPanelSlideOut(float transition, Action<bool> f1, bool arg)
	{
		for(int i = 0;i < mainMenuButtons.Count;i++) {
			var anim = mainMenuButtons[i];
			anim.SetBool ("isHidden", true);

		}
		yield return new WaitForSeconds (transition);
		MainPanel.SetActive (false);
		f1 (arg);
	}
	private IEnumerator mainPanelSlideOut(float transition) // for level panel
	{
		for(int i = 0;i < mainMenuButtons.Count;i++) {
			var anim = mainMenuButtons[i];
			anim.SetBool ("isHidden", true);

		}
		yield return new WaitForSeconds (transition);
		MainPanel.SetActive (false);
		LevelPanel.SetActive (true);
		yield return new WaitForSeconds (animation_time);

		// level buttons
		StartCoroutine(LevelManager.GetComponent<LevelManagerScript>().levelButtonsAppear());

	}
	private IEnumerator audioPanelSlideOut(float transition)
	{
		for (int i = 0; i < audioUI.Count; i++) {
			audioUI [i].SetBool ("isHidden", true);
		}
		yield return new WaitForSeconds (transition);
		AudioPanel.SetActive (false);
		MainPanel.SetActive (true);
	}
	private IEnumerator levelPanelSlideOut(float transition)
	{
		for (int i = 0; i < levelUI.Count; i++)
			levelUI [i].SetBool ("isHidden", true);

		yield return new WaitForSeconds (transition);
		LevelManager.GetComponent<LevelManagerScript>().levelButtonsDisappear ();
		LevelPanel.SetActive (false);
		MainPanel.SetActive (true);
	}


	//

	public void startButtonClick()
	{
		StartCoroutine(mainPanelSlideOut (transition_time));
		//MainPanel.SetActive (false);
		//LevelPanel.SetActive (true);
	}
	public void audioButtonClick()
	{
		StartCoroutine(mainPanelSlideOut (transition_time, AudioPanel.SetActive, true));
		//MainPanel.SetActive (false);
		//AudioPanel.SetActive (true);
	}
	public void infoButtonClick()
	{
		StartCoroutine(mainPanelSlideOut (transition_time,	testPanel.SetActive, true));
		//StartCoroutine(mainPanelSlideOut (transition_time, InfoPanel.SetActive, true));!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//MainPanel.SetActive (false);
		//InfoPanel.SetActive (true);
	}

	//Audio Panel

	public void backLevelButtonClick()
	{
		StartCoroutine(levelPanelSlideOut(transition_time));
	}

	public void backInfoButtonClick()
	{
		InfoPanel.SetActive (false);
		MainPanel.SetActive (true);
	}

	public void backAudioButtonClick()
	{
		AudioInfo audioInfo = new AudioInfo (audioToggle.isOn, audioSlider.value, musicSlider.value, effectsSlider.value);
		PlayerPrefs.SetString ("AUDIO", JsonUtility.ToJson (audioInfo));

		StartCoroutine (audioPanelSlideOut (transition_time));
	}

	public void onMusicSliderValueChanged()
	{
		SoundManager.instance.musicSource.volume = musicSlider.value;
	}
	public void onEffectsSliderValueChanged()
	{
		SoundManager.instance.effectsSource.volume = effectsSlider.value;
	}
	public void onAudioSliderValueChanged()
	{
		AudioListener.volume = audioSlider.value;
	}
	public void onAudioToggleValueChanged()
	{
		if (audioToggle.isOn)
			AudioListener.volume = 0;
		else
			AudioListener.volume = 1.0f;
	}

	//Info Panel
	 

	//TestUI
	[Header("TestUI")]

	public GameObject testPanel;
	public InputField EnemySizeTextBox;
	public InputField EnemySpeedTextBox;
	public InputField SpawnRateTextBox;
	public Dropdown EnemyTypeDropdown;

	public InputField GunSpeedTextBox;
	public InputField ReloadTextBox;
	public InputField BulletSpeedTextBox;

	public InputField FriendSpawnChanceTextBox;
	public InputField ArmoredSpawnChanceTextBox;
	public InputField ArmedSpawnChanceTextBox;

		
}


	
[System.Serializable] 
public class AudioInfo
{
	public bool muted;
	public float audioVolume;
	public float musicVolume;
	public float effectsVolume;

	public AudioInfo(bool m, float aV, float mV, float eV)
	{
		muted = m;
		audioVolume = aV;
		musicVolume = mV;
		effectsVolume = eV;
	}
	public AudioInfo()
	{
		muted = false;
		audioVolume = 1.0f;
		musicVolume = 1.0f;
		effectsVolume = 1.0f;
	}
}
