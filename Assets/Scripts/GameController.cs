using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    private RaycastHit[] hitResults ;
    
    private void Start()
    {
        hitResults = new RaycastHit[10];
    }

    private void Update()
    {
        Raycast();
    }

    public void Raycast()
    {
        int hits = Physics.RaycastNonAlloc(
            transform.position, transform.forward, hitResults, Mathf.Infinity);

        if (hits > 0) return;
        foreach (RaycastHit hit in hitResults)
        {
            if (hit.collider.CompareTag("Ignore Raycast"))
            {
                Debug.Log(hit.transform.name);

                hit.transform.SetPositionAndRotation(
                    hit.point,
                    Quaternion.Euler(Random.onUnitSphere * 360));
            }      
            Array.Clear(hitResults, 0, hitResults.Length);
        }
    }
}
