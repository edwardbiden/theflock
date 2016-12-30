using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game s;
	public GameObject menuPanel;

	// menu > council > office > church > council
	public GameObject churchPanel;
	public GameObject officePanel;
	public GameObject servicePanel;
	public GameObject[] panels;

	void Awake () {
		s = this;
	}

	void Start() {
		foreach(GameObject g in panels) g.SetActive(false);
		menuPanel.SetActive(true);
	}

	public void NewGame() {
		Church.s.Generate();
		Congregation.s.Generate(100);
		Congregation.s.Members();
		GoToChurch();
	}

	public void GoToOffice() {
		foreach(GameObject g in panels) g.SetActive(false);
		officePanel.SetActive(true);
	}

	public void GoToService() {
		foreach(GameObject g in panels) g.SetActive(false);
		servicePanel.SetActive(true);
	}

	public void GoToChurch() {
		Church.s.UpdateText();
		foreach(GameObject g in panels) g.SetActive(false);
		churchPanel.SetActive(true);
	}

	public void OpenMenu() {
		foreach(GameObject g in panels) g.SetActive(false);
		menuPanel.SetActive(true);
	}
}
