function city (object) {
    for (const property in object) {
        console.log(`${property} -> ${object[property]}`)
    }
}

city({ name: "Sofia", area: 492, population: 1238438, country: "Bulgaria", postCode: "1000" });