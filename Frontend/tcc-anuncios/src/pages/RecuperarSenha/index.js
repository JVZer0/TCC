import React, { useCallback, useState } from 'react';
import { Link, useHistory } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'
import '../RecuperarSenha/style.css'

import Logo from '../../assets/image/Capturar.PNG';
import { ToastContainer, toast } from 'react-toastify';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function RecuperarSenha(){
    const navegacao = useHistory();

    const [cpf, setCpf] = useState("");
    const [rg, setRg] = useState("");

    const recuperar = async (e) => {
        e.preventDefault();
        try{
            let cpfMask = `${cpf.substring(0,3)}.${cpf.substring(3,6)}.${cpf.substring(6,9)}-${cpf.substring(9,11)}`;
            
            const modelo = {
                CPF: cpfMask,
                RG: rg
            };
            const resp = await api.recuperar(modelo);
            console.log(resp)
            navegacao.push("/Senha", resp.data)
        }
        catch (e) {
            toast.error(e.response.data.mensagem)
        }
    }

    return(
        <div className="vo">

            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="pai">
                <div className="fi">

                    <label className="v1">Digite o seu CPF e seu RG para recuperar sua senha</label>

                    <div>
                    <label className="mama1">CPF:</label>
                    <input className="v25" type="text" value={cpf} onChange={(e) => setCpf(e.target.value)} placeholder="CPF"></input>
                    </div>
                    
                    <div>
                    <label className="mama2">RG:</label>
                    <input className="v2" type="text" value={rg} onChange={(e) => setRg(e.target.value)} placeholder="RG"></input>
                    </div>

                    <button className="v3" onClick={recuperar}>Verificar</button>
                </div>
            </div>
            <ToastContainer/>
        </div>
    )
}
