function farmManagementSystem(input) {
    let index = 0;
    const n = Number(input[index++]);

    const farmers = {};

    for (let i = 0; i < n; i++) {
        const [name, area, tasksPart] = input[index++].split(" ");
        const tasks = tasksPart.split(",");

        farmers[name] = {
            area,
            tasks
        };
    }

    while (input[index] !== "End") {
        const commandParts = input[index++].split(" / ");
        const action = commandParts[0];
        const name = commandParts[1];

        if (action === "Execute") {
            const area = commandParts[2];
            const task = commandParts[3];

            if (
                farmers[name].area === area &&
                farmers[name].tasks.includes(task)
            ) {
                console.log(`${name} has executed the task: ${task}!`);
            } else {
                console.log(`${name} cannot execute the task: ${task}.`);
            }

        } else if (action === "Change Area") {
            const newArea = commandParts[2];
            farmers[name].area = newArea;
            console.log(`${name} has changed their work area to: ${newArea}`);

        } else if (action === "Learn Task") {
            const newTask = commandParts[2];

            if (farmers[name].tasks.includes(newTask)) {
                console.log(`${name} already knows how to perform ${newTask}.`);
            } else {
                farmers[name].tasks.push(newTask);
                console.log(`${name} has learned a new task: ${newTask}.`);
            }
        }
    }

    for (const name in farmers) {
        const sortedTasks = farmers[name].tasks.sort((a, b) => a.localeCompare(b));
        console.log(`Farmer: ${name}, Area: ${farmers[name].area}, Tasks: ${sortedTasks.join(", ")}`);
    }
}

farmManagementSystem(["2", "John garden watering,weeding", "Mary barn feeding,cleaning", "Execute / John / garden / watering", "Execute / Mary / garden / feeding", "Learn Task / John / planting", "Execute / John / garden / planting", "Change Area / Mary / garden", "Execute / Mary / garden / cleaning", "End"]);
farmManagementSystem(["3", "Alex apiary harvesting,honeycomb", "Emma barn milking,cleaning", "Chris garden planting,weeding", "Execute / Alex / apiary / harvesting", "Learn Task / Alex / beeswax", "Execute / Alex / apiary / beeswax", "Change Area / Emma / apiary", "Execute / Emma / apiary / milking", "Execute / Chris / garden / watering", "Learn Task / Chris / pruning", "Execute / Chris / garden / pruning", "End"]);