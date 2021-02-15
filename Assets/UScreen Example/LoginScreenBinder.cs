using UnityEngine;
using UnityEngine.UI;
using System;

	public sealed partial class LoginScreenBinder : UBinder
	{
		public UnityEngine.UI.Button mCloseButton;
		public UnityEngine.UI.Text mLoginText;
		public UnityEngine.UI.InputField mInputField;
		public UnityEngine.UI.Button mLoginButton;

		public override void BindComponents(GameObject viewObject)
		{
			mCloseButton = viewObject.transform.Find("mCloseButton").GetComponent<UnityEngine.UI.Button>();
			mLoginText = viewObject.transform.Find("mLoginText").GetComponent<UnityEngine.UI.Text>();
			mInputField = viewObject.transform.Find("mInputField").GetComponent<UnityEngine.UI.InputField>();
			mLoginButton = viewObject.transform.Find("mLoginButton").GetComponent<UnityEngine.UI.Button>();
		}
	}
