using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseSwitcher : MonoBehaviour {

	public Pose[] Poses = new Pose[0];

	public Color Color = Color.blue;

	private SpriteRenderer body;
	private SpriteRenderer left;
	private SpriteRenderer right;
	private Light glow;
	

	
	void Awake () {
		body = GetComponent<SpriteRenderer>();
		left = transform.Find("left hand").gameObject.GetComponent<SpriteRenderer>();
		right = transform.Find("right hand").gameObject.GetComponent<SpriteRenderer>();
		glow = transform.GetComponent<Light>();
	}
	

	void Start () {
		if (CurrentType == PoseType.death)
		{
			CurrentType = PoseType.damage;
			SetPose(PoseType.death);

		}
		else
		{
			CurrentType = PoseType.damage;
			SetPose(PoseType.idle);
		}
	}

	public PoseType CurrentType;

	public void SetPose(PoseType type)
	{
		if (type == CurrentType)
			return;
		else
			CurrentType = type;

		Pose selected = null;

		foreach (Pose pose in Poses)
		{
			if(type == pose.poseType)
			{
				selected = pose;
				break;
			}
		}

		if (selected == null)
			return;

		body.sprite = selected.body;
		left.sprite = selected.leftHand;
		right.sprite = selected.rightHand;

		body.color = Color;
		left.color = Color;
		right.color = Color;
		glow.color = Color; 
	}
}

[System.Serializable]
public enum	PoseType
{
	carry,
	jump,
	idle,
	death,
	damage
}

[System.Serializable]
public class Pose
{
	public PoseType poseType;
	public Sprite body;
	public Sprite leftHand;
	public Sprite rightHand;
}
