const { flowerShop } = require("./flowerShop.js");
const { assert } = require("chai");
describe("Tests …", function () {
    describe("calcPriceOfFlowers func", function () {
        it("calcPriceOfFlowers func works", function () {
            assert.equal(flowerShop.calcPriceOfFlowers("Minzuhar", 2, 2), `You need $4.00 to buy Minzuhar!`);
        }),
            it("calcPriceOfFlowers func throws exception with invalid input", () => {
                assert.throws(() => flowerShop.calcPriceOfFlowers(10, 20, 30), "Invalid input!");
                assert.throws(() => flowerShop.calcPriceOfFlowers(10, "mama", 30), "Invalid input!");
                assert.throws(() => flowerShop.calcPriceOfFlowers(10, 20, "mama"), "Invalid input!");
                assert.throws(() => flowerShop.calcPriceOfFlowers("sdfsdf", 20.4, 20), "Invalid input!");
                assert.throws(() => flowerShop.calcPriceOfFlowers("DFsdfsad", 23, 20.4), "Invalid input!");
            })
    }),
        describe("checkFlowersAvailable func", () => {
            it("check if func works", () => {
                assert.equal(flowerShop.checkFlowersAvailable("Magnolia", ["Magnolia", "Minzuhar"]), `The Magnolia are available!`);
                assert.equal(flowerShop.checkFlowersAvailable("Kukiche", ["Magnolia", "Riba"]), `The Kukiche are sold! You need to purchase more!`);
            })


        }),
        describe("sellFlowers func", () => {
            it("sellFlowers func works", () => {
                assert.equal(flowerShop.sellFlowers(["Magnolia", "Kukiche", "Martenica"], 1), "Magnolia / Martenica");
            }),
                it("sellFlowers throws exception with invalid input", () => {
                    assert.throws(() => flowerShop.sellFlowers("msdfds", 2), 'Invalid input!');
                    assert.throws(() => flowerShop.sellFlowers(["Madfsd", "Fdsfsdf"], 2.2), 'Invalid input!');
                    assert.throws(() => flowerShop.sellFlowers(["Madfsd", "Fdsfsdf"], "sdfsdf"), 'Invalid input!');
                    assert.throws(() => flowerShop.sellFlowers(["Madfsd", "Fdsfsdf"], -1), 'Invalid input!');
                    assert.throws(() => flowerShop.sellFlowers(["Madfsd", "Fdsfsdf"], 2), 'Invalid input!');
                    assert.throws(() => flowerShop.sellFlowers(["Madfsd", "Fdsfsdf"], 3), 'Invalid input!');
                })
        })

});
