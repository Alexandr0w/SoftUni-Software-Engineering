function leapYear(year) {
    const isLeap = year % 400 === 0 || (year % 4 === 0 && year % 100 !== 0);
    console.log(isLeap ? "yes" : "no");
}

leapYear(1984);
leapYear(2003);
leapYear(4);