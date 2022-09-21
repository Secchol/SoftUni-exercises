function getFibonator() {
    let fibNums = [1];
    return function getNextFibNum() {
        let sum = 0;
        for (let i = fibNums.length - 2; i < fibNums.length; i++) {
            if (i >= 0) {
                sum += fibNums[i];
            }
        }
        fibNums.push(sum);
        return fibNums[fibNums.length - 2];
    };
}
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
