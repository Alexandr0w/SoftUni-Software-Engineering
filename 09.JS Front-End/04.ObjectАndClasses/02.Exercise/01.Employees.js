function employees(names) {
    const employees = names.map((x) => ({ name: x, personalNumber: x.length }));
    for (const employee of employees) console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
}

employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );