function objectFactory(library, orders) {
    let objects = [];
    for (order of orders) {
        const newObj = {};
        for (let prop in order.template) {
            newObj[prop] = order.template[prop];
        }
        for (const element of order.parts) {
            newObj[element] = library[element];
        }
        objects.push(newObj);
    }
    return objects;
}