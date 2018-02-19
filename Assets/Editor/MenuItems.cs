using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems
{

	//Ruta - Hotkey
	[MenuItem("Upm Tools/Clear PlayerPrefs %#a")] //HotKey ctrl+shift+a
	private static void ClearPlayerPrefs(){
		PlayerPrefs.DeleteAll ();
	}


	[MenuItem("Window/New Option %g")] //HotKey ctrl+g
	private static void NewMenuOption(){
	}
	/*
	[MenuItem("Window/SubMenu/Option _g")] //HotKey g
	private static void NewNestedOption(){
	}*/

	[MenuItem("Assets/Load Additive Scene")]
	private static void LoadAdditiveScene(){
		var selected = Selection.activeObject;
		UnityEditor.SceneManagement.EditorSceneManager.OpenScene (AssetDatabase.GetAssetPath (selected), UnityEditor.SceneManagement.OpenSceneMode.Additive);
	}

	//Este se hace primero antes que el anterior para comprobar si esta bien el tipo
	[MenuItem("Assets/Load Additive Scene",true)]
	private static bool MenuOptionvalidation(){
		return (Selection.activeObject!=null) ? Selection.activeObject.GetType () == typeof(UnityEngine.SceneManagement.Scene) : false;
	}

	[MenuItem("Assets/Create/My Character Sprite")]
	private static void MyCharacterSprite(){
		GameObject go = new GameObject ("MyCharacterSprite");
		go.transform.position = new Vector3 (0,0,0);
		go.AddComponent<SpriteRenderer> ();
		Sprite s = (Sprite)AssetDatabase.LoadAssetAtPath ("Assets/Images/character.jpg",typeof(Sprite));
		go.GetComponent<SpriteRenderer> ().sprite = s;
	}

	//Sale en el menu contextual del componente
	[MenuItem("CONTEXT/Rigidbody/NewOption")]
	private static void NewOpenForRigidBody(){
	}

	//Para separar por grupos (tercer valor) unity pone una barra siempre cada 50 items
	//El segundo parametro (el bool) indica si es un parametro de validacion, en este caso no (por lo tanto false) pero hay que ponerlo porque sino no se puede acceder al tercero
	[MenuItem("NewMenu/Option1",false,1)]
	private static void NewMenuOption1(){
	}
	[MenuItem("NewMenu/Option2",false,2)]
	private static void NewMenuOption2(){
	}
	[MenuItem("NewMenu/Option3",false,3)]
	private static void NewMenuOption3(){
	}
	[MenuItem("NewMenu/Option4",false,51)]
	private static void NewMenuOption4(){
	}
	[MenuItem("NewMenu/Option5",false,52)]
	private static void NewMenuOption5(){
	}


	[MenuItem("CONTEXT/Rigidbody/SetValues")]
	private static void SetRigidVodyValues(MenuCommand menuCommand)
	{
		Rigidbody rb = menuCommand.context as Rigidbody;
		rb.mass = 100;
		rb.drag = 100;
		rb.angularDrag = 1;
		rb.isKinematic = true;
	}

}
