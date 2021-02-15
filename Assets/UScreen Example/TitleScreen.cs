using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TitleScreen : UScreen
{
    public TitleScreenBinder UBinder { get; set; }


    public override void Awake(object initData)
    {
        base.Awake(initData);
        UBinder = new TitleScreenBinder();
        UBinder.BindComponents(UScreenMono.gameObject);

        UBinder.mCloseButton.onClick.AddListener(Hide);
    }
}
