const { lookupChar } = require("./CharLookup");
const { assert } = require("chai");
describe("check loopuChar func functionality", () => {
    it("works with valid input", () => {
        assert.equal(lookupChar("Chuck", 3), "c");
    }),
        it("returns undefined when invalid input type", () => {
            assert.equal(lookupChar(12312312, 3), undefined);
            assert.equal(lookupChar("sdfdsf", [2, 3, 4]), undefined);
            assert.equal(lookupChar("sdfds", 4.123), undefined);
        }),
        it("returns error message when index is invalid", () => {
            assert.equal(lookupChar("sdfsdfsd", -2), "Incorrect index");
            assert.equal(lookupChar("1234", 10), "Incorrect index");
        })
})