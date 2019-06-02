using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(ScriptFileGenerator))]
public class ScriptFileGeneratorInspector : Editor
{
    public override void OnInspectorGUI()
    {
        ScriptFileGenerator generator = target as ScriptFileGenerator;
        base.OnInspectorGUI();
        if (GUILayout.Button("OriginalScriptから生成"))
        {
            string folderName = generator.FolderName;
            string scriptName = generator.originalScript.classFile.name + ".cs";
            string fileBody = generator.originalScript.GetString();
            generator.GenerateScript(folderName,scriptName,fileBody);
        }

        if (GUILayout.Button("classNamesとSuffixから生成"))
        {
            generator.GenerateSuffixScripts(generator.classNames,generator.Suffix);
        }

        if (GUILayout.Button("選択したオブジェクトの名前を取得する"))
        {
            var names = Selection.gameObjects.Select(gamaObj => gamaObj.name);
            generator.classNames = names.ToArray();
        }

    }
}
