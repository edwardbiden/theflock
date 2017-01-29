using UnityEngine;
using System.Collections;

public class Need {
	public int type; // 0 = social, 1 = money, 2 = health, 3 = spiritual
	public string description;
	private string[] possibleDescriptions = {"I am lonely","I am poor","I am sick","I have doubts"};
	public float severity; // maxImpact on mood
	public float met;
	public float impact;
	public Person myPerson;

	public Need () {
		type = Random.Range(0,4);
		description = possibleDescriptions[type];
		severity = Random.Range(0f,0.5f); // max number of needs is 2, so max neediness is 1
		met = 0;
	}

	public void Refresh() {
		switch(type) {
		case 0:
			met = Church.s.socialPermanent + Church.s.socialTemp;
			impact = severity - met;
			myPerson.social -= Mathf.Max(impact, 0f);
			break;
		case 1:
			met = Church.s.moneyPermanent + Church.s.moneyTemp;
			impact = severity - met;
			myPerson.money -= Mathf.Max(impact, 0f);
			break;
		case 2:
			met = Church.s.healthPermanent + Church.s.healthTemp;
			impact = severity - met;
			myPerson.health -= Mathf.Max(impact, 0f);
			break;
		case 3:
			met = Church.s.spiritualPermanent + Church.s.spiritualTemp;
			impact = severity - met;
			myPerson.spiritual -= Mathf.Max(impact, 0f);
			break;
		}
	}
}
