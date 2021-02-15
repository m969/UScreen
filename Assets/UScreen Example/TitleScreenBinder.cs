using UnityEngine;
using UnityEngine.UI;
using System;

	public sealed partial class TitleScreenBinder : UBinder
	{
		public UnityEngine.UI.Text mTitleText;
		public UnityEngine.UI.Button mCloseButton;

		public override void BindComponents(GameObject viewObject)
		{
			mTitleText = viewObject.transform.Find("mTitleText").GetComponent<UnityEngine.UI.Text>();
			mCloseButton = viewObject.transform.Find("mCloseButton").GetComponent<UnityEngine.UI.Button>();
		}
	}
