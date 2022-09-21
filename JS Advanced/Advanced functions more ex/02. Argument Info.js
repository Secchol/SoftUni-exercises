function argsType(...arguments) {

    for (let arg of arguments) {
        console.log(`${typeof (arg)}: ${arg}`);
    }
    let types = {};
    for (let arg of arguments) {
        if (types[typeof (arg)] == undefined) {
            types[typeof (arg)] = 0;
        }
        types[typeof (arg)]++;
    }
    const keyValues = Object.entries(types).sort((a, b) => b[1] - a[1]);
    for (const el of keyValues) {
        console.log(`${el[0]} = ${el[1]}`);
    }

}



