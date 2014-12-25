function submit() {
    $("#form1").submit(function (event) {
        event.preventDefault();
    });
}


function closeWindows() {
    window.close();
}

function disableControls() {
    document.getElementById("txbx_Name").disable = true;
}



