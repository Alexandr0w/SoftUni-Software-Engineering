function largestNumber(num1, num2, num3) {
    let largest = num1;

    if (num2 > largest) {
        largest = num2;
    } if (num3 > largest) {
        largest = num3;
    }

    console.log(`The largest number is ${largest}.`);
}

largestNumber(5, -3, 16);