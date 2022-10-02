function createCalculator() {
    let value = 0;
    return {
        add: function (num) { value += Number(num); },
        subtract: function (num) { value -= Number(num); },
        get: function () { return value; }
    }
}
createCalculator().add(2);
console.log(createCalculator().get.call(""));
module.exports = { createCalculator };