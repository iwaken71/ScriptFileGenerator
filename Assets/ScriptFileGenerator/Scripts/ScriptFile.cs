using System.Collections.Generic;
using UnityEngine;

public interface IScript
{
    string GetString();
}

[System.Serializable]
public class Using : IScript
{
    public string name;
    public string GetString()
    {

        if (name == "")
        {
            return "";
        }
        return "using " + name + ";" + System.Environment.NewLine;
    }
}
[System.Serializable]
public class NameSpace : IScript
{
    public string name;
    public IScript body;
    public string GetString()
    {
        if (name == "")
        {
            return body.GetString();
        }
        string s = "namespace " + name + " {" + System.Environment.NewLine;
        s += body.GetString();
        s += "}" + System.Environment.NewLine;
        return s;
    }
    public NameSpace(string name)
    {
        this.name = name;
    }
}

[System.Serializable]
[CreateAssetMenu(menuName = "Custom/Create Scrpit File")]
public class ScriptFile : ScriptableObject, IScript
{
    public List<Using> usings;
    public NameSpace nameSpace;
    public ClassFile classFile;

    public string GetString()
    {
        string s = "";
        if (usings.Count > 0)
        {
            for (int i = 0; i < usings.Count; i++)
            {
                s += usings[i].GetString();
            }
        }
        nameSpace.body = classFile;
        s += nameSpace.GetString();
        return s;
    }

    public ScriptFile(ScriptFile script)
    {
        this.usings = new List<Using>(script.usings);
        this.nameSpace = new NameSpace(script.nameSpace.name);
        this.nameSpace.body = script.classFile;
        this.classFile = new ClassFile();
        this.classFile.access = script.classFile.access;
        this.classFile.name = script.classFile.name;
        this.classFile.parents = new List<ParentClass>(script.classFile.parents);
        this.classFile.fields = new List<Field>(script.classFile.fields);
        this.classFile.methods = new List<Method>(script.classFile.methods);
    }
}

[System.Serializable]
public class ClassFile : IScript
{
    public string access;
    public string name;
    public List<ParentClass> parents;
    public List<Field> fields;
    public List<Method> methods;

    public string GetString()
    {
        string s = access + " " + "class" + " " + name;
        if (parents.Count > 0)
        {
            s += " : ";
            for (int i = 0; i < parents.Count; i++)
            {
                s += parents[i].GetString();
                if (i < parents.Count - 1)
                {
                    s += ", ";
                }
            }
        }
        s += " {" + System.Environment.NewLine;
        if (fields.Count > 0)
        {
            for (int i = 0; i < fields.Count; i++)
            {
                s += fields[i].GetString();
            }
        }
        if (methods.Count > 0)
        {
            for (int i = 0; i < methods.Count; i++)
            {
                s += methods[i].GetString();
            }
        }
        s += "}";
        return s;
    }
}
[System.Serializable]
public class ParentClass : IScript
{
    public string name;
    public string GetString()
    {
        return name;
    }
}
[System.Serializable]
public class Field : IScript
{
    public string access;
    public string type;
    public string name;
    public string GetString()
    {
        return access + " " + type + " " + name + ";" + System.Environment.NewLine;
    }
}
[System.Serializable]
public class Method : IScript
{
    public string access;
    public string returnType;
    public string methodName;
    public List<Argument> argument;

    public string GetString()
    {
        string s = access + " " + returnType + " " + methodName + " (";
        if (argument.Count > 0)
        {
            for (int i = 0; i < argument.Count; i++)
            {
                s += argument[i].GetString();

                if (i < argument.Count - 1)
                {
                    s += ", ";
                }
            }
        }
        s += "){}" + System.Environment.NewLine;
        return s;
    }
}
[System.Serializable]
public class Argument : IScript
{
    public string type;
    public string name;
    public string GetString()
    {
        return type + " " + name;
    }
}