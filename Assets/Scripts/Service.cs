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
	public float sermonEffectiveness;

	// UI elements
	public GameObject pewPanel;
	public Text feedback;
	public Button proceed;

	void Awake () {
		s = this;
	}
	
	public void BeginService() {
		foreach(GameObject g in attendees) Destroy(g);
		attendees = new List<GameObject>();
		pews = 0;
		maxCongregation = Mathf.Min(Congregation.s.members.Count, Church.s.capacity);
		print("attendees this week: " + maxCongregation);
		StartCoroutine(FillPews());
		feedback.text = "";
		proceed.interactable = false;
	}

	IEnumerator FillPews() {
		int collection = 0;
		while(pews < maxCongregation) {
			GameObject thisPerson = Instantiate(attendee) as GameObject;
			thisPerson.transform.SetParent(pewPanel.transform);
			thisPerson.transform.localScale = new Vector3(1, 1, 1);
			Text[] myName = thisPerson.GetComponentsInChildren<Text>();
			myName[0].text = Congregation.s.members[pews].name;
			attendees.Add(thisPerson);
			collection += Congregation.s.members[pews].wealth;
//			print(myName[0].text + " " + Congregation.s.members[pews].gender + ":" + Congregation.s.members[pews].age.ToString("0"));
			pews++;
			yield return new WaitForSeconds(0.05f);
		}
		int finalCollection = Mathf.FloorToInt(collection * sermonEffectiveness);
		Church.s.cash += finalCollection;
		feedback.text = "Collection: $" + finalCollection.ToString();
		int seatsEmpty = Mathf.Max(Church.s.capacity - Congregation.s.members.Count, 0);
		feedback.text += "\n" + seatsEmpty.ToString() + " pews empty";
		proceed.interactable = true;
	}

}
