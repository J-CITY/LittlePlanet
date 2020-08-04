using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
	float r = 10.8f;

	public GameObject player;

	public GameObject o1_1;
	public GameObject o1_2;
	public GameObject o2_1;
	public GameObject o2_2;
	public GameObject o3_1;
	public GameObject o3_2;
	public GameObject o4_1;
	public GameObject o4_2;
	public GameObject o5_1;
	public GameObject o5_2;

	// Start is called before the first frame update
	void Start()
    {
		var p = GameObject.Find("Player");
		if (p != null) {
			p.GetComponent<PlayerCollision>().dieEvent.AddListener(EndGameEventFun);
		}

	}

	float time = 0;
	void Update()
	{
		if (Config.isPause) {
			return;
		}
		if (PlayerCollision.isDie) {
			return;
		}

		time += Time.deltaTime;

		if (time > 5f) {
			time = 0;
			UpdateEnv();
		}
	}

	void UpdateEnv()
	{
		var d1 = Vector3.Distance(player.transform.position, o1_1.transform.position);

		if (d1 > r * 1.5f) {
			if (Random.Range(0f, 1f) > 0.5f) {
				o1_1.SetActive(true);
				o1_2.SetActive(false);
			} else {
				o1_1.SetActive(false);
				o1_2.SetActive(true);
			}
		}

		var d2 = Vector3.Distance(player.transform.position, o2_1.transform.position);

		if (d2 > r * 1.5f) {
			if (Random.Range(0f, 1f) > 0.5f) {
				o2_1.SetActive(true);
				o2_2.SetActive(false);
			} else {
				o2_1.SetActive(false);
				o2_2.SetActive(true);
			}
		}

		var d3 = Vector3.Distance(player.transform.position, o3_1.transform.position);

		if (d3 > r * 1.5f) {
			if (Random.Range(0f, 1f) > 0.5f) {
				o3_1.SetActive(true);
				o3_2.SetActive(false);
			} else {
				o3_1.SetActive(false);
				o3_2.SetActive(true);
			}
		}

		var d4 = Vector3.Distance(player.transform.position, o4_1.transform.position);

		if (d4 > r * 1.5f) {
			if (Random.Range(0f, 1f) > 0.5f) {
				o4_1.SetActive(true);
				o4_2.SetActive(false);
			} else {
				o4_1.SetActive(false);
				o4_2.SetActive(true);
			}
		}

		var d5 = Vector3.Distance(player.transform.position, o5_1.transform.position);

		if (d5 > r * 1.5f) {
			if (Random.Range(0f, 1f) > 0.5f) {
				o5_1.SetActive(true);
				o5_2.SetActive(false);
			} else {
				o5_1.SetActive(false);
				o5_2.SetActive(true);
			}
		}
	}


	void EndGameEventFun()
	{
		GameObject[] cubes = GameObject.FindGameObjectsWithTag("cube");
		foreach (GameObject cube in cubes)
			GameObject.Destroy(cube);

		GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");
		foreach (GameObject meteor in meteors)
			GameObject.Destroy(meteor);


	}
}
