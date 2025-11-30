function modernOfHashtag(text) {
    const regex = /#(?<val>[a-zA-Z]+)/g;

    let match = regex.exec(text);
    while (match) {
        console.log(match.groups.val);
        match = regex.exec(text);
    }
}

modernOfHashtag("Nowadays everyone uses # to tag a #special word in #socialMedia");
modernOfHashtag("The symbol # is known #variously in English-speaking #regions as the #number sign");