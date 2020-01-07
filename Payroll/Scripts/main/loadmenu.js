document.addEventListener('DOMContentLoaded', () => {

    // Carga el contenido del menu \\
    
    loadmenu = () => {
        try {
            $.ajax({
                url: "../ControlPayroll/LoadMenu",
                type: "POST",
                data: {},
                contentType: "application/json; charset=utf-8",
                success: (data) => {
                    console.log(data)
                    for (var i = 0; i < data.length; i++) {
                        console.log(data[i]);
                    }
                }, error: (jqXHR, exception) => {
                    fcaptureaerrorsajax(jqXHR, exception);
                }
            });
        } catch (err) {
            if (err instanceof TypeError) {
                console.log("TypeError ", err);
            } else if (err instanceof EvalError) {
                console.log("EvalError ", err);
            } else if (err instanceof RangeError) {
                console.log("RangeError ", err);
            } else {
                console.log("Error ", err);
            }
        }
    }

    loadmenu();

});