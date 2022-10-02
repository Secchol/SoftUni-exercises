const { assert } = require("chai");
const { isSymmetric } = require("./symmetry");
describe("symmetry func works", () => {
    it("returns true for symmetric input", () => {
        assert.equal(isSymmetric([1, 2, 2, 1]), true);


    }),
        it("works with odd length arr", () => {
            assert.equal(isSymmetric([1, 2, 1]), true);
        }),
        it("works with string arr", () => {
            assert.equal(isSymmetric(["a", "b", "b", "a"]), true);
        }),
        it("return false for non symetric input", () => {
            assert.equal(isSymmetric([1, 2, 3]), false);
        }),
        it("returns false for num input", () => {
            assert.equal(isSymmetric(2), false);

        }),
        it("returns false for string input", () => {
            assert.equal(isSymmetric("abba"), false);
        }),
        it("returns false for mixed type input", () => {
            assert.equal(isSymmetric([1, 2, "3"]), false);

        })



})