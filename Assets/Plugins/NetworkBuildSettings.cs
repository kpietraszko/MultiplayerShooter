using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildSettings: EditorWindow
{
	bool ServerDefine = true;
	static Vector2 MinSize = new Vector2(10, 20);
	[MenuItem("My tools/Build Settings")]
	static void Init()
	{
		var window = GetWindow<BuildSettings>();
		window.minSize = MinSize;
		window.Show();
	}
	void OnGUI()
	{
		ServerDefine = EditorGUILayout.Toggle(new GUIContent("Server"), ServerDefine);
		string textToAdd = ServerDefine ? ";SERVER" : "";
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "UNITY" + textToAdd);
	}
}
