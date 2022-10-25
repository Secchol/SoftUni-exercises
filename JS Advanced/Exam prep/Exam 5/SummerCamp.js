class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }
    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp.hasOwnProperty(condition)) {
            throw new Error("Unsuccessful registration at the camp.");
        }
        else if (this.listOfParticipants.some(x => x.name == name)) {
            return `The ${name} is already registered at the camp.`;
        }
        else if (Number(money) < Number(this.priceForTheCamp[condition])) {
            return `The money is not enough to pay the stay at the camp.`;
        }
        else {
            this.listOfParticipants.push({ name, condition, power: 100, wins: 0 });
            return `The ${name} was successfully registered.`;
        }
    }
    unregisterParticipant(name) {
        if (!this.listOfParticipants.some(x => x.name == name)) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        else {
            this.listOfParticipants.splice(this.listOfParticipants.indexOf(this.listOfParticipants.find(x => x.name == name)), 1);
            return `The ${name} removed successfully.`;
        }
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame == "Battleship") {
            if (!this.listOfParticipants.some(x => x.name == participant1)) {
                throw new Error(`Invalid entered name/s.`);
            }
            const firstPlayer = this.listOfParticipants.find(x => x.name == participant1);
            firstPlayer.power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }
        else if (typeOfGame == "WaterBalloonFights") {
            if (!this.listOfParticipants.some(x => x.name == participant1) || !this.listOfParticipants.some(x => x.name == participant2)) {
                throw new Error(`Invalid entered name/s.`);
            }
            const firstPlayer = this.listOfParticipants.find(x => x.name == participant1);
            const secondPlayer = this.listOfParticipants.find(x => x.name == participant2);
            if (firstPlayer.condition != secondPlayer.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (firstPlayer.power > secondPlayer.power) {
                firstPlayer.wins++;
                return `The ${firstPlayer.name} is winner in the game ${typeOfGame}.`;
            }
            else if (firstPlayer.power < secondPlayer.power) {
                secondPlayer.wins++;
                return `The ${secondPlayer.name} is winner in the game ${typeOfGame}.`;
            }
            else {
                return `There is no winner.`;
            }
        }
    }
    toString() {
        let output = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`;
        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        this.listOfParticipants.forEach(person => {
            output += `\n${person.name} - ${person.condition} - ${person.power} - ${person.wins}`;
        })
        return output;
    }
}


