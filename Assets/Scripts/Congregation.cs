using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Congregation : MonoBehaviour {
	public static Congregation s;
	public Person[] population;
	public List<Person> members;
	public int size = 100;

	public float moreCommunity;
	public float lessCommunity;
	public float moreMoral;
	public float lessMoral;
	public float morePiety;
	public float lessPiety;

	// UI elements
	public Image moreCommunityImage;
	public Image lessCommunityImage;
	public Image moreMoralImage;
	public Image lessMoralImage;
	public Image morePietyImage;
	public Image lessPietyImage;

	void Awake () {
		s = this;
	}
	
	public void Generate() {
		population = new Person[size];
		for(int i = 0; i < size; i++) {
			Person thisPerson = new Person();
			thisPerson.id = i;
			thisPerson.awareness = i/size;
			population[i] = thisPerson;
		}
	}

	public void Members() {
		members = new List<Person>();
		moreCommunity = 0f;
		lessCommunity = 0f;
		moreMoral = 0f;
		lessMoral = 0f;
		morePiety = 0f;
		lessPiety = 0f;
		foreach(Person p in population) {
			if( p.community[0] > Church.s.community) moreCommunity += 1.0f/size;
			if( p.community[1] < Church.s.community) lessCommunity += 1.0f/size;
			if( p.moral[0] > Church.s.moral) moreMoral += 1.0f/size;
			if( p.moral[1] < Church.s.moral) lessMoral += 1.0f/size;
			if( p.piety[0] > Church.s.piety) morePiety += 1.0f/size;
			if( p.piety[1] < Church.s.piety) lessPiety += 1.0f/size;

			if(Church.s.community >= p.community[0] && Church.s.community <= p.community[1] &&
				Church.s.moral >= p.moral[0] && Church.s.moral <= p.moral[1] &&
				Church.s.piety >= p.piety[0] && Church.s.piety <= p.piety[1] &&
				Church.s.awareness >= p.awareness) {
				members.Add(p);
			}
		}

		moreCommunityImage.fillAmount = moreCommunity;
		lessCommunityImage.fillAmount = lessCommunity;
		moreMoralImage.fillAmount = moreMoral;
		lessMoralImage.fillAmount = lessMoral;
		morePietyImage.fillAmount = morePiety;
		lessPietyImage.fillAmount = lessPiety;

		print("members: " + members.Count);
	}
}
