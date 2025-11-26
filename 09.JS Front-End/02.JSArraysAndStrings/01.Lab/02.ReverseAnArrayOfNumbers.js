function reverseArray(n, arr) {
    let finalArray = arr
        .slice(0, n)
        .reverse();

    console.log(finalArray.join(' '));
}

reverseArray(3, [10, 20, 30, 40, 50]);