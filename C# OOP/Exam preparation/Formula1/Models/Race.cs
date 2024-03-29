﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            RaceName = raceName;
            NumberOfLaps = numberOfLaps;
            TookPlace = false;
            Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get => raceName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRaceName, value));

                }
                raceName = value;

            }

        }

        public int NumberOfLaps
        {
            get => numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));

                }
                numberOfLaps = value;
            }


        }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get; private set; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { RaceName } race has:");
            sb.AppendLine($"Participants: { Pilots.Count }");
            sb.AppendLine($"Number of laps: { NumberOfLaps }");
            sb.AppendLine($"Took place: {(TookPlace ? "Yes" : "No")}");
            return sb.ToString().TrimEnd();
        }
    }
}
