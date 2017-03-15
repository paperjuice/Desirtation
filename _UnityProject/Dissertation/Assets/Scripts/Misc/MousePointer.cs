using System.Collections;
using UnityEngine;

public class MousePointer : MonoBehaviour {

	
[SerializeField] Texture2D[] textures;

	IEnumerator Start()
	{
		while(true)
		{
			foreach(Texture2D t in textures)
			{
				Cursor.SetCursor(t, Vector2.zero, CursorMode.Auto);
				yield return new WaitForSeconds(0.1f);
			}
		}
	}



}
