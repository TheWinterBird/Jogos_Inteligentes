using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;


public class GA 
{
    Genome[] m_Genomes;

  

    double m_CrossoverRate;
    double m_MutationRate;
    int m_PopulationSize;

    int m_Chromossomo_Lenght;

    int _GeneLenght;

    double m_BestFitnessScore;
    double m_TotalFitnessScore;

    public int FittestGenome { get => m_FittestGenome; }

    public int Generation { get => m_Generation; }

    public Map Brain { get => m_Brain; }

    public bool IsRunning { get => m_IsRunning; }

    Random m_Random;


    public GA(double crossoverRate, double mutationRate, int populationSize, int chromossomoLenght, int geneLenght) 
    {

        m_Random = new Random((int)DateTime.UtcNow.Ticks);

        m_Brain = new Map();

        m_CrossoverRate = crossoverRate;
        m_MutationRate = mutationRate;
        m_PopulationSize = populationSize;

        m_Chromossomo_Lenght = chromossomoLenght;

        _GeneLenght = geneLenght;

        m_IsRunning = false;

        CreateInitialPopulation();

        
    }

    private void CreateInitialPopulation() 
    {

        m_Genomes = new Genome[m_PopulationSize];
        for (int i = 0; i < m_PopulationSize; i++) 
        {

            m_Genomes[i] = new Genome(m_Chromossomo_Lenght);

        }

        m_BestFitnessScore = 0.0;
        m_TotalFitnessScore = 0.0;
        m_FittestGenome = 0;

        m_Generation = 0;

    }


    private void UpdateFitnessScore() 
    {
        m_FittestGenome = 0;
        m_BestFitnessScore = 0.0;
        m_TotalFitnessScore = 0.0;

        Map TempMemory = new Map();

        int[] Directions;

        for (int i = 0; i < m_PopulationSize; i++) 
        {
            Directions = Decode(m_Genomes[i].Bits);

            m_Genomes[i].Fitness = m_Brain.TestRoute(Directions, TempMemory);

            m_TotalFitnessScore = i;

            m_Brain.CopyMemoryfrom(TempMemory);


        }


    }


    private Genome Roullete()
    {
        double _FitnessSlice = m_Random.NextDouble() * m_TotalFitnessScore;
        double fitnessTotal = 0.0;
        int selectedGenome = 0;

        for (int i = 0; i < m_PopulationSize; ++i)
        {
            fitnessTotal += m_Genomes[i].Fitness;
            if (fitnessTotal > _FitnessSlice)
            {
                selectedGenome = i;
                break;
            }

        }
        return m_Genomes[selectedGenome];

    }

    private void Crossover(bool[] parent1, bool[] parent2, bool[] child1, bool[] child2)
    {

        if (m_Random.NextDouble() > m_CrossoverRate || parent1 == parent2)
        {
            for (int i = 0; i <parent1.Length; i++) {
                
                child1[i] = parent1[i];
                child2[i] = parent2[i];


            }

            return;

        }

        int crossoverPoint = m_Random.Next(0, m_Chromossomo_Lenght - 1);

        for (int i = 0; i < crossoverPoint; i++)
        {
            child1[i] = parent1[i];
            child2[i] = parent2[i];

        }

        for (int i = crossoverPoint; i < parent1.Length; i++)
        {

            child1[i] = parent2[i];
            child2[i] = parent1[i];


        }

    }

    private void Mutate(bool[] bits)
    {
        for (int CurrentBit = 0; CurrentBit < bits.Length; CurrentBit++)
        {
            if (m_Random.NextDouble() < m_MutationRate)
            {

                bits[CurrentBit] = !bits[CurrentBit];


            }

        }


    }


    public void Epoch()
    {

        UpdateFitnessScore();

        int _populationCurrentSize = 0;

        Genome[] newgenomes = new Genome[m_PopulationSize];

        while (_populationCurrentSize < m_PopulationSize) 
        {
            Genome parent1 = Roullete();
            Genome parent2 = Roullete();

            Genome child1 = new Genome(parent1.Size);
            Genome child2 = new Genome(parent1.Size);
            Crossover(parent1.Bits, parent2.Bits, child1, Bits, child1.Bits);

            Mutate(child1.Bits);
            Mutate(child2.Bits);

            newgenomes[_populationCurrentSize] = child1;
            newgenomes[_populationCurrentSize + 1] = child2;

            _populationCurrentSize += 2;


        }

        for (int i = 0; i < m_Genomes.Length; ++i)
        {
            m_Genomes[i] = newgenomes[i];

        }

        ++m_Geberation;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
