$(document).ready(function () {
    var mostrandoFiltros = false;
    $('#buscaTag').on('change', function () {
        var itemText = $('#buscaTag option:selected').text();

        var el = document.createElement("span");
        el.className = "tags";
        el.id = "tags-" + this.value;
        el.textContent = itemText;
        console.log(itemText);

        var inner = document.createElement("input");
        inner.hidden = true;
        inner.name = "tags";
        inner.value = this.value;

        el.append(inner);
        el.addEventListener("click", function () {
            $(this).remove();
        });

        $('#tagsSelecionadas').append(el);
    });

    $("span[id^='tags-']").on("click", function () {
        $(this).remove();
    });

    $("#filtrosHeader").on("click", function () {
        if (mostrandoFiltros == true) {
            mostrandoFiltros = false;
            $('#filtrosBody').hide();
        }
        else {
            mostrandoFiltros = true;
            $('#filtrosBody').show();
        }
    });

})
