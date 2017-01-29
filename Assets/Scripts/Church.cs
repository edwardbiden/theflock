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
	public float socialPermanent;
	public float moneyPermanent;
	public float healthPermanent;
	public float spiritualPermanent;
	public float socialTemp;
	public float moneyTemp;
	public float healthTemp;
	public float spiritualTemp;

	// UI elements
	public Text cashText;
	public Text capacityText;
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

		socialPermanent = 0f;
		moneyPermanent = 0f;
		healthPermanent = 0f;
		spiritualPermanent = 0f;
		ResetTempEffects();

		capacityAmount = 100;
	}

	public void Refresh() {
		cashText.text = "Cash: " + cash.ToString();
		capacityText.text = "Capacity: " + capacity.ToString();
		memberText.text = "Membership: " + Members.s.body.Count.ToString();
		capacityButton.interactable = cash >= capacityAmount ? true : false;
		capacityButtonText.text = "Capacity ++ \n$" + capacityAmount.ToString("#,##0");
	}

	public void Capacity() {
		cash -= capacityAmount;
		capacity += 5;
		capacityAmount = capacityAmount*2;
		Refresh();
	}

	public void ResetTempEffects() {
		socialTemp = 0f;
		moneyTemp = 0f;
		healthTemp = 0f;
		spiritualTemp = 0f;
	}
}
