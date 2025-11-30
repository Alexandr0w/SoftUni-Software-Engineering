function substring(word, text) {
    const pattern = new RegExp(`\\b${word}\\b`, "i");
    if (pattern.test(text)) console.log(word);
    else console.log(`${word} not found!`);
}

substring("javascript", "JavaScript is the best programming language");
substring("python", "JavaScript is the best programming language");