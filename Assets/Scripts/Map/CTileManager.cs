using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CTileManager : MonoBehaviour
{
    public List<GameObject> leftSide;
    public List<GameObject> rightSide;
    public List<GameObject> leftSideW;
    public List<GameObject> rightSideW;


    private float xOff = 0.64f;
    private float yOff = 0.32f;
    private Vector3 offset;
    private int leftRoadOrder;
    private int rightRoadOrder;
    private int rSideWOrder;
    private int lSideWOrder;

	// Use this for initialization
	void Start ()
    {
        offset = new Vector3(xOff, yOff, 0f);
        leftRoadOrder = -9; // right now there are 8 tiles.
        rightRoadOrder = -8;
        lSideWOrder = -10;
        rSideWOrder = -7;
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Camera.main.transform.position, leftSide[leftSide.Count - 1].transform.position);
        //if last tile is offscreen, move it to the front
        if (distance >= 2.75f)
        {
            AdjustRoadTiles();
            AdjustSideWalks();
        }
    }

    private void AdjustRoadTiles()
    {
        GameObject leftTile = leftSide[leftSide.Count - 1]; // save the last tile
        GameObject rightTile = rightSide[rightSide.Count - 1];
        //left side
        leftSide.RemoveAt(leftSide.Count - 1); // remove the last tile from list
        leftSide.Insert(0, leftTile); // insert the saved tile to the front of the list
        leftTile = leftSide[0]; // save the first tile on the list
        leftTile.transform.position = leftSide[1].transform.position + offset;
        //right side
        rightSide.RemoveAt(rightSide.Count - 1); // remove the last tile from list
        rightSide.Insert(0, rightTile); // insert the saved tile to the front of the list
        rightTile = rightSide[0]; // save the first tile on the list
        rightTile.transform.position = rightSide[1].transform.position + offset;

        // make sure the tiles are rendered in the correct order
        leftRoadOrder = -9;
        rightRoadOrder = -8;
        for (int i = 0; i < leftSide.Count; i++)
        {
            leftSide[i].GetComponent<Renderer>().sortingOrder = leftRoadOrder;
            rightSide[i].GetComponent<Renderer>().sortingOrder = rightRoadOrder;
            leftRoadOrder++;
            rightRoadOrder++;
        }
    }

    private void AdjustSideWalks()
    {
        GameObject lSide = leftSideW[leftSideW.Count - 1];
        GameObject rSide = rightSideW[rightSideW.Count - 1];
        leftSideW.RemoveAt(leftSideW.Count - 1);
        rightSideW.RemoveAt(rightSideW.Count - 1);
        leftSideW.Insert(0, lSide);
        rightSideW.Insert(0, rSide);
        lSide = leftSideW[0];
        rSide = rightSideW[0];
        lSide.transform.position = leftSideW[1].transform.position + offset;
        rSide.transform.position = rightSideW[1].transform.position + offset;
        // adjust rendering order
        lSideWOrder = -10;
        rSideWOrder = -7;
        for(int i = 0; i < rightSideW.Count; i++)
        {
            leftSideW[i].GetComponent<Renderer>().sortingOrder = lSideWOrder;
            rightSideW[i].GetComponent<Renderer>().sortingOrder = rSideWOrder;
            lSideWOrder++;
            rSideWOrder++;
        }
    }
}
