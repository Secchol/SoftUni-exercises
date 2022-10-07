const { mathEnforcer } = require("./MathEnforcer");
const { assert } = require("chai");
describe("test math enforcer obj functionality", () => {
    it("addFive method works", () => {
        assert.equal(mathEnforcer.addFive(10), 15);
        assert.closeTo(mathEnforcer.addFive(3.14), 8.14, 0.01);
        assert.equal(mathEnforcer.addFive(-5), 0);
    }),
        it("subtractTen method works", () => {
            assert.equal(mathEnforcer.subtractTen(20), 10);
            assert.closeTo(mathEnforcer.subtractTen(22.10), 12.10, 0.01);
            assert.equal(mathEnforcer.subtractTen(-20), -30);
        }),
        it("sum method works", () => {
            assert.closeTo(mathEnforcer.sum(12.53, 3.14), 15.67, 0.01);
            assert.equal(mathEnforcer.sum(20, 30), 50);
            assert.equal(mathEnforcer.sum(-10, -20), -30);
        }),
        it("addFive method returns undefined with invalid input", () => {
            assert.equal(mathEnforcer.addFive("sdfsdfsadfaewf"), undefined);
        }),
        it("subtractTen method returns undefined with invalid input", () => {
            assert.equal(mathEnforcer.subtractTen([1, 23, 4, 512]), undefined);
        }),
        it("sum method returns undefined with invalid input", () => {
            assert.equal(mathEnforcer.sum([10, 20], 40), undefined);
            assert.equal(mathEnforcer.sum(30, "sdfwe"), undefined);
        })

})