using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.jesusnoseq.util
{
    public class PlayerSpawn : MonoBehaviour {
        [SerializeField]
        GameObject playerPrefab;

        // Use this for initialization
        void Awake () {
            if (GameObject.Find("Player")==null)
            {
                GameObject player = Instantiate(playerPrefab);
                player.name = "Player";
                player.transform.position = this.transform.position;
            }
        }
    }
}