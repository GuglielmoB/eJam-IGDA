using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyBehaviour : MonoBehaviour {
    public float Speed = 1f;
    public float FollowDistance = 1.5f;
    public Transform toFollow;

    private Rigidbody2D _rigidbody2D;

    private void Awake() {
        this._rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (this.toFollow != null) {
            this.Follow();
        }
        
    }

    public void Follow() {
        Vector3 direction = this.toFollow.position - this.transform.position;
        if (Vector3.Distance(this.toFollow.position, transform.position) > this.FollowDistance) {
            Debug.Log(Vector3.Distance(this.toFollow.position, transform.position));
            this._rigidbody2D.MovePosition(transform.position + Time.fixedDeltaTime * this.Speed * direction.normalized);
        }
        
    }
}
