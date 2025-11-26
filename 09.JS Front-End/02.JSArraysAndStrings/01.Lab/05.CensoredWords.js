function censorWord(text, wordToCensor) {
    let startTemplate = '*'.repeat(wordToCensor.length);
    text = text.replaceAll(wordToCensor, startTemplate);

    console.log(text);
}

censorWord('A small sentence with some words', 'small');