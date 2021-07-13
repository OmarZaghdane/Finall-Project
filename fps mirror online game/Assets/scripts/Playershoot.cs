using UnityEngine;
using Mirror;

public class Playershoot : NetworkBehaviour
{
    public Playerweapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask Mask;
  
    void Start()
    {
        if(cam == null)
        {
            Debug.Log("no camera on shoot system");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    [Client]
    void Shoot()
    {
        RaycastHit hit;

       if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, Mask ) )
       {
            if(hit.collider.tag == "Player")
            {
                CmdPlayerShot(hit.collider.name);
            }
       }
    }

    [Command]
    private void CmdPlayerShot(string playerName)
    {
        Debug.Log(playerName + "a ete touche");
    }
}
