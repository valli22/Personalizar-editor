using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class NuevaVentana : EditorWindow {

	string myString = "Hello World";
	bool groupEnable;
	bool myBool = true;
	float myFloat = 1.23f;

	[MenuItem("Window/My Window")]
	public static void ShowWindow(){
		EditorWindow.GetWindow (typeof(NuevaVentana));
	}

	void OnGUI(){
		GUILayout.Label ("Base Settings", EditorStyles.boldLabel);
		myString = EditorGUILayout.TextField ("Text Field", myString);

		groupEnable = EditorGUILayout.BeginToggleGroup ("Optional Settings", groupEnable);
		myBool = EditorGUILayout.Toggle ("Toggle", myBool);
		myFloat = EditorGUILayout.Slider ("Slider", myFloat, -3, 3);
		EditorGUILayout.EndToggleGroup ();
	}

}
