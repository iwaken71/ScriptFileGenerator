using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScriptFileGenerator : MonoBehaviour
{

    public ScriptFile originalScript;
    public string FolderName;
    public string[] classNames;
    public string Suffix;

    public void GenerateSuffixScripts(string[] classNameList,string suffix) {

        foreach (string className in classNameList)
        {
            ScriptFile scriptFile = new ScriptFile(originalScript);
            string viewClassName = className + suffix + ".cs";
            string ViewFolderName = Path.Combine(FolderName, suffix);
            scriptFile.classFile.name = className + suffix;
            GenerateScript(ViewFolderName, scriptFile.classFile.name + ".cs", scriptFile.GetString());
        }

    }
    public void GenerateScript(string folderName, string fileName, string fileBody)
    {
        string folderPath = Path.Combine(Application.dataPath, folderName);
        DirectoryUtils.SafeCreateDirectory(folderPath);
        string filePath = Path.Combine(folderPath, fileName);
        StreamWriter sw = new StreamWriter(filePath, false, System.Text.Encoding.GetEncoding("utf-8"));// TextData.txtというファイルを新規で用意
        sw.WriteLine(fileBody);// ファイルに書き出したあと改行
        sw.Flush();// StreamWriterのバッファに書き出し残しがないか確認
        sw.Close();// ファイルを閉じる
    }
}

