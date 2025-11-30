function rotationArray(arr, rotations) {
    const result = [];
    for (let i = 0; i < arr.length; i++) result.push(arr[(i + rotations) % arr.length]);

    console.log(result.join(" "));
}

rotationArray([51, 47, 32, 61, 21], 2);
rotationArray([32, 21, 61, 1], 4);
rotationArray([2, 4, 15, 31], 5);