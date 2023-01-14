using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    int amount;

    void Start() {
        GameObject[] collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        amount = collectibles.Length;
    }

    void CheckWin() {
        if (amount == 0) {
            Debug.Log("You win!");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectible")) {
            Destroy(other.gameObject);
            amount--;
        }
        CheckWin();
    }
}
