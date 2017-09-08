using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildSettings: EditorWindow
{
	bool ServerDefine = true;
	static Vector2 MinSize = new Vector2(10, 22);
	[MenuItem("My tools/Build Settings")]
	static void Init()
	{
		var window = GetWindow<BuildSettings>();
		window.titleContent = new GUIContent("Build Settings");
		window.minSize = MinSize;
		window.Show();
	}
	void OnGUI()
	{
		//EditorGUILayout.LabelField("Server", EditorStyles.largeLabel, GUILayout.Width(50));
		//ServerDefine = EditorGUILayout.Toggle(ServerDefine, EditorStyles.radioButton, GUILayout.Width(15));
		//ServerDefine = !EditorGUILayout.Toggle(!ServerDefine, EditorStyles.radioButton, GUILayout.Width(15));
		//EditorGUILayout.LabelField("Client", EditorStyles.largeLabel, GUILayout.ExpandWidth(false));
		var previousState = ServerDefine;
		int selected = ServerDefine ? 0 : 1;
		ServerDefine = GUILayout.SelectionGrid(selected, new string[] { "Server", "Client" }, 2) == 0;
		if (ServerDefine != previousState)
			PlayerSettings.productName = ServerDefine ? "Server" : "Client";
		EditorGUIUtility.labelWidth = 0;
	/*	ServerDefine = EditorGUILayout.ToggleLeft("Server", ServerDefine);*/
		string textToAdd = ServerDefine ? ";SERVER" : "";
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, "UNITY" + textToAdd);
	}
}
