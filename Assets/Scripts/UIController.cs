using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	public GameObject textLogo;
	public GameObject textScore;
	public GameObject textTip;
	public GameObject startBtn;
	public GameObject joystick;

	public GameObject buttons;
	public GameObject pauseBtn;
	public GameObject playBtn;
	public GameObject textPauseTip;


	public GameObject scoreInGame;
	public GameObject lineInGame;

	//$%^$^^$%^$^
	public GameObject bus;

	private Text scoreText;

	// Start is called before the first frame update
	void Start()
    {
		textScore.SetActive(false);
		scoreText = scoreInGame.GetComponent<Text>();

		scoreInGame.SetActive(false);
		lineInGame.SetActive(false);

		var p = GameObject.Find("Player");
		if (p != null) {
			p.GetComponent<PlayerCollision>().dieEvent.AddListener(EndGameEventFun);
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (PlayerCollision.isDie) {
			return;
		}
		scoreText.text = "SCORE: " + RoundUp(PlayerCollision.score, 2);
	}

	public float RoundUp(float number, int digits)
	{
		float factor = (float)Math.Pow(10, digits);
		return (float)Math.Ceiling(number * factor) / factor;
	}

	public void StartBtnClick()
	{
		startBtn.SetActive(false);
		textTip.SetActive(false);
		textScore.SetActive(false);
		textLogo.SetActive(false);
		buttons.SetActive(false);

		scoreInGame.SetActive(true);
		lineInGame.SetActive(true);
		joystick.SetActive(true);
		pauseBtn.SetActive(true);


		PlayerCollision.isDie = false;
		PlayerCollision.score = 0f;

		bus.SetActive(true);

		bus.transform.parent.transform.position = new Vector3(0f, 11.5f, 0f);
		var rb = bus.transform.parent.gameObject.GetComponent<Rigidbody>();

		rb.velocity = new Vector3(0f, 0f, 0f);
		rb.angularVelocity = new Vector3(0f, 0f, 0f);
		bus.transform.parent.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
	}

	void EndGameEventFun()
	{
		startBtn.SetActive(true);
		textTip.SetActive(true);
		textScore.SetActive(true);
		textLogo.SetActive(true);
		buttons.SetActive(true);

		scoreInGame.SetActive(false);
		lineInGame.SetActive(false);
		joystick.SetActive(false);
		pauseBtn.SetActive(false);

		textScore.GetComponent<CurvedText>().text = PlayerCollision.isNewBest ? "NEW BEST: " : "SCORE: " + RoundUp(PlayerCollision.score, 2).ToString();
		PlayerCollision.isNewBest = false;
	}

	public void OnPressPause()
	{
		Config.isPause = !Config.isPause;

		if (Config.isPause) {
			joystick.SetActive(false);
			pauseBtn.SetActive(false);

			buttons.SetActive(true);
			playBtn.SetActive(true);
			textPauseTip.SetActive(true);
		} else {
			
			joystick.SetActive(true);
			pauseBtn.SetActive(true);

			buttons.SetActive(false);
			playBtn.SetActive(false);
			textPauseTip.SetActive(false);

			var rb = bus.transform.parent.gameObject.GetComponent<Rigidbody>();

			rb.velocity = new Vector3(0f, 0f, 0f);
			rb.angularVelocity = new Vector3(0f, 0f, 0f);
			bus.transform.parent.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		}

	}
}
