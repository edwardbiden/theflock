using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person {
	public int id;
	public float age;
	public string gender;
	public string name;
	public int wealth;
	private string[] malenames = {"Bob","Dave","John","Fred","Simon","Paul","Martin","Mark"};
	private string[] femalenames = {"Catherine","Sarah","Emma","Rose","Claire","Mary","Nicole"};
	private string[] surnames = {"Smith","Jones","Higgins","Davis","Eden","Roberts","Griffiths"};
	public float awareness;
	public bool attendee;
	public float happiness;
	// theology
	public float dogmatic;
	public float material;
	//needs
	public float social;
	public float financial;
	public float health;
	public float spiritual;
	public float neediness;
	public float theologicalDistance;
	public List<Need> needs;

	public Person () {
		age = Random.Range(18,80);
		gender = Random.Range(0,2) == 0 ? "m" : "f";
		string[] namelookup = gender == "m" ? malenames : femalenames;
		name = namelookup[Random.Range(0,namelookup.Length)];
		name += " " + surnames[Random.Range(0,surnames.Length)];
		wealth = Random.Range(1,11);
		attendee = false;

		dogmatic = Random.Range(0f,1f);
		material = Random.Range(0f,1f);
		social = 0f;
		financial = 0f;
		health = 0f;
		spiritual = 0f;

		needs = new List<Need>();
		int num = Random.Range(1,4);
		for(int i = 0; i < num; i++) {
			Need thisNeed = new Need();
			needs.Add(thisNeed);
		}

		Debug.Log(name + " " + gender + ":" + age.ToString("0") + "dogmatic: " + dogmatic.ToString("0.00") + "; material: " + material.ToString("0.00"));
		foreach(Need n in needs) {
			Debug.Log(n.description);
		}
		RefreshNeeds();
		RefreshNeeds();
	} 

	public void RefreshNeeds() {
		theologicalDistance = Mathf.Abs(dogmatic - Church.s.dogmatic);
		theologicalDistance += Mathf.Abs(material - Church.s.material);

		foreach(Need n in needs) {
			switch(n.type)
			{
			case 0:
				social += n.severity;
				break;
			case 1:
				financial += n.severity;
				break;
			case 2:
				health += n.severity;
				break;
			case 3:
				spiritual += n.severity;
				break;
			}
		}
		neediness = social + financial + health + spiritual;
		if(attendee) happiness -=neediness;
	}

	public void RefreshMembership() {
		if(!attendee && theologicalDistance < neediness) {
			happiness = 1f;
			attendee = true;
			Congregation.s.members.Add(this);
			Debug.Log(name + " joined the congregation");
		}
		if(attendee && happiness < 0) {
			attendee = false;
			Congregation.s.members.Remove(this);
			Congregation.s.population.Remove(this);
			Debug.Log(name + " left the congregation");
		}
	}
	// update function
	// if neediness > theologicalDistance >> join congregation
	// once joined, if neediness + theologicalDistance > belonging >> leave congregatinon
	// update neediness level based on needs
	// 
}
