using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class RandomizePosition : NetworkBehaviour
{
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        base.OnStartAuthority();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(__RandomizePosition());
    }

    private IEnumerator __RandomizePosition()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);
        Vector3 startPosition = transform.position;

        while (true)
        {
            transform.position += startPosition + ReturnRandom();
            yield return wait;
        }
    }

    private Vector3 ReturnRandom()
    {
        return new Vector3(
            Random.Range(-4, 4),
            Random.Range(-4, 4),
            0
        );

    }
}
