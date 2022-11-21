using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisher : MonoBehaviour
{
    private GameObject _nearestFisherHut;
    private Vector3 _workingPosition;

    private Animator _animator;
    private static readonly int Fish = Animator.StringToHash("fish");
    private static readonly int Walk = Animator.StringToHash("walk");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnEnable()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("wood");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        _nearestFisherHut = closest;
    }

    private void IdleAction()
    {
        _workingPosition = _nearestFisherHut.transform.position;
        _animator.SetBool(Walk, false);
        _animator.SetBool(Fish, false);
    }

    private void MovingAction()
    {
        transform.Translate(_workingPosition * Time.deltaTime);
        _animator.SetBool(Walk, true);
        _animator.SetBool(Fish, false);
    }

    private void HarvestAction()
    {
        _animator.SetBool(Walk, false);
        _animator.SetBool(Fish, true);
    }
}