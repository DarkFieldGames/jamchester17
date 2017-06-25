using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FadeIn : MonoBehaviour {

	[Range(0.5f, 5f)] public float Scale = 5;

	public float MaxScale = 5;

	private RectTransform rectangle;

	public float Boost = 0;

	// Use this for initialization
	void Awake () {
		rectangle = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

		var player = GameObject.FindGameObjectWithTag("Player");

		if (player == null)
			return;

		var properties = player.GetComponent<PlayerProperties>();

		var percentage = properties.health / properties.maxHealth;

		Scale = Mathf.Clamp(4.5f * (Mathf.Sin(percentage))  + 0.5f - Boost, 0.5f, MaxScale);

		rectangle.localScale = new Vector3(Scale, Scale);

		if (percentage == 0)
		{
			StartCoroutine("Expand");
		}
			
	}

	IEnumerator Expand()
	{
		for (float f = 0f; f < 4.5; f = f + 0.05f)
		{
			Boost = 4.5f - f;
			yield return new WaitForSeconds(0.015f);
		}
	}
}
