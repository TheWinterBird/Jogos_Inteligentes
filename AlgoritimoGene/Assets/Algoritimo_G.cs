using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class Map : MonoBehaviour
{

    public GameObject _wall;
    public GameObject _exit;
    public GameObject _start;
    public GameObject _path;

    public List<GameObject> pathTiles;

    public GA _Generic_Algorithm;

    public GameObject MazeTiles(int tile) 
    {

        if (tile == 1) return _wall;
        if (tile == 8) return _start;
        if (tile == 9) return _exit;
        return null;


    }



    static readonly int[,] m_grid = new int[,]
{
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        {1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,9 },
        {1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1 },
        {1,0,0,0,1,0,1,1,1,0,0,0,1,1,0,1 },
        {1,0,0,1,1,0,1,1,1,0,0,1,1,1,0,1 },
        {1,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1 },
        {8,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1 },
        {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 }
};

    public int[,] Grid { get => m_grid; }



    public void Start()
    {
     
}

    public void ClearPathTiles() 
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


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (_Generic_Algorithm.IsRunning) _Generic_Algorithm.Epoch();
        


    }

}
