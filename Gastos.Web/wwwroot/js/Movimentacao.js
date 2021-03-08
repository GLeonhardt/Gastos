$(document).ready(function () {
    $('#movimentacaoTag').on('change', function () {
        let itemText = $('#movimentacaoTag option:selected').text();

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
})



