using UnityEngine;
using System.Collections;

public class Need {
	public int type; // 0 = social, 1 = financial, 2 = health, 3 = spiritual
	public string description;
	private string[] possibleDescriptions = {"I am lonely","I am poor","I am sick","I have doubts"};
	public float severity;
	public bool curable;

	public Need () {
		type = Random.Range(0,4);
		description = possibleDescriptions[type];
		severity = Random.Range(0f,0.1f);
		float f = Random.Range(0,2);
		curable = f == 0 ? true : false;
	}
}
