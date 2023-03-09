using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	public static DontDestroy Instance;

	private void Start()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}
}
