using System;
using UnityEngine;

public class Movement2D : MonoBehaviour {
    public float Speed;

    private Rigidbody2D _rigidbody2D;
    private float movementHorizontal;
    private float movementVertical;
    private Vector2 movement;
    
    
    private void Awake() {
        this._rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.movementHorizontal = Input.GetAxisRaw("Horizontal");
        this.movementVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(this.movementHorizontal, this.movementVertical).normalized;
    }

    private void FixedUpdate() {
        this._rigidbody2D.MovePosition(this._rigidbody2D.position + Time.fixedDeltaTime * this.Speed * this.movement);
    }
}
