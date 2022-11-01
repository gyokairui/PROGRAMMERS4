using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public GameObject Panel;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{

			Panel.SetActive(false);

		}

		if (Input.GetKey(KeyCode.Space))
		{

			Panel.SetActive(true);

		}

	}
}