﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _IndividualInteraction : MonoBehaviour {

    public GameObject textbox;
    [HideInInspector]
    public bool _BoxDisplaced;
	// Use this for initialization
	void Start () {
        textbox.SetActive(false);
        _BoxDisplaced = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BoxTestInteraction()
    {
        textbox.SetActive(!textbox.activeSelf);
        bool activeText = GameObject.Find("Dialogue_Manager").GetComponent<Dialogue>().active;

        GameObject.Find("Dialogue_Manager").GetComponent<Dialogue>().active = !activeText;
    }

    IEnumerator Displace(float v, float old, float t)
    {
        float start = old;
        for(float i = 0.0f; i < 1.0f; i += Time.deltaTime / t)
        {
            float newV = Mathf.Lerp(start, v, t);
            GetComponent<Renderer>().material.SetFloat("_Displacement", newV);
            yield return null;
        }
    }

    public void BoxDisplacement()
    {
        _BoxDisplaced = !_BoxDisplaced;

        if (_BoxDisplaced)
        {
            StartCoroutine(Displace(0.0f, 5.0f, 0f));
            GetComponent<BoxCollider>().size = new Vector3(5f, 5f, 5f);
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
        else
        {
            StartCoroutine(Displace(5.0f, 0.0f, 0f));
            GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        }

    }
}