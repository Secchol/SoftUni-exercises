const { assert } = require("chai");
const { createCalculator } = require("./AddandSubstract");
describe("Check if  createCalculator func works", () => {
    const obj = createCalculator();
    it("check if createCalc returns object with properties", () => {

        assert.equal(obj.hasOwnProperty("add"), true);
        assert.equal(obj.hasOwnProperty("subtract"), true);
        assert.equal(obj.hasOwnProperty("get"), true);
    }),
        it("returns undefined if input isnt num in add", () => {
            assert.equal(obj.add("sdfsdf"), undefined);
        }),
        it("returns undefined if input isnt num in subtract", () => {
            assert.equal(obj.subtract("sdfsdf"), undefined);
        }),
        it("get works", () => {

            assert.equal(createCalculator().get.call(undefined), 0);
        })
    it("add works", () => {
        const commandsObj = createCalculator();
        commandsObj.add(2);
        assert.equal(commandsObj.get.call(undefined), 2);
    }),
        it("substract works", () => {
            const commandsObj = createCalculator();
            commandsObj.subtract(2);
            assert.equal(commandsObj.get.call(undefined), -2);
        })

})