$(document).ready(function () {
    let index = 0;

    $('#movimentacaoTag').on('change', function () {
        let itemText = $('#movimentacaoTag option:selected').text();
        let newElement = "<span><input hidden name=\"Tags[]\" value=\"" + this.value + "\"/>" + itemText + "</span> "

        $('#tagsSelecionadas').append(newElement);
    });

    

})



