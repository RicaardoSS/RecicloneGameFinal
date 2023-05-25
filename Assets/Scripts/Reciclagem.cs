using UnityEngine;
using Mirror;

public class Reciclagem : NetworkBehaviour
{
    public string lvlName;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isServer)
            return;

        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            NetworkManager networkManager = FindObjectOfType<NetworkManager>();
            networkManager.ServerChangeScene(lvlName);
        }
    }
}
