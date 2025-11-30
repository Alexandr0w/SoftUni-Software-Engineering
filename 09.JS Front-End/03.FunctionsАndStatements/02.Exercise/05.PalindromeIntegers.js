function palindromeIntegers(nums) {
    for (const num of nums) {
        let reversed = 0,
            iter = num;

        while (iter !== 0) {
            reversed = reversed * 10 + (iter % 10);
            iter = Math.floor(iter / 10);
        }

        console.log(reversed === num);
    }
}

palindromeIntegers([123, 323, 421, 121]);
palindromeIntegers([32, 2, 232, 1010]);