using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    IEnumerator Start()
    {
        Debug.Log("Start");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("End");
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
    }
    void Test1()
    {
        Debug.Log("The first method is running");
    }
    void Test2()
    {
        Debug.Log("The second method is running");
    }
    IEnumerator Test3(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Co-routine Running!");
        yield return new WaitForSeconds(4.0f);
        Debug.Log("4 seconds after");
    }
}
