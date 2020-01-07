document.addEventListener('DOMContentLoaded', () => {

    const dateact = document.getElementById('dateact');
    let d = new Date();
    let monthact = d.getMonth() + 1, dayact = d.getDay(), montlet = "", daylet = "";
    const months = ['', 'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];

    for (let i = 0; i < months.length; i++) {
        if (monthact == i) {
            montlet = months[i];
        }
    }

    const days = ['', 'Lunes', 'Martes', 'Miercoles', 'Jueves', 'Viernes', 'Sabado', 'Domingo'];

    for (let d = 0; d < days.length; d++) {
        if (dayact == d) {
            daylet = days[d];
        }
    }

    dateact.textContent = daylet + " " + d.getDate() + " de " + montlet + " del " + d.getFullYear() + ".";

});