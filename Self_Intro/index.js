main();

function main() {
    let nodeList = document.getElementById("icecreamList");
    document.getElementById("printIcecreams").addEventListener("click", () => {
        printIcecreams(nodeList.childNodes);
    });
    document.getElementById("addIcecream").addEventListener("click", () => {
        AddIcecream(nodeList);
    });
}

function AddIcecream(list) {
    let item = document.createElement("li");
    let input = document.getElementById("icecreamInput").value;
    item.setAttribute("class", "icecreamList");
    item.appendChild(new Text(input));
    list.append(item);
    console.log(input);
}

function printIcecreams(list) {
    let res = [];
    console.log(list);
    for (let i = 1; i < list.length; i += 2) {
        res.push(list[i].firstChild.data);
    }
    // for Challenge V
    //alert(res);
    Toastify({
        text: res,
        duration: 2000,
        close: true,
        gravity: "top",
        position: "right",
        stopOnFocus: true,
        style: {
            background: "linear-gradient(to right, #00b09b, #96c93d)",
        }
    }).showToast();
}