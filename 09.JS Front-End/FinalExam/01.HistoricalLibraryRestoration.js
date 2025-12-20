function solve(input) {
    const numManuscripts = parseInt(input[0]);
    const manuscripts = [];

    for (let i = 1; i <= numManuscripts; i++) {
        const line = input[i];
        const [title, topicsStr, preservationLevelStr] = line.split('-');

        const manuscript = {
            title: title,
            topics: topicsStr.split(','),
            preservationLevel: parseInt(preservationLevelStr),
        };
        manuscripts.push(manuscript);
    }

    const manuscriptMap = new Map();
    manuscripts.forEach(m => manuscriptMap.set(m.title, m));

    let commandIndex = numManuscripts + 1;
    let command = input[commandIndex];

    while (command !== "Restoration Complete!") {
        const parts = command.split(' & ');
        const action = parts[0];
        const title = parts[1];
        const manuscript = manuscriptMap.get(title);

        if (manuscript) {
            switch (action) {
                case "Research":
                    const topicToResearch = parts[2];
                    const requiredLevel = parseInt(parts[3]);

                    const hasTopic = manuscript.topics.includes(topicToResearch);
                    const hasEnoughPreservation = manuscript.preservationLevel >= requiredLevel;

                    if (hasTopic && hasEnoughPreservation) {
                        manuscript.preservationLevel -= requiredLevel;
                        console.log(`${title} has been researched on ${topicToResearch} and now has ${manuscript.preservationLevel} preservation level!`);
                    } else {
                        console.log(`${title} cannot be researched on ${topicToResearch} or is in poor condition!`);
                    }
                    break;

                case "Restore":
                    const restorationEffort = parseInt(parts[2]);
                    const maxLevel = 100;

                    if (manuscript.preservationLevel === maxLevel) {
                        console.log(`${title} is already fully restored!`);
                    } else {
                        const originalLevel = manuscript.preservationLevel;
                        manuscript.preservationLevel += restorationEffort;

                        if (manuscript.preservationLevel > maxLevel) {
                            manuscript.preservationLevel = maxLevel;
                        }

                        const preservationGained = manuscript.preservationLevel - originalLevel;

                        console.log(`${title} has been restored and gained ${preservationGained} preservation level!`);
                    }
                    break;

                case "Catalog":
                    const newTopic = parts[2];

                    if (manuscript.topics.includes(newTopic)) {
                        console.log(`${title} is already catalogued with ${newTopic}.`);
                    } else {
                        manuscript.topics.push(newTopic);
                        console.log(`${title} has been catalogued with ${newTopic}!`);
                    }
                    break;
            }
        }

        command = input[++commandIndex];
    }

    for (const m of manuscripts) {
        const topicsStr = m.topics.join(', ');

        console.log(`Manuscript: ${m.title}`);
        console.log(`- Topics: ${topicsStr}`);
        console.log(`- Preservation Level: ${m.preservationLevel}`);
    }
}

solve ([
    "3",
    "Codex Gigas-Demonology,Herbalism-80",
    "Voynich Manuscript-Cryptography-10",
    "Book of Kells-Illumination-60",
    "Research & Codex Gigas & Herbalism & 30",
    "Restore & Voynich Manuscript & 20",
    "Restore & Book of Kells & 50",
    "Catalog & Book of Kells & Calligraphy",
    "Research & Book of Kells & Calligraphy & 70", 
    "Restoration Complete!"
    ])
    