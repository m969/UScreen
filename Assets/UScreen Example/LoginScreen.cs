using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class LoginScreen : UScreen
{
    public LoginScreenBinder UBinder { get; set; }


    public override void Awake(object initData)
    {
        base.Awake(initData);
        UBinder = new LoginScreenBinder();
        UBinder.BindComponents(UScreenMono.gameObject);

        UBinder.mCloseButton.onClick.AddListener(Hide);
    }
}
