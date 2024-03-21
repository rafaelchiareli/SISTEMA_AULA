function ExibirMensagem(titulo, mensagem, erro = false) {
    Swal.fire({
        title: titulo,
        text: mensagem,
        icon: erro == true ? "error" : "success",
    });
}

function ConfiguraDataTable(nomeTabela) {
    $(`#${nomeTabela}`).DataTable();
}