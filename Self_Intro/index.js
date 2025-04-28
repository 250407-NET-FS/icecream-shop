main();

function main() {
    let nodeList = document.getElementById("icecreamList");
    AddIcecream(nodeList, "Vanilla Icecream");
    printIcecreams(nodeList.childNodes);
}

function AddIcecream(list, input) {
    let item = document.createElement("li");
    item.setAttribute("class", "icecreamList");
    item.appendChild(new Text(input));
    list.append(item);
    console.log(list);
}

function printIcecreams(list) {
    let res = [];
    console.log(list);
    for (let i = 1; i < list.length; i += 2) {
        res.push(list[i].firstChild.data);
    }

    alert(res);
}