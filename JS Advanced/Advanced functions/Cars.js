function carsModifier(commands) {
    let objHolder = {};
    let commandsObj = {
        create: (name) => objHolder[name] = {},
        inherit: (name, parentName) => {
            objHolder[name] = {};
            for (let [key, value] in objHolder[parentName]) {
                objHolder[name][key] = value;
            }
        },
        set: (name, key, value) => {
            objHolder[name][key] = value;
        },
        print: (name) => {
            let props = Object.entries(objHolder[name]);
            props = props.map(x => {
                let joinedX = x.join(":");
                return joinedX;
            });
            console.log(props.join(","));
        }
    }
    for (let command of commands) {
        let commandsSplit = command.split(" ");
        let action = commandsSplit[0];
        let name = commandsSplit[1];
        if (commandsSplit[2] == "inherit") {
            let parentName = commandsSplit[3];
            commandsObj.inherit(name, parentName);
        }
        else if (action == "create") {
            commandsObj.create(name);
        }
        else if (action == "set") {
            let key = commandsSplit[2];
            let value = commandsSplit[3];
            commandsObj.set(name, key, value);
        }
        else if (action == "print") {
            commandsObj.print(name);
        }
    }

}
carsModifier(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);