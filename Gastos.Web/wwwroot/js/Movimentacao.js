$(document).ready(function () {
    $('#movimentacaoTag').on('change', function () {
        let itemText = $('#movimentacaoTag option:selected').text();
        let newElement = "<span><input hidden name=\"Tags[]\" value=\"" + this.value + "\"/>" + itemText + "</span> "

        $('#tagsSelecionadas').append(newElement);
    });
})



