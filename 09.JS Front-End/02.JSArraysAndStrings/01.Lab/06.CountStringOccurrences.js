function printOccurenceCount(text, wordToSearch) {
    let arr = text
        .split(' ')
        .filter(word => word === wordToSearch);

    console.log(arr.length);
}

printOccurenceCount('This is a word and it also is a sentence', 'is');