using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
        StartCoroutine(nameof(FindPlayer));
    }

    // Update is called once per frame
    private IEnumerator FindPlayer()
    {
        while (true)
        {
            GameObject[] list = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in list)
            {
                NetworkIdentity identity = player.GetComponent<NetworkIdentity>();
                if (identity == null) continue;
                if (identity.isLocalPlayer)
                {
                    _camera.LookAt = identity.transform;
                    _camera.Follow = identity.transform;
                    break;
                }
            }
            yield return new WaitForSeconds(.1f);
        }
    }
}
