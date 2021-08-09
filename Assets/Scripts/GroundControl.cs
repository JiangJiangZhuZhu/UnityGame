using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour
{
    // Start is called before the first frame update

    public float Speed = 10f;
    public GameObject[] GroundPrefabs;
    // Update is called once per frame
    void Update()
    {
        foreach (Transform tran in transform)
        {
            Vector3 pos = tran.position;
            pos.x -= Speed * Time.deltaTime;
            if (pos.x < -37.8f)
            {
                Transform newTrans = Instantiate(GroundPrefabs[Random.Range(0, GroundPrefabs.Length)], transform).transform;
                Vector2 newPos = newTrans.position;
                newPos.x = pos.x + 37.8f * 2;
                newTrans.position = newPos;
                Destroy(tran.gameObject);
            }
            tran.position = pos;
        }
    }
}
