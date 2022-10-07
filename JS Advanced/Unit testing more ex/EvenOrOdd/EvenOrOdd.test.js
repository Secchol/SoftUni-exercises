const { isOddOrEven } = require("./EvenOrOdd");
const { assert } = require("chai");
describe("isOddOrEven func works", () => {
    it("works with valid input", () => {
        assert.equal(isOddOrEven("odd"), "odd");
        assert.equal(isOddOrEven("even"), "even");
    }),
        it("returns undefined if input is not string", () => {
            assert.equal(isOddOrEven(1231231231), undefined);
        })


})