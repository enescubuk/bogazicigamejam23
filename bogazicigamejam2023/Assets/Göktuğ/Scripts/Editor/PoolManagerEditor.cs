using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(PoolManager))]
public class PoolManagerEditor : Editor {

	PoolManager pool;
	void OnEnable(){
		pool = (PoolManager)target;
	}
	public override void OnInspectorGUI () {

		GUILayout.Space (10);
		GUILayout.BeginVertical ("Box");
		GUILayout.Label ("Pool Manager");
		GUILayout.BeginHorizontal();
		GUILayout.Label ("Object in Pool: "+pool.objectPrefabs.Count.ToString());
		pool.defaultBufferAmount= (int)EditorGUILayout.IntField("Default Amount:",pool.defaultBufferAmount, GUILayout.MinWidth(100));
		GUILayout.EndHorizontal();
		GUILayout.Space (10);
		GUILayout.EndVertical ();
		GUILayout.Space (10);
		if (GUILayout.Button ("Add Object to Pool")) {
			addObject();
		}
		GUILayout.Space (10);
		for (int cnt=0; cnt<pool.objectPrefabs.Count; cnt++) {
			GUILayout.BeginHorizontal();
			pool.objectPrefabs[cnt] = (GameObject)EditorGUILayout.ObjectField(pool.objectPrefabs[cnt],typeof(GameObject),true, GUILayout.MinWidth(100));
			pool.amountToBuffer[cnt]= (int)EditorGUILayout.IntField(pool.amountToBuffer[cnt], GUILayout.MinWidth(50),GUILayout.MaxWidth(100));
			if (GUILayout.Button ("-",GUILayout.ExpandWidth(false))) {
				removeObject(cnt);
				return;
			}
			GUILayout.EndHorizontal();
		}
		GUILayout.Space (10);
        if (GUILayout.Button("Add Ui Object to Pool"))
        {
            addUiObject();
        }
        GUILayout.Space(10);
        for (int cnt = 0; cnt < pool.uiObjectPrefabs.Count; cnt++)
        {
            GUILayout.BeginHorizontal();
            pool.uiObjectPrefabs[cnt] = (GameObject)EditorGUILayout.ObjectField(pool.uiObjectPrefabs[cnt], typeof(GameObject), true, GUILayout.MinWidth(100));
            pool.amountToUiBuffer[cnt] = (int)EditorGUILayout.IntField(pool.amountToUiBuffer[cnt], GUILayout.MinWidth(50), GUILayout.MaxWidth(100));
            if (GUILayout.Button("-", GUILayout.ExpandWidth(false)))
            {
                removeUiObject(cnt);
                return;
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.Space(10);
        //	base.OnInspectorGUI ();

    }

	// Normal Object
	public void addObject(){
		pool.objectPrefabs.Add(null);
		pool.amountToBuffer.Add (pool.defaultBufferAmount);
	}
    public void removeObject(int index){
		pool.objectPrefabs.RemoveAt(index);
		pool.amountToBuffer.RemoveAt(index);
	}

	// Ui Object
    public void addUiObject()
    {
        pool.uiObjectPrefabs.Add(null);
        pool.amountToUiBuffer.Add(pool.defaultBufferAmount);
    }
    public void removeUiObject(int index)
    {
        pool.uiObjectPrefabs.RemoveAt(index);
        pool.amountToUiBuffer.RemoveAt(index);
    }
}
