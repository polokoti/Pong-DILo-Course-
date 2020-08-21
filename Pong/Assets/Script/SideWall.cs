using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    //player akan bertambah skorya jika bola menngenai objek ini (tembok) 
    public PlayerControl player;
    //script untuk akses ke gameManager untuk dapetin skor maksimal
    [SerializeField] private GameManager gameManager;

    //dipanggil ketika objek menyentuh dinding
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        //jika objek yang bersentuhan bernama "Ball"
        if (anotherCollider.name =="Ball")
        {
            //skor bertambah ke pemain
            player.IncrementScore();

            //jika player belum mencapai skor maksimal
            if(player.Score < gameManager.maxScore)
            {
                //restart game setelah mengenai dinding
                anotherCollider.gameObject.SendMessage("Restart Game", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }

}
