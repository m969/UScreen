using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UComponent;

public class UScreenMono : MonoBehaviour
{
    [ValueDropdown("FilterScreenType")]
    public string ScreenType;
    public UScreen Screen { get; private set; }


    private IEnumerable<string> FilterScreenType()
    {
        return new string[] { "TitleScreen", "LoginScreen", "LevelScreen"};
    }

    private void Start()
    {
        if (ScreenType == "LoginScreen")
        {
            Screen = Entity.CreateWithParent<LoginScreen>(UIStage.Instance, this);
        }
        if (ScreenType == "LevelScreen")
        {
            Screen = Entity.CreateWithParent<LevelScreen>(UIStage.Instance, this);
        }
        if (ScreenType == "TitleScreen")
        {
            Screen = Entity.CreateWithParent<TitleScreen>(UIStage.Instance, this);
        }
    }
}
