using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Church : MonoBehaviour {
	public static Church s;
	public int cash;
	public int value;
	public int halos;
	public float awareness;

	public float charity;
	public float community;
	public float family;
	public float piety;
	public float tolerance;

	public Text cashText;
	public Text congregationText;
	public Text halosText;

	void Awake () {
		s = this;
	}

	public void Generate() {
		cash = 200;
		value = 5000;
		halos = 0;
		awareness = 0.1f;

		charity = 0.5f;
		community = 0.5f;
		family = 0.5f;
		piety = 0.5f;
		tolerance = 0.5f;
	}

	public void UpdateText() {
		cashText.text = "Cash: " + cash.ToString();
		congregationText.text = "Congregation: " + Congregation.s.members.Count.ToString();
		halosText.text = "Good deeds: " + halos.ToString();
	}
}
