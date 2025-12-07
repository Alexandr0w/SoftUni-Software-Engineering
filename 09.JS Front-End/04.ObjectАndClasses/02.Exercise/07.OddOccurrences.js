function oddOccurrences(text) {
    const words = text.split(" ");
    const freq = {};

    for (const word of words) {
        const lowerCased = word.toLowerCase();
        if (!(lowerCased in freq)) freq[lowerCased] = 0;
        freq[lowerCased]++;
    }

    const result = [];
    const added = new Set();

    for (const word of words) {
        const lowerCased = word.toLowerCase();

        if (freq[lowerCased] % 2 !== 0 && !added.has(lowerCased)) {
            result.push(lowerCased);
            added.add(lowerCased);
        }
    }

    console.log(result.join(" "));
}

oddOccurrences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
oddOccurrences("Cake IS SWEET is Soft CAKE sweet Food");