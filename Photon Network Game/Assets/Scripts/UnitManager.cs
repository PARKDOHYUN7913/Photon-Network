using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class UnitManager : MonoBehaviourPunCallbacks
{
    private WaitForSeconds waitForSeconds = new WaitForSeconds(5.0f);

    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Creat());
        }
    }

    IEnumerator Creat()
    {
        while (true)
        {
            PhotonNetwork.Instantiate("Rake", new Vector3(0, 1, 0), Quaternion.identity);

            yield return waitForSeconds;
        }
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);

        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine (Creat());
        }
    }
}
