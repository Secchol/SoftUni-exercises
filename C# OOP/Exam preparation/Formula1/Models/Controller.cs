using Formula1.Core.Contracts;
using Formula1.Models.Cars;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Models
{
    public class Controller : IController
    {
        private FormulaOneCarRepository carRepository;
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        public Controller()
        {
            carRepository = new FormulaOneCarRepository();
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();

        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            if (pilotRepository.FindByName(pilotName) == null || pilotRepository.FindByName(pilotName).Car != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));


            }
            else if (carRepository.FindByName(carModel) == null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");

            }
            IFormulaOneCar car = carRepository.FindByName(carModel);
            IPilot pilot = pilotRepository.FindByName(pilotName);
            pilot.AddCar(car);
            carRepository.Remove(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { car.Model } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            }
            else if (pilotRepository.FindByName(pilotFullName) == null || !pilotRepository.FindByName(pilotFullName).CanRace || raceRepository.FindByName(raceName).Pilots.Any(x => x.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");


            }
            raceRepository.FindByName(raceName).AddPilot(pilotRepository.FindByName(pilotFullName));
            return $"Pilot { pilotFullName } is added to the { raceName } race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarExistErrorMessage, model));

            }
            IFormulaOneCar car;
            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);

            }
            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);

            }
            else
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");

            }
            carRepository.Add(car);
            return $"Car { car.GetType().Name }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotExistErrorMessage, fullName));

            }
            pilotRepository.Add(new Pilot(fullName));
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));


            }
            raceRepository.Add(new Race(raceName, numberOfLaps));
            return $"Race { raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pilot in pilotRepository.Models.OrderByDescending(x => x.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());

            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Race race in raceRepository.Models.Where(x => x.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());

            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            if (raceRepository.FindByName(raceName) == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));

            }
            else if (raceRepository.FindByName(raceName).Pilots.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRaceParticipants, raceName));

            }
            else if (raceRepository.FindByName(raceName).TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");

            }
            IRace race = raceRepository.FindByName(raceName);
            List<IPilot> pilots = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).Take(3).ToList();
            StringBuilder sb = new StringBuilder();
            race.TookPlace = true;
            pilots[0].WinRace();
            sb.AppendLine($"Pilot { pilots[0].FullName } wins the { raceName } race.");
            sb.AppendLine($"Pilot { pilots[1].FullName } is second in the { raceName } race.");
            sb.AppendLine($"Pilot { pilots[2].FullName } is third in the { raceName } race.");
            return sb.ToString().TrimEnd();
        }
        public void Exit()
        {
            Environment.Exit(0);

        }
    }
}
