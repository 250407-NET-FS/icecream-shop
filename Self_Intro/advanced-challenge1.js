main();

function main() {
    document.getElementById("work").addEventListener("click", () => {
        let header = document.getElementById("header");
        header.innerHTML = "Working, Please Wait";
        setTimeout(() => {
            header.innerHTML = "Waiting";
        }, 5000);

    });
}