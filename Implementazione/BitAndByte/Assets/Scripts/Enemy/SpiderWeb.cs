using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour {

    private LineRenderer Line;
    private Transform tr;
    private DistanceJoint2D Joint;

    private Vector2 pos;


    private void Awake()
    {
        Line = GetComponent<LineRenderer>();
        Joint = GetComponent<DistanceJoint2D>();
        tr = GetComponent<Transform>();
        Line.positionCount = 2;
    }
	
	// Update is called once per frame
	void Update () {
        pos = new Vector2(tr.position.x, tr.position.y);
        Line.SetPosition(0, Joint.anchor + pos);
        Line.SetPosition(1,Joint.connectedAnchor);
		
	}
}
