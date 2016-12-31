using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour {
	public int id;
	public GameObject me;
	public Button button;
	public int type; // 0 = community; 1 = moral; 2 = piety
	public string name;
	public string summary;
	public string a;
	public string b;

	// UI elements
	public Text summaryText;


	public void Setup () {
		summary = name + " needs " + Phone.s.typeName[type]+ " help";
		a = "be strict (" + Phone.s.typeName[type]+ "++)";
		b = "be tolerant (" + Phone.s.typeName[type]+ "--)";
		summaryText.text = summary;
	}

	public void SeeMessage() {
		Phone.s.confirmPanel.SetActive(false);
		Phone.s.messageTitleText.text = summary;
		Phone.s.aText.text = a;
		Phone.s.bText.text = b;
		Phone.s.type = type;
		Phone.s.currentMessageId = id;
		Phone.s.currentMessageObject = me;
		Game.s.GoToMessage();
	}
}
