function calorieObject(foods) {
    let obj = {};
    for (let i = 0; i < foods.length - 1; i += 2) {
        obj[foods[i]] = (Number)(foods[i + 1]);
    }
    console.log(obj);
}
calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
