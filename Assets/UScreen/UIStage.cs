using System.Collections;
using System.Collections.Generic;
using UComponent;
using UnityEngine;

public class UIStage : UComponent.Entity
{
    public static UIStage Instance { get; private set; }
    public Dictionary<string, UScreen> TypeScreens = new Dictionary<string, UScreen>();


    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    public override void OnAddChild(Entity child)
    {
        base.OnAddChild(child);
        if (child is UScreen screen)
        {
            TypeScreens.Add(child.GetType().Name, screen);
        }
    }

    public T PopUp<T>() where T : UScreen
    {
        var screen = Type2Children[typeof(T)][0] as T;
        foreach (var item in TypeScreens)
        {
            if (item is T showScreen)
            {
                continue;
            }
            item.Value.Hide();
        }
        screen.Show();
        return screen;
    }
}
