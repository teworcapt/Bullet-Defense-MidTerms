using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public GameObject Mechs, Instruct, EndScreen, player;
    public bool playerHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHit == true)
        {
            Mechs.SetActive(false);
            Instruct.SetActive(false);
            EndScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Player"))
        {
            playerHit = true;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
