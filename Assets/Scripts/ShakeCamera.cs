using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour {
	IEnumerable Go(float duration, float magnitude) {
		Vector3 originalPos = transform.localPosition;

		float elapsed = 0f;

		while (elapsed < duration) {
			float x = Random.Range(-1f, 1f) * magnitude;
			float y = Random.Range(-1f, 1f) * magnitude;

			transform.localPosition = new Vector3(x, originalPos.y, y);

			elapsed += Time.deltaTime;

			yield return null;
		}

		transform.localPosition = originalPos;
	}
}
