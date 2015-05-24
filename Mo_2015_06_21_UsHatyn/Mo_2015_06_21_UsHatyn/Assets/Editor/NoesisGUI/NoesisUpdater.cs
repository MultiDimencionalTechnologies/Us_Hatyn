using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.IO;
using System.Collections;


[InitializeOnLoad]
public class NoesisUpdater
{
    const string lastVersion = "1.2.3";

    public static bool IsLocked()
    {
        string lockupdate = Application.dataPath + "/Editor/NoesisGUI/lockupdate.txt";
        return File.Exists(lockupdate);
    }

    static NoesisUpdater()
    {
        if (IsLocked())
        {
            return;
        }

        string currentVersion = null;
        string filename = Application.dataPath + "/Editor/NoesisGUI/version.txt";

        try
        {
            if (File.Exists(filename))
            {
                StreamReader reader = new StreamReader(filename);
                currentVersion = reader.ReadLine();
                reader.Close();
            }
        }
        catch (Exception) { }

        // If there is no version file it must be a clean new version or an old version (<=1.1.8)
        if (String.IsNullOrEmpty(currentVersion))
        {
            if (File.Exists(Application.dataPath + "/Plugins/x86/libUnityRenderHook.so"))
            {
                currentVersion = "1.1.8";
            }
            else
            {
                currentVersion = "";
            }
        }

        if (currentVersion != lastVersion)
        {
            GoogleAnalyticsHelper.LogEvent("Install", lastVersion, 0);

            string progressTitle;
            if (currentVersion != "")
            {
                progressTitle = "noesisGUI Upgrade " + currentVersion + " -> " + lastVersion;
            }
            else
            {
                progressTitle = "noesisGUI Upgrade " + lastVersion;
            }

            EditorUtility.DisplayProgressBar(progressTitle, "Upgrading scripts...", 0.0f);

            // Apply needed patches
            Upgrade(currentVersion);

            // Rebuild Database
            NoesisSettings.RebuildActivePlatforms(progressTitle);

            try
            {
                StreamWriter writer = new StreamWriter(filename);
                writer.WriteLine(lastVersion);
                writer.Close();

            }
            catch (Exception) { }

            // Refresh Asset Database
            AssetDatabase.Refresh();

            // Show Welcome Screen
            EditorWindow.GetWindow(typeof(NoesisWelcome), true, "Welcome to NoesisGUI!");
        }
    }

    static void Upgrade(string currentVersion)
    {
        // 1.1.8 -> 1.1.9
        if (currentVersion == "1.1.8")
        {
            Upgrade_1_1_9();
            currentVersion = "1.1.9";
        }

        // 1.1.9 -> 1.1.10
        if (currentVersion == "1.1.9")
        {
            currentVersion = "1.1.10";
        }

        // 1.1.10 -> 1.1.11
        if (currentVersion == "1.1.10")
        {
            currentVersion = "1.1.11";
        }

        // 1.1.11 -> 1.1.12
        if (currentVersion == "1.1.11")
        {
            Upgrade_1_1_12();
            currentVersion = "1.1.12";
        }

        // 1.1.12 -> 1.1.13
        if (currentVersion == "1.1.12")
        {
            currentVersion = "1.1.13";
        }

        // 1.1.13 -> 1.1.14
        if (currentVersion == "1.1.13")
        {
            currentVersion = "1.1.14";
        }

        // 1.1.14 -> 1.2.0
        if (currentVersion == "1.1.14")
        {
            Upgrade_1_2_0();
            currentVersion = "1.2.0b";
        }

        // 1.2.0 -> 1.2.0b6
        if (currentVersion == "1.2.0b")
        {
            Upgrade_1_2_0b6();
            currentVersion = "1.2.0b6";
        }

        // 1.2.0b6 -> 1.2.0b7
        if (currentVersion == "1.2.0b6")
        {
            Upgrade_1_2_0b7();
            currentVersion = "1.2.0b7";
        }

        // 1.2.0b7 -> 1.2.0b8
        if (currentVersion == "1.2.0b7")
        {
            Upgrade_1_2_0b8();
            currentVersion = "1.2.0b8";
        }

        // 1.2.0b8 -> 1.2.0RC1
        if (currentVersion == "1.2.0b8")
        {
            currentVersion = "1.2.0RC1";
        }

        // 1.2.0RC1 -> 1.2.0RC2
        if (currentVersion == "1.2.0RC1")
        {
            currentVersion = "1.2.0RC2";
        }

        // 1.2.0RC2 -> 1.2.0RC3
        if (currentVersion == "1.2.0RC2")
        {
            currentVersion = "1.2.0RC3";
        }

        // 1.2.0RC3 -> 1.2.0RC4
        if (currentVersion == "1.2.0RC3")
        {
            currentVersion = "1.2.0RC4";
        }

        // 1.2.0RC4 -> 1.2.0RC5
        if (currentVersion == "1.2.0RC4")
        {
            currentVersion = "1.2.0RC5";
        }

        // 1.2.0RC5 -> 1.2.0
        if (currentVersion == "1.2.0RC5")
        {
            currentVersion = "1.2.0";
        }

        // 1.2.0 -> 1.2.1
        if (currentVersion == "1.2.0")
        {
            currentVersion = "1.2.1";
        }

        // 1.2.1 -> 1.2.2RC1
        if (currentVersion == "1.2.1")
        {
            currentVersion = "1.2.2RC1";
        }

        // 1.2.2RC1 -> 1.2.2
        if (currentVersion == "1.2.2RC1")
        {
            Upgrade_1_2_2();
            currentVersion = "1.2.2";
        }

        // 1.2.2 -> 1.2.3
        if (currentVersion == "1.2.2")
        {
            currentVersion = "1.2.3";
        }

        RemoveObsoleteScripts();

        UpdatePluginImporterSettings();
    }

