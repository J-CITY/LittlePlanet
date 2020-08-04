using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Meteor : FauxGravityBody {

	public UnityEvent dieEvent;

	public GameObject cubePref;

	public SphereCollider sphereCol;
	//public ParticleSystem trail;

	private Vector3 normalizeDirection;

	bool isDie = false;

	void Start()
	{
		normalizeDirection = (Vector3.zero - transform.position).normalized;

		dieEvent.AddListener(GameObject.Find("AudioController").GetComponent<AudioController>().PlayMeteorSound);
	}

	void OnCollisionEnter(Collision col)
	{

		if (isDie)
			return;

		isDie = true;

		if (Config.isVibro)
			Vibration.Vibrate(10);

		GetComponent<Rigidbody>().isKinematic = true;

		for (int i = 0; i < 20; ++i) {
			var cube = Instantiate(cubePref, transform.position, transform.rotation);
			
			if (cube != null) {
				var rb_ = cube.AddComponent<Rigidbody>();
				rb_.mass = 0.0001f;
				rb_.AddExplosionForce(1f, cube.transform.position, 2f);
			}
		}

		if (Config.isSound) {
			dieEvent.Invoke();
		}

		//sphereCol.enabled = false;
		//trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

		enabled = false;

		Destroy(gameObject, 2f);
	}

	void Update()
	{
		if (Config.isPause) {
			return;
		}
		transform.position += normalizeDirection * 4f * Time.deltaTime;
	}

}
