const { cinema } = require("./cinema");
const { assert } = require("chai");
describe("Tests …", function () {
    describe("showMovies func", function () {
        it("showMovies func works", function () {
            assert.equal(cinema.showMovies(["1", "2", "3"]), "1, 2, 3");
            assert.equal(cinema.showMovies(["Im", "Very", "Good"]), "Im, Very, Good");
        }),
            it("showMovies func returns message with invalid input", () => {
                assert.equal(cinema.showMovies([]), 'There are currently no movies to show.');
            })
    }),
        describe("ticketPrice func", function () {
            it("ticketPrice func works", function () {
                assert.equal(cinema.ticketPrice("Premiere"), 12.00);
                assert.equal(cinema.ticketPrice("Normal"), 7.50);
                assert.equal(cinema.ticketPrice("Discount"), 5.50);
            }),
                it("ticketPrice func returns error with invalid input value", () => {
                    assert.throws(() => cinema.ticketPrice("Yok"), 'Invalid projection type.');
                    assert.throws(() => cinema.ticketPrice("normal"), 'Invalid projection type.');
                    assert.throws(() => cinema.ticketPrice("discount"), 'Invalid projection type.');
                    assert.throws(() => cinema.ticketPrice("premiere"), 'Invalid projection type.');
                })
        }),
        describe("swapSeatsInHall func", function () {
            it("swapSeatsInHall func works", function () {
                assert.equal(cinema.swapSeatsInHall(1, 2), "Successful change of seats in the hall.");
                assert.equal(cinema.swapSeatsInHall(19, 20), "Successful change of seats in the hall.");
                assert.equal(cinema.swapSeatsInHall(20, 19), "Successful change of seats in the hall.");


            }),
                it("swapSeatsInHall func returns error with invalid input value", () => {
                    assert.equal(cinema.swapSeatsInHall(1.2, 2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall("sdfsd", 2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(-2, 2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(0, 2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(21, 2), "Unsuccessful change of seats in the hall.");


                    assert.equal(cinema.swapSeatsInHall(2, 1.2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(2, "dsfsd"), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(2, -2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(2, 0), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(2, 21), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall("2", 2), "Unsuccessful change of seats in the hall.");
                    assert.equal(cinema.swapSeatsInHall(2, 2), "Unsuccessful change of seats in the hall.");
                })
        })

});
