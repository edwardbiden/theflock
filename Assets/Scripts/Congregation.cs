using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Congregation : MonoBehaviour {
	public static Congregation s;
	public List<Person> population;
	public List<Person> members;
	public int size;

	public float dogmatic;
	public float material;
	public float social;
	public float financial;
	public float health;
	public float spiritual;

	// UI elements
	public Image dogmaticImageChurch;
	public Image dogmaticImageCongregation;
	public Image materialImageChurch;
	public Image materialImageCongregation;
	public Image socialImage;
	public Image financialImage;
	public Image healthImage;
	public Image spiritualImage;

	void Awake () {
		s = this;
	}
	
	public void Generate() {
		population = new List<Person>();
		for(int i = 0; i < size; i++) {
			Person thisPerson = new Person();
			thisPerson.id = i;
			thisPerson.awareness = i/size;
			population.Add(thisPerson);
		}
	}

	public void Members() {
		members = new List<Person>();
		dogmatic = 0f;
		material = 0f;
		social = 0f;
		financial = 0f;
		health = 0f;
		spiritual = 0f;
		foreach(Person p in population.ToArray()) {
			dogmatic += p.dogmatic / population.Count;
			material += p.material / population.Count;
			social += p.social / population.Count;
			financial += p.financial / population.Count;
			health += p.health / population.Count;
			spiritual += p.spiritual / population.Count;

			// run update function for Persons
			p.RefreshNeeds();
			p.RefreshMembership();
		}

		dogmaticImageChurch.fillAmount = Church.s.dogmatic;
		dogmaticImageCongregation.fillAmount = dogmatic;
		materialImageChurch.fillAmount = Church.s.material;
		materialImageCongregation.fillAmount = material;
		socialImage.fillAmount = social;
		financialImage.fillAmount = financial;
		healthImage.fillAmount = health;
		spiritualImage.fillAmount = spiritual;

		print("members: " + members.Count);
	}
}
