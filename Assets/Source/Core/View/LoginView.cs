using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour {
	private LoginModule loginModule;

	public InputField Username;
	public InputField Password;
	public Button confirm;
	// Use this for initialization
	void Start () {
		loginModule = ModuleManager.Instance().FindModule<LoginModule>();
		
		confirm.onClick.AddListener(onConfirmClick);

		//loginModule.Connect("192.168.18.168", 18888);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void onConfirmClick()
	{
		string username = Username.text;
		string password = Password.text;

		loginModule.Login(username, password);
		//TODO: do some action
	}
}
