using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    [SerializeField] private int HP;   //other cannot access or modify the HP
    public int currentHP { get => HP; }   //get HP
    public int maxHP;

    float hoz;
    float ver;
    [Range(0,20f)]
    public float movementSpeed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hoz = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        //transform.position += (new Vector3(hoz, ver, 0))*movementSpeed;
        //transform.position = transform.position + new 

        //print("x Input: "+xInput);
        //print("y Input");
    }
    private void FixedUpdate()
    {
        Vector2 positionToMove = new Vector2(hoz, ver) * movementSpeed * Time.fixedDeltaTime;
        Vector2 newPos = (Vector2)transform.position + positionToMove;
        rb.MovePosition(newPos);
    }

    public void ChangeHP(int value)
    {
        HP += value;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
        if (HP < 0)
        {
            HP = 0;
        }

        HP = Mathf.Clamp(HP, 0, maxHP);
        Debug.Log("player hp is now" + HP);
    }
}
