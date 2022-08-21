using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return endurance;


            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Endurance should be between 0 and 100.");
                    
                }
                else
                {
                    endurance = value;

                }


            }
        }
        public int Sprint
        {
            get
            {
                return Sprint;


            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Sprint should be between 0 and 100.");

                }
                else
                {
                    sprint = value;

                }


            }
        }
        public int Dribble
        {
            get
            {
                return dribble;


            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Dribble should be between 0 and 100.");

                }
                else
                {
                    dribble = value;

                }


            }
        }
        public int Passing
        {
            get
            {
                return passing;


            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Passing should be between 0 and 100.");

                }
                else
                {
                    passing = value;

                }


            }
        }
        public int Shooting
        {
            get
            {
                return shooting;


            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Shooting should be between 0 and 100.");

                }
                else
                {
                    shooting = value;

                }


            }
        }

        public double Overall => (endurance + sprint + dribble + passing + shooting) / 5.0;
    }
}
