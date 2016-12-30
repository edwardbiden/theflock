using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Office : MonoBehaviour {
	public static Office s;
	private string[] weekdays = {"Monday","Tuesday","Wednesday","Thursday","Friday", "Saturday"};
	private string today;
	private int dayOfWeek;

	// UI elements
	public Text todayText;
	public Text feedback;
	public Button[] actionButtons;
	public Button proceed;


	void Awake () {
		s = this;
	}

	public void BeginWeek() {
		dayOfWeek = 0;
		today = weekdays[dayOfWeek];
		todayText.text = today;
		feedback.text = "";
		foreach(Button b in actionButtons) b.interactable = true;
		proceed.interactable = false;
	}

	public void Phone() {
		NewAction();
	}

	public void Tea() {
		NewAction();
		Church.s.community += 0.02f;
		feedback.text = "community ++";
	}

	public void TV() {
		NewAction();
		Church.s.tolerance += 0.02f;
		feedback.text = "tolerance ++";
	}

	public void Bible() {
		NewAction();
		Church.s.piety += 0.02f;
		feedback.text = "piety ++";
	}

	public void Hospital() {
		NewAction();
		Church.s.awareness += 0.02f;
		feedback.text = "awareness ++";
	}

	public void NewAction() {
		feedback.text = "";
		dayOfWeek++;
		today = weekdays[dayOfWeek];
		todayText.text = today;
		if(dayOfWeek == 5) foreach(Button b in actionButtons) b.interactable = false;
		proceed.interactable = true;
	}
}
