main();

function main() {
    document.getElementById("callPokemon").addEventListener("click", () => {
        let name = document.getElementById("name").value;
        fetchAPI(name);
    });
}

async function fetchAPI(name) {
    console.log(name);
    await fetch(`https://pokeapi.co/api/v2/pokemon/${name}`)
        .then((res) => res.json())
        .then((data) => {
            document.getElementById("pokemonName").innerHTML = data.name;
            document.getElementById("pokemonHP").innerHTML = data.stats[0].base_stat;
    });
    // For Challenge II
    //alert(res.text);
}