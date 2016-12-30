using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Service : MonoBehaviour {
	public static Service s;
	public List<GameObject> attendees;
	public GameObject attendee;
	private int pews;
	public float length;
	private int maxCongregation;

	// UI elements
	public GameObject pewPanel;
	public Text feedback;
	public Image timeImage;
	public Button[] actionButtons;
	public Button proceed;

	void Awake () {
		s = this;
	}
	
	public void BeginService() {
		foreach(GameObject g in attendees) Destroy(g);
		attendees = new List<GameObject>();
		pews = 0;
		maxCongregation = Mathf.Min(Congregation.s.members.Count, 100, Church.s.capacity);
		print("attendees this week: " + maxCongregation);
		StartCoroutine(FillPews());
		feedback.text = "";
		timeImage.fillAmount = 0;
		proceed.interactable = false;
		foreach(Button b in actionButtons) b.interactable = false;
	}

	IEnumerator FillPews() {
		while(pews < maxCongregation) {
			GameObject thisPerson = Instantiate(attendee) as GameObject;
			thisPerson.transform.SetParent(pewPanel.transform);
			thisPerson.transform.localScale = new Vector3(1, 1, 1);
			Text[] myName = thisPerson.GetComponentsInChildren<Text>();
			myName[0].text = Congregation.s.members[pews].name;
			attendees.Add(thisPerson);
//			print(myName[0].text + " " + Congregation.s.members[pews].gender + ":" + Congregation.s.members[pews].age.ToString("0"));
			pews++;
			yield return new WaitForSeconds(0.05f);
		}
		Sermon();
	}

	public void Convert() {
		Church.s.awareness += 0.01f;
		feedback.text = "awareness ++";
		TextOn();
	}

	public void Love() {
		Church.s.halos += pews;
		feedback.text = "good deeds ++";
		TextOn();
	}

	public void Donate() {
		foreach(Person p in Congregation.s.members) Church.s.cash += p.wealth;
		feedback.text = "cash ++";
		TextOn();
	}

	public void Sermon() {
		foreach(Button b in actionButtons) b.interactable = true;
		length = 0;
		StartCoroutine(SermonTick());
	}

	IEnumerator SermonTick() {
		while (length <= 1f) {
			timeImage.fillAmount = length;
			length += 0.01f;

			Color col = feedback.color;
			col.a -= 0.1f;
			feedback.color = col;
			yield return new WaitForSeconds(0.05f);
		}
		foreach(Button b in actionButtons) b.interactable = false;
		proceed.interactable = true;
	}

	public void TextOn() {
		Color col = feedback.color;
		col.a = 1;
		feedback.color = col;
	}
}
