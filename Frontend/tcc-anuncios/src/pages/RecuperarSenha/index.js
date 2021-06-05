import React, { useCallback, useState } from 'react';
import { Link, useHistory } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Inicial/style.css'
import '../RecuperarSenha/style.css'

import Logo from '../../assets/image/Capturar.PNG';
import { ToastContainer, toast } from 'react-toastify';

import InputMask from 'react-input-mask';

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();

export default function RecuperarSenha(){
    const navegacao = useHistory();

    const [cpf, setCpf] = useState("");
    const [rg, setRg] = useState("");

    const recuperar = async (e) => {
        e.preventDefault();
        try{
            let rgMask = `${rg.substring(0,2)}.${rg.substring(2,5)}.${rg.substring(5,8)}-${rg.substring(8,10)}`;
            
            const modelo = {
                CPF: cpf,
                RG: rgMask
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
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="180" height="34px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>
            <form>
                <div className="pai">
                    <div className="fi">

                        <label className="v1">Digite o seu CPF e seu RG para recuperar sua senha</label>

                        <div className="aaaa">
                            <div className="labels1">
                                <label className="mama1">CPF:</label>
                                <label className="mama2">RG: (Somente números)</label>
                            </div>
                            <div className="labels1">
                                <InputMask className="v25" value={cpf} mask="999.999.999-99" onChange={(e) => setCpf(e.target.value)} placeholder="CPF"/>
                                <input className="v2" type="text" value={rg} onChange={(e) => setRg(e.target.value)} placeholder="RG"></input>
                            </div>
                        </div>

                        {/* <div>
                            <label className="mama1">CPF:</label>
                            <InputMask className="v25" value={cpf} mask="999.999.999-99" onChange={(e) => setCpf(e.target.value)} placeholder="CPF"/>
                        </div>
                        
                        <div>
                            <label className="mama2">RG: (Somente números)</label>
                            <input className="v2" type="text" value={rg} onChange={(e) => setRg(e.target.value)} placeholder="RG"></input>
                        </div> */}

                        <button className="v3" onClick={recuperar}>Verificar</button>
                    </div>
                </div>
            </form>
            <ToastContainer/>
        </div>
    )
}
