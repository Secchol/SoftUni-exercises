const { library } = require("./library");
const { assert } = require("chai");
describe("Tests …", function () {
    describe("calcPriceOfBook func", function () {
        it("calcPriceOfBook func works", function () {
            assert.equal(library.calcPriceOfBook("Ivan", 1200), `Price of Ivan is 10.00`);
            assert.equal(library.calcPriceOfBook("Ivan", 1980), `Price of Ivan is 10.00`);
            assert.equal(library.calcPriceOfBook("Ivan", 2050), `Price of Ivan is 20.00`);
        }),
            it("calcPriceOfBook func throws error with invalid input", () => {
                assert.throws(() => library.calcPriceOfBook(20, 1930), "Invalid input");
                assert.throws(() => library.calcPriceOfBook("sdfsdfa", 20.3), "Invalid input");
            })
    }),
        describe("findBook func", function () {
            it("findBook func works", function () {
                assert.equal(library.findBook(["Ivan", "Dg", "Patka"], "Patka"), "We found the book you want.");
                assert.equal(library.findBook(["Ivan", "Dg", "Patka"], "Kotka"), "The book you are looking for is not here!");

            }),
                it("findBook func throws error with invalid input", () => {
                    assert.throws(() => library.findBook([], "sdfas"), "No books currently available");
                })
        }),
        describe("arrangeTheBooks func", function () {
            it("arrangeTheBooks func works", function () {
                assert.equal(library.arrangeTheBooks(20), "Great job, the books are arranged.");
                assert.equal(library.arrangeTheBooks(40), "Great job, the books are arranged.");
                assert.equal(library.arrangeTheBooks(0), "Great job, the books are arranged.");
                assert.equal(library.arrangeTheBooks(41), "Insufficient space, more shelves need to be purchased.");

            }),
                it("arrangeTheBooks func throws error with invalid input", () => {
                    assert.throws(() => library.arrangeTheBooks(1.2), "Invalid input");
                    assert.throws(() => library.arrangeTheBooks(-2), "Invalid input");
                    assert.throws(() => library.arrangeTheBooks("sdfasdf"), "Invalid input");
                })
        })

});
