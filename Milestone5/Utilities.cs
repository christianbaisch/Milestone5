using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class Utilities : MonoBehaviour
{
    public static string ProcessText(string textIn)
    {
        try
        {
            float result = float.Parse(textIn);
            textIn = "Number";
        }
        catch (FormatException)
        {
            textIn = "String";
        }
        return textIn;
        //return the word "string" if the user enters string
        //return number if number inclues decimals
    }

    public static string AverageChar(string textIn)
    {
        
        float myLength = 0;
    
        string[] words = textIn.Split(' ');
        
        
        foreach(string word in words)
        {
           myLength = myLength + word.Length;
        }
        myLength = myLength / words.Length;

        textIn = myLength.ToString();
        return textIn;

    }

    static public Material[] GetAllMaterials(GameObject go){
        Renderer[] rends = go.GetComponentsInChildren<Renderer>();

        List<Material> mats = new List<Material>();
        foreach (Renderer rend in rends){
            mats.Add( rend.material);
        }

        return ( mats.ToArray() );
    }

    public void StartMovingTo (Vector3 position)
	{
		if (shouldIgnoreHeightOfDestination)
			position.y = transform.position.y;

		GetComponent<Navigator> ().targetPosition = position;
	}

	// Stop moving completely.
	public void StopMoving ()
	{
		GetComponent<Navigator> ().targetPosition = transform.position;
		currentPath = null;
	}

    /** Return what layers are included in this LayerMask. */
		public static List<int> GetLayers (this LayerMask layerMask)
		{
			var layers = new List<int> ();
			for (int mask = layerMask.value, layer = 0; mask != 0; mask = mask >> 1, layer++)
			{
				if ((mask & 1) != 0)
					layers.Add (layer);
			}

		/** Returns a copy of this vector with the given x component. */
		public static Vector3 WithX (this Vector3 vec, float x)
		{
			return new Vector3(x, vec.y, vec.z);
		}

		/** Returns a copy of this vector with the given y component. */
		public static Vector3 WithY (this Vector3 vec, float y)
		{
			return new Vector3(vec.x, y, vec.z);
		}

		/** Returns a copy of this vector with the given z component. */
		public static Vector3 WithZ (this Vector3 vec, float z)
		{
			return new Vector3(vec.x, vec.y, z);
		}

        public transform resetPosition(GameObject ob)
        {
            ob.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
            return ob.transform;
        }

        public void ShowAddJobWindow(GameObject personSlot)
    {
        addJobWindow.SetActive(true);
        addJobWindow.GetComponent<AddJobWindow>().selectedPerson = personSlot;

        addJobWindow.GetComponent<RectTransform>().position = personSlot.transform.position +  new Vector3(0,10,0);
        addJobWindow.GetComponent<RectTransform>().transform.LookAt(Camera.main.transform.position +    Camera.main.transform.forward * 10000);
        
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(10);
        Scene loadedLevel = SceneManager.GetActiveScene ();
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
    }


    
}