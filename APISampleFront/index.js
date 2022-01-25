let url = "https://localhost:44341/api/Puestos"

// fetch(url).then(function(response){
//     return response.json();
// }).then(function(MyJson){
//     console.log(MyJson);
// })


fetch(url, {
    method: 'POST',
    body: JSON.stringify(
        {
            "puesto": "mipuesto4"
        }
    ),
    headers:{
        //Esto informa a la API que estamos enviando un objeto en formato JSON
        "Content-type": "application/json"
    }
})
.then(res => res.json())
.then(data => console.log(data))
