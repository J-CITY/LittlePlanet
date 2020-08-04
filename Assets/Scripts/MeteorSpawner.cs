using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

	public GameObject meteorPrefab;
	public float distance = 20f;

	public float spawnTime = 5f;

	void Start ()
	{
	}

	void SpawnMeteor()
	{
		Vector3 pos = Random.onUnitSphere * distance;
		Instantiate(meteorPrefab, pos, Quaternion.identity);
	}

	float time = 3;
	void Update()
	{
		if (Config.isPause) {
			return;
		}
		if (PlayerCollision.isDie) {
			return;
		}

		time += Time.deltaTime;

		var t = (spawnTime - PlayerCollision.score / 10f);
		if (time > (t > 0.5f ? t : 0.5f)) {
			time = 0;
			SpawnMeteor();
		}
	}

}
