using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Congregation : MonoBehaviour {
	public static Congregation s;
	public Person[] population;
	public List<Person> members;

	void Awake () {
		s = this;
	}
	
	public void Generate(int size) {
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
		foreach(Person p in population) {
			if(Church.s.charity >= p.charity[0] && Church.s.charity <= p.charity[1] &&
				Church.s.community >= p.community[0] && Church.s.community <= p.community[1] &&
				Church.s.family >= p.family[0] && Church.s.family <= p.family[1] &&
				Church.s.piety >= p.piety[0] && Church.s.piety <= p.piety[1] &&
				Church.s.tolerance >= p.tolerance[0] && Church.s.tolerance <= p.tolerance[1] &&
				Church.s.awareness >= p.awareness) {
				members.Add(p);
			}
		}
		print("members: " + members.Count);
	}
}
