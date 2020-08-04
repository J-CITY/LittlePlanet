using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonSettingsController : MonoBehaviour
{

	public UnityEvent musicEvent;

	public Text txtMusic;
	public Text txtSound;
	public Text txtVibro;
	
	public void MusicOnPress()
	{
		Config.isMusic = !Config.isMusic;
		txtMusic.text = Config.isMusic ? "MUSIC" : " ̶M̶U̶S̶I̶C̶";
		musicEvent.Invoke();
		
	}

	public void SoundOnPress()
	{
		Config.isSound = !Config.isSound;
		txtSound.text = Config.isSound ? "SOUND" : "̶ ̶S̶O̶U̶N̶D̶";

	}

	public void VibroOnPress()
	{
		Config.isVibro = !Config.isVibro;
		txtVibro.text = Config.isVibro ? "VIBRO" : "̶ ̶V̶I̶B̶R̶O̶";
	}

}
