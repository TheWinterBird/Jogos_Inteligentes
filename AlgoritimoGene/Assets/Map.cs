using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algoritimo_G : MonoBehaviour
{
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

    public int[,] Grid {get => m_grid;}

    public struct Genome
    {
        bool[] m_Bits;
        public bool[] Bits;

        double m_Fitness;
        public double Fitness;

        public int Size { get => m_Bits.Lenght;}

        public Genome(int Size)
            {
            Random random = new Random((int)DateTime.UtcNow.Ticks);

            m_Bits = new bool[Size];
            for (int i = 0; i < Size; i++) 
            {
                m_Bits[i] = random.NextDouble() < 0.5;
            }

            m_Fitness = 0.0;


            }
}





    


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

}
