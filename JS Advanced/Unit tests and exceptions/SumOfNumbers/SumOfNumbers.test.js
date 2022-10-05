const { assert } = require("chai");
const { sum } = require("./SumOfNumbers");

describe("sum func functionality", function () {
    const nums = [1, 2, 3];
    it("works", function () {
        assert.equal(sum(nums), 6);
    })
    it("returns NaN if invalid input", () => {
        assert.equal(isNaN(sum(["a", "b", "c"])), true);
    })
})