    static void Upgrade_1_1_9()
    {
        AssetDatabase.DeleteAsset("Assets/Plugins/x86/UnityRenderHook.dll");
        AssetDatabase.DeleteAsset("Assets/Plugins/x86_64/UnityRenderHook.dll");
        AssetDatabase.DeleteAsset("Assets/Plugins/x86/libUnityRenderHook.so");
        AssetDatabase.DeleteAsset("Assets/Plugins/UnityRenderHook.bundle");
    }

    static void Upgrade_1_1_12()
    {
        EditorPrefs.DeleteKey("NoesisReviewStatus");
        EditorPrefs.DeleteKey("NoesisReviewDate");
    }

    static void Upgrade_1_2_0()
    {
        AssetDatabase.DeleteAsset("Assets/meta.ANDROID.cache");
        AssetDatabase.DeleteAsset("Assets/meta.GL.cache");
        AssetDatabase.DeleteAsset("Assets/meta.IOS.cache");
        AssetDatabase.DeleteAsset("Assets/meta.DX9.cache");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI.build.ANDROID.log");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI.build.GL.log");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI.build.IOS.log");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI.build.DX9.log");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI.play.log");
        AssetDatabase.DeleteAsset("Assets/Editor/NoesisGUI/Build_.cs");

        string[] makes = Directory.GetFiles(UnityEngine.Application.dataPath, "*.make", SearchOption.AllDirectories);
        foreach (string make in makes)
        {
            string asset = ("Assets" + make.Substring(UnityEngine.Application.dataPath.Length)).Replace('\\', '/');
            AssetDatabase.DeleteAsset(asset);
        }

        string[] fonts = Directory.GetFiles(UnityEngine.Application.dataPath, "*.font", SearchOption.AllDirectories);
        foreach (string font in fonts)
        {
            string asset = ("Assets" + font.Substring(UnityEngine.Application.dataPath.Length)).Replace('\\', '/');
            AssetDatabase.DeleteAsset(asset);
        }

        EditorPrefs.DeleteKey("NoesisDelayedBuildDoScan");
        EditorPrefs.DeleteKey("NoesisDelayedBuildDoBuild");
    }

    static void Upgrade_1_2_0b6()
    {
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Docs/Images.zip");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Docs/Integration.zip");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Docs/Shapes.zip");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Docs/Text.zip");
    }

    static void Upgrade_1_2_0b7()
    {
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/blog_compose.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/button_blue_pause.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/button_blue_play.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/calculator.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/calendar.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/camera.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/folder_open.png");
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/notepad.png");
    }

    static void Upgrade_1_2_0b8()
    {
        AssetDatabase.DeleteAsset("Assets/NoesisGUI/Samples/ControlGallery/Samples/Images/space.jpg");
    }

    static void Upgrade_1_2_2()
    {
        AssetDatabase.DeleteAsset("Assets/Editor/NoesisGUI/BuildTool/tbb.dll");
        AssetDatabase.DeleteAsset("Assets/Plugins/x86/tbb.dll");
    }

    static void RemoveObsoleteScripts()
    {
        // 1_2_0b6
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/AccessKeyEventArgs.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/AncestorNameScopeChangeAction.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/AncestorNameScopeChangedArgs.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/BaseCommand.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/BaseList.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/BaseObservableList.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/BaseValueConverter.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/DictionaryChangedAction.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/DictionaryChangedEventArgs.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/NameScopeChangedAction.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/NameScopeChangedArgs.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/NotifyCollectionChangedAction.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/NotifyCollectionChangedEventArgs.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/ResourceDictionaryExtend.cs");

        // 1_2_0b7
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/SerializableComponent.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/SerializePropertyHelper.cs");

        // 1_2_0b8
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/DependencyData.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/SizeChangedInfo.cs");

        // 1_2_0RC1
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/AnimationTarget.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/ObjectWithNameScope.cs");
        AssetDatabase.DeleteAsset("Assets/Plugins/NoesisGUI/Scripts/Proxies/PathElement.cs");
    }

    static void UpdatePluginImporterSettings()
    {
#if UNITY_5_0
        // http://issuetracker.unity3d.com/issues/plugin-importer-settings-do-not-persist-when-exporting-a-unitypackage
        PluginImporter importer;

        importer = AssetImporter.GetAtPath("Assets/Plugins/Noesis.bundle") as PluginImporter;
        if (importer != null)
        {
            importer.SetCompatibleWithAnyPlatform(false);
            importer.SetCompatibleWithEditor(false);
            importer.SetCompatibleWithPlatform(BuildTarget.StandaloneOSXUniversal, true);
            importer.SaveAndReimport();
        }

        importer = AssetImporter.GetAtPath("Assets/Plugins/NoesisUnityRenderHook.bundle") as PluginImporter;
        if (importer != null)
        {
            importer.SetCompatibleWithAnyPlatform(false);
            importer.SetCompatibleWithEditor(true);
            importer.SetCompatibleWithPlatform(BuildTarget.StandaloneOSXUniversal, true);
            importer.SaveAndReimport();
        }

        importer = AssetImporter.GetAtPath("Assets/Editor/NoesisGUI/BuildTool/Noesis.bundle") as PluginImporter;
        if (importer != null)
        {
            importer.SetCompatibleWithAnyPlatform(false);
            importer.SetCompatibleWithEditor(true);
            importer.SaveAndReimport();
        }
#endif
    }
}
