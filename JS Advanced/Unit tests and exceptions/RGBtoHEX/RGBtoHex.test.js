const { assert } = require("chai");
const { rgbToHexColor } = require("./RGBtoHex");
describe("check rgbToHexColor func functionality", () => {
    it("converts to black", () => {
        assert.equal(rgbToHexColor(0, 0, 0), "#000000");
    }),
        it("converts to white", () => {
            assert.equal(rgbToHexColor(255, 255, 255), "#FFFFFF");
        }),
        it("converts to SoftUni blue to #234465", () => {
            assert.equal(rgbToHexColor(35, 68, 101), "#234465");
        }),
        it("returns undefined if red value is invalid", () => {
            assert.equal(rgbToHexColor("a", 20, 30), undefined);
            assert.equal(rgbToHexColor(-1, 20, 30), undefined);
            assert.equal(rgbToHexColor(32423, 20, 30), undefined);
        }),
        it("returns undefined if blue value is invalid", () => {
            assert.equal(rgbToHexColor(10, "a", 30), undefined);
            assert.equal(rgbToHexColor(10, -20, 30), undefined);
            assert.equal(rgbToHexColor(10, 21232131, 30), undefined);
        }),
        it("returns undefined if green value is invalid", () => {
            assert.equal(rgbToHexColor(10, 20, "SDfasdf"), undefined);
            assert.equal(rgbToHexColor(30, 20, -30), undefined);
            assert.equal(rgbToHexColor(40, 20, 323432), undefined);
        })
})