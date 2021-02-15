using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using System.Text;
using System;
using System.Linq;

[CreateAssetMenu(fileName = "MyViewBinder", menuName = "UBinder/视图构建配置")]
public class BinderBuildObject : SerializedScriptableObject
{
    [LabelText("视图对象")]
    public GameObject ViewObject;

    [Space(10)]
    [LabelText("指定前缀")]
    public string Prefix = "m";
    //[LabelText("变量名去掉前缀")]
    //public bool MemberNoPrefix;
    [LabelText("命名空间")]
    public string Namespace = "";
    [LabelText("基类")]
    public string BaseClass = "UBinder";

    [Space(10)]
    [HideReferenceObjectPicker]
    [LabelText("成员列表")]
    public Dictionary<string, Component> MemberTypes = new Dictionary<string, Component>();

    private static List<Type> PriorityComponents = new List<Type>() { typeof(MonoBehaviour), typeof(Button), typeof(Text), typeof(InputField), typeof(Toggle), typeof(Slider), typeof(Dropdown), typeof(Transform) };


    [Button("清空")]
    private void ClearParse()
    {
        MemberTypes.Clear();
    }

    [Button("解析")]
    private void ParseBuild()
    {
        ForeachTransform(ViewObject.transform);
    }

    [Button("生成代码")]
    private void GenerateCode()
    {
        var sb = new StringBuilder();
        sb.AppendLine("using UnityEngine;");
        sb.AppendLine("using UnityEngine.UI;");
        sb.AppendLine("using System;");
        sb.AppendLine("");

        if (Namespace != "")
        {
            sb.AppendLine($"namespace {Namespace}");
            sb.AppendLine("{");
        }

        if (BaseClass != "")
        {
            sb.AppendLine($"\tpublic sealed partial class {name}Binder : {BaseClass}");
        }
        else
        {
            sb.AppendLine($"\tpublic sealed partial class {name}Binder : UBinder");
        }
        sb.AppendLine("\t{");
        foreach (var item in MemberTypes)
        {
            sb.AppendLine($"\t\tpublic {item.Value.GetType().FullName} {item.Key};");
        }

        sb.AppendLine("");
        sb.AppendLine("\t\tpublic override void BindComponents(GameObject viewObject)");
        sb.AppendLine("\t\t{");
        foreach (var item in MemberTypes)
        {
            sb.AppendLine($"\t\t\t{item.Key} = viewObject.transform.Find(\"{item.Key}\").GetComponent<{item.Value.GetType().FullName}>();");
        }
        sb.AppendLine("\t\t}");

        sb.AppendLine("\t}");

        if (Namespace != "")
        {
            sb.AppendLine("}");
        }

        var path = UnityEditor.AssetDatabase.GetAssetPath(this);
        System.IO.File.WriteAllText(path.Replace(".asset", "Binder.cs"), sb.ToString());
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }

    private void ForeachTransform(Transform transform)
    {
        if (transform.name.StartsWith("m"))
        {
            if (MemberTypes == null)
            {
                MemberTypes = new Dictionary<string, Component>();
            }
            if (!MemberTypes.ContainsKey(transform.name))
            {
                var components = transform.GetComponents(typeof(Component));
                if (components.Length > 0)
                {
                    var max = components[0];
                    foreach (var item in components)
                    {
                        if (PriorityComponents.Contains(item.GetType()))
                        {
                            var itemIndex = PriorityComponents.IndexOf(item.GetType());
                            var maxIndex = PriorityComponents.IndexOf(max.GetType());
                            if (!PriorityComponents.Contains(max.GetType()))
                            {
                                maxIndex = 100;
                            }
                            if (item is MonoBehaviour)
                            {
                                itemIndex = -1;
                            }
                            if (itemIndex < maxIndex)
                            {
                                max = item;
                            }
                        }
                    }
                    MemberTypes.Add(transform.name, max);
                }
                else
                {
                    MemberTypes.Add(transform.name, transform);
                }
            }
        }
        if (transform.childCount > 0)
        {
            foreach (Transform item in transform)
            {
                ForeachTransform(item);
            }
        }
    }
}
