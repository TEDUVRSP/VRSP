using System.Collections;
using System.Collections.Generic;
using PackageManager;
using SimpleJSON;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using WiseMonkeES.Util;

public class PackagesEditor : EditorWindow
{
    //Load packages array from the package manager
    static Package [] packages;
    private static List<string> eachrow;
    private static string rowsjson;

    // Add a menu item named "Package Manager" to the WiseMonkeES menu
    [MenuItem("WiseMonkeES/Package Manager")]
    public static void ShowWindow()
    {
        GetWindow<PackagesEditor>("Packages");
        MBInstance.Instance.StartCoroutine(ObtainSheetData());
    }
    

    void OnGUI()
    {
        // Display the package manager title with update button
        EditorGUILayout.BeginHorizontal("box");
        EditorGUILayout.LabelField("Package Manager", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();
        if(packages == null)
        {
            EditorGUILayout.LabelField("Loading packages...");
            return;
        }
        foreach (var t1 in packages)
        {
            if(t1 == null)
                continue;
            // Display every package in a box
            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.BeginVertical();
            
            // // Display the package name in bold
            EditorGUILayout.LabelField(t1.name, EditorStyles.boldLabel);
            
            // Display the package github url
            EditorGUILayout.LabelField(t1.gitHubUrl);
            
            // Display the package description
            EditorGUILayout.LabelField(t1.description);
            
            // Display the package dependencies
            foreach (var t in t1.dependencies)
            {
                EditorGUILayout.LabelField(t.name);
            }
            // Display the package Download button
            if (GUILayout.Button("Download"))
            {
                // Log the package is being downloaded
                Debug.Log("Downloading " + t1.name + " from " + t1.gitHubUrl + "");
                // Download the package
                UnityEditor.PackageManager.Client.Add(t1.gitHubUrl);
            }
            
            EditorGUILayout.EndVertical();
            EditorGUILayout.EndHorizontal();
        }
    }
    
    static IEnumerator ObtainSheetData()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://sheets.googleapis.com/v4/spreadsheets/1w3lb--YNJjQQowqE0AdWcpPFEV6Nc5QrCDs4XODEpSA/values/Sayfa1?key=AIzaSyAbnuRDDM-KCgCPc20zalWyA6x0Z2FYr4U");
        yield return www.SendWebRequest();
        if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string json = www.downloadHandler.text;
            var o = JSON.Parse(json);
            var count = o["values"].Count;
            packages = new Package[count];
            foreach (var item in o["values"])
            {
                
                var itemo = JSON.Parse(item.ToString());
                eachrow = itemo[0].AsStringList;
                foreach (var data in eachrow)
                {
                    rowsjson += data + ",";
                }
                rowsjson += "\n";
            }

            var lines = rowsjson.Split('\n');
           
            for (var i = 1; i < count; i++)
            {
                var line = lines[i];
                var data = line.Split(',');
                var name = data[0];
                var description = data[1];
                var gitHubUrl = data[2];
                var dependencies = new Package[data.Length - 3];
                for (var j = 3; j < data.Length; j++)
                {
                    var dependency = data[j];
                    dependencies[j - 3] = new Package(dependency, "", "", null);
                }
                packages[i - 1] = new Package(name, description, gitHubUrl, dependencies);
            }
        }

    }

}