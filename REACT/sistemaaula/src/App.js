import React,{useState, useEffect} from "react";
import { GetClientes } from "./services/serviceCliente";

const App = () =>{
  useEffect(() => {
GetClientes().then(res => {console.log(res.data)})
  },[])
  
  return (
    <>
    <h2>Olá Mundo!</h2>
    </>
  )
}
export default App;
