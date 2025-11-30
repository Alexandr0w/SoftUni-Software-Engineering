function perfectNumber(num) {
    const sqrt = Math.sqrt(num);
    let divisorsSum = 0;

    for (let i = 1; i <= sqrt; i++) {
        if (num % i !== 0) continue;

        divisorsSum += i;
        const otherDivisor = num / i;
        if (i !== otherDivisor) divisorsSum += otherDivisor;
    }

    if (num === divisorsSum / 2) console.log("We have a perfect number!");
    else console.log("It's not so perfect.");
}

perfectNumber(6);
perfectNumber(28);
perfectNumber(1236498);