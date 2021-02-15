using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LevelScreen : UScreen
{
    public LevelScreenBinder UBinder { get; set; }


    public override void Awake(object initData)
    {
        base.Awake(initData);
        UBinder = new LevelScreenBinder();
        UBinder.BindComponents(UScreenMono.gameObject);

        UBinder.mCloseButton.onClick.AddListener(Hide);
    }
}
