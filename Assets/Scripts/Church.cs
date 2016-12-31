using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Church : MonoBehaviour {
	public static Church s;
	public int cash;
	public int value;
	public int halos;
	public int capacity;
	public int capacityAmount;
	public int marketingAmount;
	public float awareness;
	public float community;
	public float moral;
	public float piety;

	// UI elements
	public Text cashText;
	public Text congregationText;
	public Text halosText;
	public Text awarenessText;
	public Button capacityButton;
	public Button marketingButton;
	public Text capacityButtonText;
	public Text marketingButtonText;

	void Awake () {
		s = this;
	}

	public void Generate() {
		cash = 200;
		value = 5000;
		halos = 0;
		capacity = 5;
		awareness = 0.1f;

		community = 0.4f;
		moral = 0.4f;
		piety = 0.4f;

		capacityAmount = 100;
		marketingAmount = 100;
	}

	public void Refresh() {
		cashText.text = "Cash: " + cash.ToString();
		congregationText.text = "Congregation: " + Congregation.s.members.Count.ToString();
		halosText.text = "Good deeds: " + halos.ToString();
		int awarenessPercent = Mathf.FloorToInt(awareness * 100);
		awarenessText.text = "Awareness: " + awarenessPercent.ToString() + "%";
		capacityButton.interactable = cash >= capacityAmount ? true : false;
		marketingButton.interactable = cash >= marketingAmount ? true : false;
		capacityButtonText.text = "Capacity ++ \n$" + capacityAmount.ToString("#,##0");
		marketingButtonText.text = "Awareness ++ \n$" + marketingAmount.ToString("#,##0");
	}

	public void Capacity() {
		cash -= capacityAmount;
		capacity += 5;
		capacityAmount = capacityAmount*2;
		Refresh();
	}

	public void Marketing() {
		cash -= marketingAmount;
		awareness += 0.05f;
		if(awareness > 1) awareness = 1f;
		marketingAmount = marketingAmount*2;
		Refresh();
	}
}
