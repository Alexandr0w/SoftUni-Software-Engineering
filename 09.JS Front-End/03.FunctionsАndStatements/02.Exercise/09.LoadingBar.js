function loadingBar(percentage) {
    function drawLoadingBar(done, length) {
        return `[${"%".repeat(done)}${".".repeat(length - done)}]`;
    }

    let output = "";

    if (percentage === 100) {
        console.log("100% Complete!");
        console.log(drawLoadingBar(10, 10));
    } else {
        console.log(`${percentage}% ${drawLoadingBar(percentage / 10, 10)}`);
        console.log("Still loading...");
    }
}

loadingBar(30);
loadingBar(50);
loadingBar(100);