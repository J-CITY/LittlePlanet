using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoManager : MonoBehaviour
{
	public float slowmoFactor = 0.05f;
	public float slowmoLength = 2f;

	private void Update()
	{
		if (Time.timeScale != 1f) {
			Time.timeScale += (1f / slowmoLength ) * Time.deltaTime;
			if (Time.timeScale > 1f) {
				Time.timeScale = 1f;
			}
		}
	}

	public void Go()
	{
		Time.timeScale = slowmoFactor;
		Time.fixedDeltaTime = Time.timeScale * 0.02f;
		StartCoroutine(end());
	}

	IEnumerator end()
	{
		yield return new WaitForSeconds(slowmoLength);
		Time.timeScale = 1f;
	}
}
