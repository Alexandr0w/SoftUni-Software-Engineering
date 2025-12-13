function solve(input) {
    let index = 0;
    const n = Number(input[index++]);

    const astronauts = {};

    for (let i = 0; i < n; i++) {
        const line = input[index++];
        const [name, section, skillsStr] = line.split(" ");
        const skills = skillsStr.split(",");

        astronauts[name] = {
            section,
            skills
        };
    }

    while (input[index] !== "End") {
        const commandParts = input[index++].split(" / ");
        const action = commandParts[0];

        if (action === "Perform") {
            const name = commandParts[1];
            const section = commandParts[2];
            const skill = commandParts[3];

            if (astronauts[name].section === section && astronauts[name].skills.includes(skill)) {
                console.log(`${name} has successfully performed the skill: ${skill}!`);
            } else {
                console.log(`${name} cannot perform the skill: ${skill}.`);
            }

        } else if (action === "Transfer") {
            const name = commandParts[1];
            const newSection = commandParts[2];

            astronauts[name].section = newSection;
            console.log(`${name} has been transferred to: ${newSection}`);

        } else if (action === "Learn Skill") {
            const name = commandParts[1];
            const newSkill = commandParts[2];

            if (astronauts[name].skills.includes(newSkill)) {
                console.log(`${name} already knows the skill: ${newSkill}.`);
            } else {
                astronauts[name].skills.push(newSkill);
                console.log(`${name} has learned a new skill: ${newSkill}.`);
            }
        }
    }

    for (const name in astronauts) {
        const section = astronauts[name].section;
        const sortedSkills = astronauts[name].skills.sort((a, b) => a.localeCompare(b));

        console.log(`Astronaut: ${name}, Section: ${section}, Skills: ${sortedSkills.join(", ")}`
        );
    }
}

solve([
    "2",
    "Alice command_module piloting,communications",
    "Bob engineering_bay repair,maintenance",
    "Perform / Alice / command_module / piloting",
    "Perform / Bob / command_module / repair",
    "Learn Skill / Alice / navigation",
    "Perform / Alice / command_module / navigation",
    "Transfer / Bob / command_module",
    "Perform / Bob / command_module / maintenance",
    "End"
])