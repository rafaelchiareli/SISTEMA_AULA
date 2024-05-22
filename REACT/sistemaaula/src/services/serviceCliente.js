import Api from "../helpers/api";

export async function GetClientes() {
    return await Api.get("/Cliente");
}

export async function GetClienteById(id){
    return await Api.get(`/cliente/getclientesbyid/${id}`);
}
