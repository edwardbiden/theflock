using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Office : MonoBehaviour {
	public static Office s;
	private string[] weekdays = {"Monday","Tuesday","Wednesday","Thursday","Friday", "Saturday"};
	private string today;
	private int dayOfWeek;

	// UI elements
	public Text todayText;
	public Text feedback;
	public Text phoneText;
	public Button[] actionButtons;
	public Button proceed;

	void Awake () {
		s = this;
	}

	public void BeginWeek() {
		dayOfWeek = 0;
		today = weekdays[dayOfWeek];
		todayText.text = today;
		Phone.s.todayText.text = today;
		feedback.text = "";
		Phone.s.messageNum = Random.Range(1,4);
		phoneText.text = "Phone (" + Phone.s.messageNum.ToString() + ")";
		Phone.s.Generate();
		Service.s.sermonEffectiveness = 1;
		foreach(Button b in actionButtons) b.interactable = true;
		proceed.interactable = false;

		// reset temp effects
		Church.s.ResetTempEffects();
	}

	public void Tea() {
		NewAction();
		Church.s.socialTemp += 0.03f;
		feedback.text = "Temp Social boost: " + Church.s.socialTemp.ToString("0.00");
	}

	public void Fundraise() {
		NewAction();
		Church.s.moneyTemp += 0.03f;
		feedback.text = "Temp Money boost: " + Church.s.moneyTemp.ToString("0.00");
	}

	public void Hospital() {
		NewAction();
		Church.s.healthTemp += 0.03f;
		feedback.text = "Temp Health boost: " + Church.s.healthTemp.ToString("0.00");
	}

	public void Bible() {
		NewAction();
		Church.s.spiritualTemp += 0.03f;
		feedback.text = "Temp Spiritual boost: " + Church.s.spiritualTemp.ToString("0.00");
	}

	public void NewAction() {
		feedback.text = "";
		dayOfWeek++;
		today = weekdays[dayOfWeek];
		todayText.text = today;
		Phone.s.todayText.text = today;
		if(dayOfWeek == 5) {
			foreach(Button b in actionButtons) b.interactable = false;
			foreach(KeyValuePair<int, Message> myMessage in Phone.s.allMessages) Phone.s.allMessages[myMessage.Key].button.interactable = false;
			proceed.interactable = true;
		}
	}
}
