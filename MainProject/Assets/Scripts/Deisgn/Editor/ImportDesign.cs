using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImportDesign
{
    [MenuItem("Time/Design/Import All")]
    public static void Import()
    {
        CommandLineHelper.RunCommand("python", "ImportDesign.py", "all");
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Dialog")]
    public static void ImportDialog()
    {
        CommandLineHelper.RunCommand("python", "ImportDesign.py", "export", "create", "updateEnum", "dialogs");
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Interacting Objects")]
    public static void ImportInteracintObjects()
    {
        CommandLineHelper.RunCommand("python", "ImportDesign.py", "export", "create", "updateEnum", "interacting");
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Events")]
    public static void Events()
    {
        CommandLineHelper.RunCommand("python", "ImportDesign.py", "export", "create", "updateEnum", "events");
        AssetDatabase.Refresh();
    }

}
