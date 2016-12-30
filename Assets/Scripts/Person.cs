﻿using UnityEngine;
using System.Collections;

public class Person {
	public int id;
	public float age;
	public string gender;
	public string name;
	public int wealth;
	private string[] malenames = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	private string[] femalenames = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	private string[] surnames = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
	public float awareness;

	public float[] charity;
	public float[] community;
	public float[] family;
	public float[] piety;
	public float[] tolerance;

	public Person () {
		age = Random.Range(18,80);
		gender = Random.Range(0,2) == 0 ? "m" : "f";
		string[] namelookup = gender == "m" ? malenames : femalenames;
		name = namelookup[Random.Range(0,namelookup.Length)];
		name += surnames[Random.Range(0,surnames.Length)];
		name += surnames[Random.Range(0,surnames.Length)];
		wealth = Random.Range(1,11);

		charity = Values();
		community = Values();
		family = Values();
		piety = Values();
		tolerance = Values();

		Debug.Log(name + " " + gender + ":" + age.ToString("0") + "tolerance: " + tolerance[0].ToString() + "-" + tolerance[1].ToString() + "; community: " + community[0].ToString() + "-" + community[1].ToString());
	} 

	float[] Values() {
		float[] value = new float[2];
		float one = Random.Range(0,0.8f);
		float two = Random.Range(0.8f,1.5f);
		value[0] = one;
		value[1] = Mathf.Min(1f,two);
		return value;
	}
}
