using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UComponent;

public class UScreenTest : MonoBehaviour
{
    void Awake()
    {
        MasterEntity.Create();
        Entity.Create<UIStage>();
    }

    void Start()
    {
        UIStage.Instance.PopUp<TitleScreen>();
    }

    void Update()
    {
        MasterEntity.Instance.Update();
    }

    public void PopUpTitle()
    {
        UIStage.Instance.PopUp<TitleScreen>();
    }

    public void PopUpLogin()
    {
        UIStage.Instance.PopUp<LoginScreen>();
    }

    public void PopUpLevel()
    {
        UIStage.Instance.PopUp<LevelScreen>();
    }
}
