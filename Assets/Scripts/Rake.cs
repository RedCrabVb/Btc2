using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rake : MonoBehaviour
{
    [SerializeField] private GameObject M_colider;
    [SerializeField] private Transform M_parint;
    [SerializeField] private GameObject particalSysteam;
    [SerializeField] private Starvation starvation;
    [SerializeField] private MatchesController matchesController;
    [SerializeField] public bool button_Control_Android = false;
    [SerializeField] private bool go = false;
    [SerializeField] private Food food;

    public void EatFood()
    {
        if (food != null && M_colider != null)
        {
            food.Eat = true;
            particalSysteam.SetActive(true);
        }
    }

    public void EatStop()
    {
        if (food != null && M_colider != null)
        {
            food.Eat = false;
            particalSysteam.SetActive(false);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<CardboardBox>() 
            || other.GetComponent<Food>() 
            || other.GetComponent<Matchstic>())
        {
            if (M_colider == null)
            {
                go = false;
            }
            if (button_Control_Android && go == false)
            {
                M_colider = other.gameObject;
                M_colider.transform.parent = M_parint.transform;
                M_colider.GetComponent<Rigidbody>().useGravity = false;
                M_colider.GetComponent<Rigidbody>().angularDrag = 5;
                M_colider.GetComponent<Rigidbody>().drag = 5;
                go = true;

                if (M_colider.GetComponent<Food>())
                {
                    food = M_colider.GetComponent<Food>();
                    food.SetDependenciesPlayer(starvation, this);
                }
                if (M_colider.GetComponent<Matchstic>())
                {
                    matchesController.Add();
                    Destroy(M_colider);
                }
            }
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        CancelHold();
    }

    private void Update()
    {
        if (go = true && !button_Control_Android)
        {
            CancelHold();
        }
    }

    public void CancelHold() {
        EatStop();
        food = null;
        if (M_colider != null)
        {
            M_colider.transform.parent = null;
            M_colider.GetComponent<Rigidbody>().useGravity = true;
            M_colider.GetComponent<Rigidbody>().angularDrag = 0.05f;
            M_colider.GetComponent<Rigidbody>().drag = 0;
            M_colider = null;
        }
    }
}
