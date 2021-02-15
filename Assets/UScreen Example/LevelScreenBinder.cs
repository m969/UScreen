using UnityEngine;
using UnityEngine.UI;
using System;

	public sealed partial class LevelScreenBinder : UBinder
	{
		public UnityEngine.UI.Button mCloseButton;
		public UnityEngine.UI.Text mLevelText;

		public override void BindComponents(GameObject viewObject)
		{
			mCloseButton = viewObject.transform.Find("mCloseButton").GetComponent<UnityEngine.UI.Button>();
			mLevelText = viewObject.transform.Find("mLevelText").GetComponent<UnityEngine.UI.Text>();
		}
	}
