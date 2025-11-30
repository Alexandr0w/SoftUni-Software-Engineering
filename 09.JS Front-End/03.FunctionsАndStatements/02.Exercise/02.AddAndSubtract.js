function addSubtract(a, b, c) {
    function sum(x, y) {
        return x + y;
    }

    function subtract(x, y) {
        return x - y;
    }

    const result = subtract(sum(a, b), c);
    console.log(result);
}

addSubtract(23, 6, 10);
addSubtract(1, 17, 30);
addSubtract(42, 58, 100);