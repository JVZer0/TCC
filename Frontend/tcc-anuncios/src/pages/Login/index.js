import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";
import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import '../../components/Cabecalho/cabecalho.css';
import '../Login/style.css';

import Logo from '../../assets/image/Capturar.PNG';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function Login(){
    const navegacao = useHistory();

    const [username, setUsername] = useState("");
    const [senha, setSenha] = useState("");

    const logar = async (e) => {
        e.preventDefault();
        try {
            const modelo = {
                Username: username,
                Senha: senha
            };
            const resp = await api.login(modelo);
            navegacao.push("/Home",resp.data)
        } catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    return(
        <div>
            <form>
                <div className="cabecalho diva">
                    <div>
                        <Link className="hihi" to="/" ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                    </div>
                    <div className="barraPesquisa"></div>
                    <div className="meio"></div>
                </div>
                <div className="menuLogin diva">
                    <div className="display-4 text-center mb-5">Fazer login</div>
                    <div className="form-group row" style={{minWidth:"500px"}}>
                        <label className="col-sm-2 col-form-label"> Username: </label>
                        <div className="col-sm-8">
                        <input id="Username" type="text" value={username} onChange={(e) => setUsername(e.target.value)} className="form-control"/>
                        </div>
                    </div>
                    <div className="form-group row diva" style={{minWidth:"500px"}}>
                        <label className="col-sm-2 col-form-label"> Senha: </label>
                        <div className="col-sm-8">
                        <input id="Senha" type="password" value={senha} onChange={(e) => setSenha(e.target.value)} className="form-control"/>
                        </div>
                    </div>
                    <div className='diva'>
                        <button type="submit" className="btnbtn-primary" onClick={logar}>Logar</button>
                    </div>
                </div>
                
            </form>
            <div className='d-flex justify-content-center abc'>
                <Link to='/RecuperarSenha'>Recuperar Senha</Link>
            </div>
            <ToastContainer/>
        </div>
    )
}
