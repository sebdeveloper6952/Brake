using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CTileManager : MonoBehaviour
{
    public List<GameObject> road;
    public List<GameObject> leftSideW;
    public List<GameObject> rightSideW;


    private float xOff = 0.64f;
    private float yOff = 0.32f;
    private Vector3 offset;
    private int roadRendOrder;
    private int rSideWOrder;
    private int lSideWOrder;

	// Use this for initialization
	void Start ()
    {
        offset = new Vector3(xOff, yOff, 0f);
        roadRendOrder = -8; // right now there are 8 tiles.
        lSideWOrder = -9;
        rSideWOrder = -7;
	}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(Camera.main.transform.position, road[road.Count - 1].transform.position);
        //if last tile is offscreen, move it to the front
        if (distance >= 2.75f)
        {
            AdjustRoadTiles();
            AdjustSideWalks();
        }
    }

    private void AdjustRoadTiles()
    {
        GameObject tile = road[road.Count - 1]; // save the last tile
        road.RemoveAt(road.Count - 1); // remove the last tile from list
        road.Insert(0, tile); // insert the saved tile to the front of the list
        tile = road[0]; // save the first tile on the list
        tile.transform.position = road[1].transform.position + offset;

        // make sure the tiles are rendered in the correct order
        roadRendOrder = -8;
        for (int i = 0; i < road.Count; i++)
        {
            road[i].GetComponent<Renderer>().sortingOrder = roadRendOrder;
            roadRendOrder++;
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
        lSideWOrder = -9;
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
