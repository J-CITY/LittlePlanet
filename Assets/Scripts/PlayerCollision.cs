using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour {

	public UnityEvent dieEvent;
	public UnityEvent dieSoundEvent;
	public UnityEvent winEvent;
	public UnityEvent loseEvent;

	public GameObject cubePref1;
	public GameObject cubePref2;

	public GameObject bus;

	public SlowMoManager slowmo;

	public int cubeCount = 150;

	public static bool isDie = true;
	public static float score = 0;
	public static bool isNewBest = false;

	PlayerData data = null;

	void Start()
	{
		data = SaveSystem.Load();
	}

	void Update()
	{
		if (Config.isPause) {
			return;
		}
		score += Time.deltaTime;
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.collider.tag == "Meteor" || col.collider.tag == "Env")
		{

			if (Config.isVibro)
				Vibration.Vibrate(100);
			bus.SetActive(false);

			for (int i = 0; i < cubeCount; ++i) {
				GameObject cube = null;
				if (Random.Range(0f, 1f) > 0.5f) {
					cube = Instantiate(cubePref1, transform.position, transform.rotation);
				} else {
					cube = Instantiate(cubePref2, transform.position, transform.rotation);
				}
				if (cube != null) {
					var rb_ = cube.AddComponent<Rigidbody>();
					rb_.AddExplosionForce(10f, cube.transform.position, 1f);
				}
			}

			Debug.Log("Die");
			isDie = true;

			dieSoundEvent.Invoke();

			StartCoroutine(EndGame());

			//save profile
			if (data != null) {
				if (data.score < score) {
					isNewBest = true;
					data = new PlayerData(score);
					SaveSystem.Save(data);
				}
			} else {
				isNewBest = true;
				data = new PlayerData(score);
				SaveSystem.Save(data);
			}
			slowmo.Go();
		}
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(3);
		dieEvent.Invoke();
		if (isNewBest) {
			winEvent.Invoke();
		} else {
			loseEvent.Invoke();
		}
	}

}
