using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerMovement playerMovement;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.name == "MapBottom")
        {
            gameObject.SetActive(false);
            Events.PlayerDeath();
        }
        else if (other.collider.gameObject.name == "WinLocation")
        {
            Events.PlayerWin();
        }
        else if (other.collider.gameObject.name.Contains("WeaponUpgrade"))
        {
            Events.WeaponUpgradePickup(other.gameObject.GetComponent<WeaponUpgrade>().weaponUpgradeData, other.gameObject.name);
            Destroy(other.gameObject);
        }
        else if (other.collider.gameObject.name.Contains("SavePoint"))
        {
            Events.SaveGame(other.gameObject.name);
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Platform"))
        {
            playerMovement.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Platform")){
            playerMovement.transform.parent = null;
        }
    }
}
