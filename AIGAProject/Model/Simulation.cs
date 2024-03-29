﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AIGAProject.Model
{
    class Simulation
    {
        Robots robots;
        Map map;
        const int ROBOT_RADIUS = 1;
        const int NUMBER_OF_ROBOTS = 10;
        const int NUMBER_OF_STEPS = 10;
        const int NUMBER_OF_GENERATIONS = 10;
        const double MUTATION_RATE = 0.05;

        public Simulation(Map map)
        {
            this.map = map;
            robots = new Robots(map.StartPoint, ROBOT_RADIUS, NUMBER_OF_ROBOTS, NUMBER_OF_STEPS);
        }

        public void Start()
        {
            for (int generations = 0; generations < NUMBER_OF_GENERATIONS; generations++)
            {
                //機器人重設（步數、地點）
                robots.Reset();
                //機器人動
                robots.StartToMove();
                //剔除後 50%
                robots.Selection(SelectMode.Distance);
                //交配
                robots.Crossover();
                //突變
                robots.Mutation(MUTATION_RATE);
            }
        }
    }
}
