function solution(num) {
    return function addNum(numToAdd) {
        return num + numToAdd;
    }
}