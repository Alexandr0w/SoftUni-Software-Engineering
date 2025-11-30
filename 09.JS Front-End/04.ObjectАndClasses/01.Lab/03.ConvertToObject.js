function convertToObject (JSONobject) {
    let object = JSON.parse(JSONobject);

    for (key in object) {
        console.log(`${key}: ${object[key]}`);
    }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');