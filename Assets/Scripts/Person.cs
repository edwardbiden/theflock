using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person {
	public float age;
	public string gender;
	public string name;
	public int wealth;
	private string[] malenames = {"Bob","Dave","John","Fred","Simon","Paul","Martin","Mark"};
	private string[] femalenames = {"Catherine","Sarah","Emma","Rose","Claire","Mary","Nicole"};
	private string[] surnames = {"Smith","Jones","Higgins","Davis","Eden","Roberts","Griffiths"};
	public float mood;
	// theology
	public float dogmatic;
	public float material;
	//needs
	public float social;
	public float money;
	public float health;
	public float spiritual;
	public float theologicalDistance;
	private float theologicalWeighting = 0.25f;
	public float neediness;
	private float needinessWeighting = 1f;
	public List<Need> needs;

	public Person () {
		age = Random.Range(18,80);
		gender = Random.Range(0,2) == 0 ? "m" : "f";
		string[] namelookup = gender == "m" ? malenames : femalenames;
		name = namelookup[Random.Range(0,namelookup.Length)];
		name += " " + surnames[Random.Range(0,surnames.Length)];
		wealth = Random.Range(1,11);

		dogmatic = Random.Range(0f,1f);
		material = Random.Range(0f,1f);

		needs = new List<Need>();
		int num = Random.Range(0,3);
		for(int i = 0; i < num; i++) {
			Need thisNeed = new Need();
			thisNeed.myPerson = this;//
			needs.Add(thisNeed);
		}

		Debug.Log(name + " " + gender + ":" + age.ToString("0") + "dogmatic: " + dogmatic.ToString("0.00") + "; material: " + material.ToString("0.00"));
		foreach(Need n in needs) {
			Debug.Log(n.description);
		}
		RefreshMood();
		if (mood >= 0.5f) {
			Members.s.body.Add(this);
		}
	} 

	public void RefreshMood() {
		// updates mood
		theologicalDistance = Mathf.Abs(dogmatic - Church.s.dogmatic);
		theologicalDistance += Mathf.Abs(material - Church.s.material);
		theologicalDistance = theologicalDistance * theologicalWeighting;

		// refresh impact of needs
		social = 0f;
		money  = 0f;
		health = 0f;
		spiritual = 0f;

		foreach(Need n in needs) {
			n.Refresh();
		}

		neediness = (social + money + health + spiritual) * needinessWeighting * -1f;

		mood = 1f - theologicalDistance - neediness;
		Debug.Log("mood: " + mood.ToString("0.00") + " need: " + neediness.ToString("0.00") + " beliefs: " + theologicalDistance.ToString("0.00"));
	}

	public void RefreshMembership() {
		// members leave Church if mood is too low
		if(mood < 0f) {
			Members.s.body.Remove(this);
			Debug.Log(name + " left the congregation");
		}
	}
}
