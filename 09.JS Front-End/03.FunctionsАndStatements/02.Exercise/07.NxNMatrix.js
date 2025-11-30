function nxnMatrix(n) {
    const matrix = Array.from({ length: n }, () => Array.from({ length: n }, () => n));

    for (const row of matrix) console.log(row.join(" "));
}

nxnMatrix(3);
nxnMatrix(7);
nxnMatrix(2);