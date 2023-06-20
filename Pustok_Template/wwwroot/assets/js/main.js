$(document).on("click", ".modal-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href");
   /* alert(url)*/
    fetch(url).then(response => response.text()).then(data => {
        console.log(data)
        $("#quickModal .modal-dialog").html(data)
    })
    $("#quickModal").modal("show")
})


$(document).on("click", ".add-basket-btn", function (e) {
    e.preventDefault();
    let url = $(this).attr("href");
    /* alert(url);*/
    fetch(url).then(response => {
        if (!response.ok) {
            alert("Xeta bas verdi")
        }
        else return response.text()
    }).then(data => {
        $("#basketCart").html(data)
    })

})