using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Members : MonoBehaviour {
	public static Members s;
	public List<Person> body;
	public int size;

	public float mood;
	public float dogmatic;
	public float material;
	public float social;
	public float money;
	public float health;
	public float spiritual;

	// UI elements
	public Image dogmaticImageChurch;
	public Image dogmaticImageCongregation;
	public Image materialImageChurch;
	public Image materialImageCongregation;
	public Image moodImage;
	public Image socialImage;
	public Image financialImage;
	public Image healthImage;
	public Image spiritualImage;
	private float magnifier = 16f; // av. 1 need pp; av. 0.25f severity; 4 types of needs

	void Awake () {
		s = this;
	}
	
	public void Generate() {
		body = new List<Person>();
		for(int i = 0; i < size; i++) {
			Person thisPerson = new Person();
		}
	}

	public void Refresh() {
		mood = 0f;
		dogmatic = 0f;
		material = 0f;
		social = 1f;
		money = 1f;
		health = 1f;
		spiritual = 1f;
		foreach(Person p in body.ToArray()) {
			// run update function for Persons
			p.RefreshMood();
			mood += p.mood / body.Count;
			dogmatic += p.dogmatic / body.Count;
			material += p.material / body.Count;
			social += (magnifier * p.social) / body.Count;
			money += (magnifier * p.money) / body.Count;
			health += (magnifier * p.health) / body.Count;
			spiritual += (magnifier * p.spiritual) / body.Count;

			p.RefreshMembership();
		}

		dogmaticImageChurch.fillAmount = Church.s.dogmatic;
		dogmaticImageCongregation.fillAmount = dogmatic;
		materialImageChurch.fillAmount = Church.s.material;
		materialImageCongregation.fillAmount = material;
		moodImage.fillAmount = mood;
		socialImage.fillAmount = social;
		financialImage.fillAmount = money;
		healthImage.fillAmount = health;
		spiritualImage.fillAmount = spiritual;

		print("members: " + body.Count + "; money: " + money.ToString("0.0000"));
	}
}
