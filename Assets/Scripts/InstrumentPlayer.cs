using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstrumentPlayer : MonoBehaviour {
    public float InstrumentRadius = 1f;
    public List<PartyBehaviour> Followers = new List<PartyBehaviour>();
    private float instrumentHorizontal;
    private float instrumentVertical;

    
    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Gather();
        }

    }

    public void Gather() {
        var nearbyParade = Physics2D.OverlapCircleAll(transform.position, this.InstrumentRadius, LayerMask.GetMask("Parade"));

        foreach (var partygoer in nearbyParade) {
            var partyBehaviour = partygoer.GetComponent<PartyBehaviour>();
            partyBehaviour.toFollow = this.transform;
            this.Followers.Add(partyBehaviour);
        }
    }
}
