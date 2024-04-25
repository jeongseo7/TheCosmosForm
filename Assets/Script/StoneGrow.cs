using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGrow : MonoBehaviour
{
    [SerializeField] GameObject GrowObject1;
    [SerializeField] GameObject GrowObject2;
    [SerializeField] GameObject GrowObject3;
    [SerializeField] GameObject GrowObject4;
    [SerializeField] GameObject GrowObject5;

    [SerializeField] float hideSeconds = 3;
    
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        
        yield return new WaitForSeconds(hideSeconds);
        GrowObject1.SetActive(false);
        GrowObject2.SetActive(true);
        yield return new WaitForSeconds(hideSeconds * 3);
        GrowObject2.SetActive(false);
        GrowObject3.SetActive(true);
        yield return new WaitForSeconds(hideSeconds * 4);
        GrowObject3.SetActive(false);
        GrowObject4.SetActive(true);
        yield return new WaitForSeconds(hideSeconds * 5);
        GrowObject4.SetActive(false);
        GrowObject5.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
