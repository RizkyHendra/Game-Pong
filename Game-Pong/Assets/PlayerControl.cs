using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    // Tombol menggerakan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol Menggerakan ke bawah
    public KeyCode downButton = KeyCode.S;

    // kecepetan gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game  scene (Batas bawah menggunakan minus(-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D raket ini
    private Rigidbody2D rigidBody2D;

    // Skor Pemain
    public int score;

    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    { 
        get { return lastContactPoint; }
    
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    // Menaikan skor sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai score
    public int Score
    { 
        get { return score; }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang
        Vector2 velocity = rigidBody2D.velocity;

        // Jika pemain menekan tombol atas, beri keceptana positif ke komponen y (ke atas).
        if(Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekana tombol kebawah, beri kecepetan negatif ke komponen y (ke bawah)
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa-apa, keceptan nol.
        else
        {
            velocity.y = 0.0f;
        }

        // Masukan kembali kecepetanya ke rigidBody2D.
        rigidBody2D.velocity = velocity;

        // Dapatkan posisi raket sekarang
        Vector3 position = transform.position;

        // Jika posisi raket melawati batas atas (yBoundary), kembalikan ke batas atas tersebut.
        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut.
        else if(position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukan kembali posisinya ke transform.
        transform.position = position;
    }
}
