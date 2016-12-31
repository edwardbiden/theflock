using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public static Game s;
	public GameObject menuPanel;

	// menu > council > office > church > council
	public GameObject churchPanel;
	public GameObject officePanel;
	public GameObject servicePanel;
	public GameObject phonePanel;
	public GameObject messagePanel;
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
		Congregation.s.Generate();
		Congregation.s.Members();
		GoToChurch();
	}

	public void GoToOffice() {
		Office.s.BeginWeek();
		foreach(GameObject g in panels) g.SetActive(false);
		officePanel.SetActive(true);
	}

	public void GoBackToOffice() {
		foreach(GameObject g in panels) g.SetActive(false);
		officePanel.SetActive(true);
	}

	public void GoToService() {
		Congregation.s.Members();
		Service.s.BeginService();
		foreach(GameObject g in panels) g.SetActive(false);
		servicePanel.SetActive(true);
	}

	public void GoToChurch() {
		Church.s.Refresh();
		foreach(GameObject g in panels) g.SetActive(false);
		churchPanel.SetActive(true);
	}

	public void GoToPhone() {
		foreach(GameObject g in panels) g.SetActive(false);
		phonePanel.SetActive(true);
	}

	public void GoToMessage() {
		foreach(GameObject g in panels) g.SetActive(false);
		messagePanel.SetActive(true);
	}

	public void OpenMenu() {
		foreach(GameObject g in panels) g.SetActive(false);
		menuPanel.SetActive(true);
	}
}
