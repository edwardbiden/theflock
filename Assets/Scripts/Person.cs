using UnityEngine;
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

	public float[] community;
	public float[] moral;
	public float[] piety;

	public Person () {
		age = Random.Range(18,80);
		gender = Random.Range(0,2) == 0 ? "m" : "f";
		string[] namelookup = gender == "m" ? malenames : femalenames;
		name = namelookup[Random.Range(0,namelookup.Length)];
		name += surnames[Random.Range(0,surnames.Length)];
		name += surnames[Random.Range(0,surnames.Length)];
		wealth = Random.Range(1,11);

		community = Values();
		moral = Values();
		piety = Values();

		Debug.Log(name + " " + gender + ":" + age.ToString("0") + "community: " + community[0].ToString("0.00") + "-" + community[1].ToString("0.00") + "; moral: " + moral[0].ToString("0.00") + "-" + moral[1].ToString("0.00"));
	} 

	float[] Values() {
		float[] value = new float[2];
		float one = Random.Range(0,1f);
		float two = Random.Range(0,1f);
		value[0] = Mathf.Min(one,two);
		value[1] = Mathf.Max(one,two);
		return value;
	}
}
