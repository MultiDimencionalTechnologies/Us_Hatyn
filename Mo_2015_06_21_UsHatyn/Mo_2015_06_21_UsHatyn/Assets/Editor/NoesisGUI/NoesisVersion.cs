using System;
using UnityEngine;
using Noesis;


public class NoesisVersion
{
    public static string Get()
    {
        try
        {
            using (var library = new Library(UnityEngine.Application.dataPath + "/Editor/NoesisGUI/BuildTool/Noesis"))
            {
                var getVersion = library.Find<Noesis_GetVersionDelegate>("Noesis_GetVersion");
                return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(getVersion());
            }
        }
        catch
        {
            return "";
        }
    }

    public static bool IsTrial()
    {
        try
        {
            using (var library = new Library(UnityEngine.Application.dataPath + "/Editor/NoesisGUI/BuildTool/Noesis"))
            {
                var isTrial = library.Find<Noesis_IsTrialDelegate>("Noesis_IsTrial");
                return isTrial();
            }
        }
        catch
        {
            return false;
        }
    }

    private delegate IntPtr Noesis_GetVersionDelegate();
    private delegate bool Noesis_IsTrialDelegate();
}