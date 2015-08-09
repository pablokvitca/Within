using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Helps)), CanEditMultipleObjects]
public class TextAreaEditor : Editor {
	
	public SerializedProperty longStringProp;
	
	void OnEnable () {
		longStringProp = serializedObject.FindProperty ("helpText");
	}
	
	public override void OnInspectorGUI() {
		serializedObject.Update ();
		longStringProp.stringValue = EditorGUILayout.TextArea( longStringProp.stringValue, GUILayout.MaxHeight(75) );
		serializedObject.ApplyModifiedProperties ();
	}
}