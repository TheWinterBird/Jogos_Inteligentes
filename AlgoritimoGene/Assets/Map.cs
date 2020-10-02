using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public GameObject _wall;
    public GameObject _exit;
    public GameObject _start;
    public GameObject _path;
    public Vector2 startPosition;
    public Vector2 endPosition;


    public List<GameObject> pathTiles;

    public GA _Generic_Algorithm;

    public GameObject MazeTiles(int tile)
    {

        if (tile == 1) return _wall;
        if (tile == 8) return _start;
        if (tile == 9) return _exit;
        return null;


    }




    // startPosition = new Vector2(14f, 7f);
    //endPosition = new Vector2(0f, 2f);
    //fittestDirections = new List<int>();
    // pathTiles = new List<GameObject>();

    //geneticAlgorithm = new AG();
    // geneticAlgorithm.Map = this;
    //   geneticAlgorithm.Run();




    public void Start()
    {
      

        
    }
    public int[,] m_grid = new int[,]
        {
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,9 },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
        {1,0,0,0,1,0,1,1,1,0,0,0,1,1,0,1 },
        {1,0,0,1,1,0,1,1,1,0,0,1,1,1,0,1 },
        {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1 },
        {8,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }};
        









// public int[,] Grid {get => m_grid;}


/* public double TestRoute(List<int> directions)
 {
     Vector2 position = startPosition;

     for (int directionIndex = 0; directionIndex < directions.Count; directionIndex++)
     {
         int nextDirection = directions[directionIndex];
         position = Move(position, nextDirection);
     }

     Vector2 deltaPosition = new Vector2(
         Math.Abs(position.x - endPosition.x),
         Math.Abs(position.y - endPosition.y));
     double result = 1 / (double)(deltaPosition.x + deltaPosition.y + 1);
     if (result == 1)
         Debug.Log("TestRoute result=" + result + ",(" + position.x + "," + position.y + ")");
     return result;
 }*/

/*public void ClearPathTiles()
{

    foreach (GameObject pathTile in pathTiles)
    {
        Destroy(pathTile);

    }
    pathTiles.Clear();

}


public void RenderPath()
{
    ClearPathTiles();


}
*/


// Start is called before the first frame update


// Update is called once per frame
void Update()
    {
        
    }

}
