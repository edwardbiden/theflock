using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Church : MonoBehaviour {
	public static Church s;
	public int cash;
	public int capacity;
	public int capacityAmount; // amount to upgrade capacity
	// theology
	public float dogmatic;
	public float material;
	// needs
	public float social;
	public float financial;
	public float health;
	public float spiritual;

	// UI elements
	public Text cashText;
	public Text capacityText;
	public Text populationText;
	public Text memberText;
	public Button capacityButton;
	public Text capacityButtonText;

	void Awake () {
		s = this;
	}

	public void Generate() {
		cash = 200;
		capacity = 50;

		dogmatic = 0.5f;
		material = 0.5f;

		social = 0f;
		financial = 0f;
		health = 0f;
		spiritual = 0f;

		capacityAmount = 100;
	}

	public void Refresh() {
		cashText.text = "Cash: " + cash.ToString();
		capacityText.text = "Capacity: " + capacity.ToString();
		populationText.text = "Population: " + Congregation.s.population.Count.ToString();
		memberText.text = "Membership: " + Congregation.s.members.Count.ToString();
		capacityButton.interactable = cash >= capacityAmount ? true : false;
		capacityButtonText.text = "Capacity ++ \n$" + capacityAmount.ToString("#,##0");
	}

	public void Capacity() {
		cash -= capacityAmount;
		capacity += 5;
		capacityAmount = capacityAmount*2;
		Refresh();
	}
}
