using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ImportDesign
{
    private const string kPython = "python";
    private const string kImportScript = "ImportDesign.py";
    private const string kAll = "all";
    private const string kExport= "export";
    private const string kCreate = "create";
    private const string kUpdateEnum = "updateEnum";
    private const string kDialogs = "dialogs";
    private const string kInteract = "interacting";
    private const string kEvents = "events";
    private const string kChapters = "chapters";

    [MenuItem("Time/Design/Import All")]
    public static void Import()
    {
        CommandLineHelper.RunCommand(kPython, kImportScript, kAll);
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Dialog")]
    public static void ImportDialog()
    {
        CommandLineHelper.RunCommand(kPython, kImportScript, kExport, kCreate, kUpdateEnum, kDialogs);
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Interacting Objects")]
    public static void ImportInteracintObjects()
    {
        CommandLineHelper.RunCommand(kPython, kImportScript, kExport, kCreate, kUpdateEnum, kInteract);
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Events")]
    public static void Events()
    {
        CommandLineHelper.RunCommand(kPython, kImportScript, kExport, kCreate, kUpdateEnum, kEvents);
        AssetDatabase.Refresh();
    }

    [MenuItem("Time/Design/Import Chapters")]
    public static void Chapters()
    {
        CommandLineHelper.RunCommand(kPython, kImportScript, kExport, kCreate, kUpdateEnum, kChapters);
        AssetDatabase.Refresh();
    }



}
