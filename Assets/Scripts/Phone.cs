using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Phone : MonoBehaviour {
	public static Phone s;

	public GameObject messagePrefab;
	private int messageType;
	public int messageNum;
	public int memberNum;
	public int type;
	public int currentMessageId;
	public string[] typeName = {"community","moral","piety"};
	public GameObject[] startingMessages;
	public Dictionary<int, Message> allMessages = new Dictionary<int, Message>();
	public GameObject confirmPanel;
	public GameObject currentMessageObject;

	// UI elements
	public GameObject messagePanel;
	public Text todayText;
	public Text confirmText;
	public Text messageTitleText;
	public Text aText;
	public Text bText;

	void Awake () {
		s = this;
	}

	public void Generate () {
		foreach(GameObject g in startingMessages) Destroy(g);
		for(int i = 0; i < Phone.s.allMessages.Count; i++) {
			Destroy(Phone.s.allMessages[i].me);
		}
		allMessages = new Dictionary<int, Message>();
		int count = 0;
		while(count < messageNum) {
			GameObject thisSummary = Instantiate(messagePrefab) as GameObject;
			thisSummary.transform.SetParent(messagePanel.transform);
			thisSummary.transform.localScale = new Vector3(1, 1, 1);
			Message thisMessage = thisSummary.GetComponentInChildren<Message>();
			thisMessage.id = count;

			// determine message type
			messageType = Random.Range(0,3);
			memberNum = Random.Range(0,Congregation.s.members.Count);

			thisMessage.type = messageType;
			thisMessage.name = Congregation.s.members[memberNum].name;
			allMessages.Add(thisMessage.id, thisMessage);
			thisMessage.Setup();
			count++;
		}
	}

	public void pressA() {
		switch(type) {
		case 0:
			Church.s.community += 0.05f;
			break;
		case 1: 
			Church.s.moral += 0.05f;
			break;
		case 2:
			Church.s.piety += 0.05f;
			break;
		}
		confirmPanel.SetActive(true);
		confirmText.text = "You were strict\n" + typeName[type] + " has increased";
	}

	public void pressB() {
		switch(type) {
		case 0:
			Church.s.community -= 0.05f;
			break;
		case 1: 
			Church.s.moral -= 0.05f;
			break;
		case 2:
			Church.s.piety -= 0.05f;
			break;
		}
		confirmPanel.SetActive(true);
		confirmText.text = "You were tolerant\n" + typeName[type] + " has decreased";
	}

	public void Confirm() {
		allMessages.Remove(currentMessageId);
		Destroy(currentMessageObject);
		messageNum--;
		Office.s.phoneText.text = "Phone (" + Phone.s.messageNum.ToString() + ")";
		Office.s.NewAction();
		Game.s.GoToPhone();
	}
}
