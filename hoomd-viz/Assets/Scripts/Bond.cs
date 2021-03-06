﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bond : MonoBehaviour
{
    public int a1 = -1;
    public int a2 = -1;
    public int type = -1;

    public GameObject atom1;
    public GameObject atom2;

    public float atom_scale = 0.05f;

    // Update is called once per frame
    void Update()
    {
        if (a1 != -1 && a2 != -1 && type != -1)
        {
            //transform.position = 0.5f*(atom2.transform.position + atom1.transform.position);
            //transform.LookAt(atom2.transform);

            float width = atom1.transform.localScale.x / 5.0f;
            Vector3 pos_delta = atom2.transform.position - atom1.transform.position;
            Vector3 scale = new Vector3(width, pos_delta.magnitude / 2.0f, width);
            if (scale.magnitude >= atom_scale*20.0f)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            transform.position = atom1.transform.position + (pos_delta / 2.0f);
            transform.up = pos_delta;
            transform.localScale = scale;
        }

        if (!atom1.activeInHierarchy || !atom2.activeInHierarchy)
        {
            //gameObject.SetActive(false);
            GetComponent<MeshRenderer>().enabled = false;
        } else
        {
            if (!gameObject.activeInHierarchy)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
