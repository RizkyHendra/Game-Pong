using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BallControl : MonoBehaviour
{
    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;
    private Vector2 trajectoryOrigin;

    // Apakah debug window ditampilkan ?
    


    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    
    void ResetBall()
    {
        // Reset posisi menjadi(0,0)
        transform.position = Vector2.zero;

        // Reset kecepetan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInutialForce
        float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (ekslusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri
        // Jika tidak, bola bergerak ke kanan

        if(randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakan bola ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }

        
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Mulai Game
        RestartGame();

        trajectoryOrigin = transform.position;
        
    }

    private void OncollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    { 
        get { return trajectoryOrigin; }
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
