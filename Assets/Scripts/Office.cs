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
	}

	public void Tea() {
		NewAction();
		feedback.text = "Awareness + 1%";
	}

	public void TV() {
		NewAction();
		Service.s.sermonEffectiveness += Random.Range(0,0.1f);
		int effectivenessShown = Mathf.FloorToInt(Service.s.sermonEffectiveness * 100);
		feedback.text = "collection effectiveness: " + effectivenessShown.ToString() + "%";
	}

	public void Bible() {
		NewAction();
		feedback.text = "you are feeling very devout";
	}

	public void Hospital() {
		NewAction();
		feedback.text = "good deeds +1";
	}

	public void NewAction() {
		feedback.text = "";
		dayOfWeek++;
		today = weekdays[dayOfWeek];
		todayText.text = today;
		Phone.s.todayText.text = today;
		if(dayOfWeek == 5) foreach(Button b in actionButtons) b.interactable = false;
		if(dayOfWeek == 5) foreach(KeyValuePair<int, Message> myMessage in Phone.s.allMessages) Phone.s.allMessages[myMessage.Key].button.interactable = false;
		proceed.interactable = true;
	}
}
