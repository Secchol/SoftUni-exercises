function TownPopulation(towns) {
    let townsObj = {};
    towns = towns.map(x => x.split(" <-> "));
    for (town of towns) {
        let townName = town[0];
        let townPopulation = town[1];
        if ( typeof townsObj[townName] == 'undefined') {
            townsObj[townName] = 0;
        }
        townsObj[townName] += Number(townPopulation);
    }
    for (town in townsObj) {
        console.log(`${town} : ${townsObj[town]}`);
    }


}
TownPopulation(['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
);
TownPopulation(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
);