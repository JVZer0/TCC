import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import '../../components/Cabecalho/cabecalho.css'
import '../Login/style.css'

import Logo from '../../assets/image/Capturar.PNG'



export default function Login(){
    const navegacao = useHistory();

    const [username, setUsername] = useState("");
    const [senha, setSenha] = useState("");

    const logar = async (e)=> {
        e.preventDefault();
        try {
            const m = {
                username:username,
                senha:senha
            };
            const resp = "A";
            navegacao.push("/Home")
        } catch (e) {
            toast.error(e.response)
        }
    }

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px"/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>


            <div className="menuLogin">
                <div className="display-4 text-center mb-5">Fazer login</div>
                <div className="form-group row" style={{minWidth:"500px"}}>
                    <label className="col-sm-2 col-form-label"> Username: </label>
                    <div className="col-sm-8">
                    <input id="Username" type="text" value={username} onChange={(e) => setUsername(e.target.value)} className="form-control"/>
                    </div>
                </div>
                <div className="form-group row" style={{minWidth:"500px"}}>
                    <label className="col-sm-2 col-form-label"> Senha: </label>
                    <div className="col-sm-8">
                    <input id="Senha" type="password" value={senha} onChange={(e) => setSenha(e.target.value)} className="form-control"/>
                    </div>
                </div>
                <div>
                    <button type="submit" className="btn btn-primary">Logar</button>
                </div>
            </div>
        </div>
    )
}