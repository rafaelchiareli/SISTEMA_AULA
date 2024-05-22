import Api from "../helpers/api";

export async function GetProdutos(){
    return await Api.get("/Produto")
}

export async function GetProdutosById(id){
    return await Api.get(`/Produto/GetProdutoById&id=${id}`);
}